using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class ActivitySpellData
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float CD { get; private set; }
    public int ConsumeVitality { get; private set; }
    public bool IsAttack { get; private set; }
    public bool InSpareTime { get; private set; }
    public string TriggerTarget { get; private set; }
    public string IconName { get; private set; }
    public string Type { get; private set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, ActivitySpellData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/ActivitySpell").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData spellItems = jd["ActivitySpell"];
        for (int i = 0; i < spellItems.Count; i++)
        {
            ActivitySpellData spellData = new ActivitySpellData(spellItems[i]);
            int id = int.Parse(spellItems[i]["ID"].ToString());
            _dic.Add(id, spellData);
        }
    }
    ActivitySpellData(JsonData _item)
    {
        try
        {
            JsonData item = _item;
            ID = int.Parse(item["ID"].ToString());
            Name = item["Name"].ToString();
            Description = item["Description"].ToString();
            CD = float.Parse(item["CD"].ToString());
            ConsumeVitality = int.Parse(item["Vitality"].ToString());
            IsAttack = bool.Parse(item["IsAttack"].ToString());
            InSpareTime = bool.Parse(item["InSpareTime"].ToString());
            TriggerTarget = item["TriggerTarget"].ToString();
            IconName = item["Icon"].ToString();
            Type = item["Type"].ToString();
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
