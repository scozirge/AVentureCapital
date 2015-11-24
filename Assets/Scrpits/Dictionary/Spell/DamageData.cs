using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class DamageData
{
    public int ID { get; private set; }
    //觸發機率
    public float Probability { get; private set; }
    //延遲顯示扣血
    public float ShowDelay { get; private set; }
    //物攻加值
    public int PAttack { get; protected set; }
    //物傷乘值
    public float PLethalityRate { get; protected set; }
    //魔攻加值
    public int MAttack { get; protected set; }
    //魔傷乘值
    public float MLethalityRate { get; protected set; }
    //絕對傷害
    public int AbsoluteDamage { get; protected set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, DamageData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Damage").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData DamageItems = jd["Damage"];
        for (int i = 0; i < DamageItems.Count; i++)
        {
            DamageData DamageData = new DamageData(DamageItems[i]);
            int id = int.Parse(DamageItems[i]["ID"].ToString());
            _dic.Add(id, DamageData);
        }
    }
    DamageData(JsonData _item)
    {
        try
        {
            JsonData item = _item;
            ID = int.Parse(item["ID"].ToString());
            Probability = float.Parse(item["Probability"].ToString());
            ShowDelay = float.Parse(item["ShowDelay"].ToString());
            PAttack = int.Parse(item["PAttack"].ToString());
            PLethalityRate = float.Parse(item["PLethalityRate"].ToString());
            MAttack = int.Parse(item["MAttack"].ToString());
            MLethalityRate = float.Parse(item["MLethalityRate"].ToString());
            AbsoluteDamage = int.Parse(item["AbsoluteDamage"].ToString());
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
