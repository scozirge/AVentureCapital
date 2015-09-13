using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class DamageData
{
    public int ID { get; private set; }
    public float Probability { get; private set; }
    public int BaseDamage { get; private set; }
    public float AttackRate { get; private set; }
    public int AttackValue { get; private set; }
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
            BaseDamage = int.Parse(item["BaseDamage"].ToString());
            AttackRate = float.Parse(item["AttackRate"].ToString());
            AttackValue = int.Parse(item["AttackValue"].ToString());
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
