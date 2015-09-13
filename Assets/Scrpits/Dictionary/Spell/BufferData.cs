using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class BufferData
{
    public int ID { get; private set; }
    public float Probability { get; private set; }
    public BufferType Type { get; private set; }
    public bool IsBuff { get; private set; }
    public bool IsDeBuff { get; private set; }
    public float Duration { get; private set; }
    public float Circle { get; private set; }
    public bool IniTrigger { get; private set; }
    public string TriggerExecute { get; private set; }
    public bool Stackable { get; private set; }
    public int MaxStack { get; private set; }
    public int AttackValue { get; private set; }
    public float AttackRate { get; private set; }
    public int DefenseValue { get; private set; }
    public float DefenseRate { get; private set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, BufferData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Buffer").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData BufferItems = jd["Buffer"];
        for (int i = 0; i < BufferItems.Count; i++)
        {
            BufferData BufferData = new BufferData(BufferItems[i]);
            int id = int.Parse(BufferItems[i]["ID"].ToString());
            _dic.Add(id, BufferData);
        }
    }
    BufferData(JsonData _item)
    {
        try
        {
            JsonData item = _item;
            ID = int.Parse(item["ID"].ToString());
            Probability = float.Parse(item["Probability"].ToString());
            Type = (BufferType)Enum.Parse(typeof(BufferType), item["Probability"].ToString());
            IsBuff = bool.Parse(item["IsBuff"].ToString());
            IsDeBuff = bool.Parse(item["IsDeBuff"].ToString());
            Duration = float.Parse(item["Duration"].ToString());
            Circle = float.Parse(item["Circle"].ToString());
            IniTrigger = bool.Parse(item["IniTrigger"].ToString());
            TriggerExecute = item["TriggerExecute"].ToString();
            Stackable = bool.Parse(item["Stackable"].ToString());
            MaxStack = int.Parse(item["MaxStack"].ToString());
            AttackValue = int.Parse(item["AttackValue"].ToString());
            AttackRate = float.Parse(item["AttackRate"].ToString());
            DefenseValue = int.Parse(item["DefenseValue"].ToString());
            DefenseRate = float.Parse(item["DefenseRate"].ToString());
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
