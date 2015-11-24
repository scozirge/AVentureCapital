using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class PassiveSpellData
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float CD { get; private set; }
    public bool IsAttack { get; private set; }
    public string TriggerTarget { get; private set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, PassiveSpellData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/PassiveSpell").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData spellItems = jd["PassiveSpell"];
        for (int i = 0; i < spellItems.Count; i++)
        {
            PassiveSpellData spellData = new PassiveSpellData(spellItems[i]);
            int id = int.Parse(spellItems[i]["ID"].ToString());
            _dic.Add(id, spellData);
        }
    }
    PassiveSpellData(JsonData _item)
    {
        try
        {
            JsonData item = _item;
            ID = int.Parse(item["ID"].ToString());
            Name = item["Name"].ToString();
            Description = item["Description"].ToString();
            CD = float.Parse(item["CD"].ToString());
            IsAttack = bool.Parse(item["IsAttack"].ToString());
            TriggerTarget = item["TriggerTarget"].ToString();
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
