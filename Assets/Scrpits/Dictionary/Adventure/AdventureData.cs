using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class AdventureData
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Level { get; private set; }
    public int RequireLV { get; private set; }
    public int MinEvent { get; private set; }
    public int MaxEvent { get; private set; }
    public int MinEventMile { get; private set; }
    public int MaxEventMile { get; private set; }
    public int MonsterWeight { get; private set; }
    public int InvestigateWeight { get; private set; }
    public int AccidentWeight { get; private set; }
    public int CampWeight { get; private set; }
    public float Unknown { get; private set; }
    public int MonsterEvent { get; private set; }
    public int InvestigateGroup { get; private set; }
    public int AccidentGroup { get; private set; }
    public int CampGroup { get; private set; }

    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, AdventureData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Adventure").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["Adventure"];
        for (int i = 0; i < items.Count; i++)
        {
            AdventureData armorData = new AdventureData(items[i]);
            int id = int.Parse(items[i]["ID"].ToString());
            _dic.Add(id, armorData);
        }
    }
    AdventureData(JsonData _item)
    {
        try
        {
            JsonData item = _item;
            foreach (string key in item.Keys)
            {
                switch (key)
                {
                    case "ID":
                        ID = int.Parse(item[key].ToString());
                        break;
                    case "Name":
                        Name = item[key].ToString();
                        break;
                    case "Description":
                        Description = item[key].ToString();
                        break;
                    case "Level":
                        Level = int.Parse(item[key].ToString());
                        break;
                    case "RequireLV":
                        RequireLV = int.Parse(item[key].ToString());
                        break;
                    case "Event":
                        string[] eventStr = item[key].ToString().Split(':');
                        if (eventStr.Length == 2)
                        {
                            MinEvent = byte.Parse(eventStr[0]);
                            MaxEvent = byte.Parse(eventStr[1]);
                        }
                        else if (eventStr.Length == 1)
                        {
                            MinEvent = byte.Parse(eventStr[0]);
                            MaxEvent = MinEvent + 1;
                        }
                        else
                        {
                            MinEvent = 1;
                            MaxEvent = MinEvent + 1;
                            Debug.LogWarning(string.Format("冒險ID:{0}的事件數格式錯誤"));
                        }
                        if (MinEvent<=0)
                            Debug.LogWarning(string.Format("冒險ID:{0}的事件數最小不可低於0"));
                        break;
                    case "EventMile":
                        string[] eventMileStr = item[key].ToString().Split(':');
                        if (eventMileStr.Length == 2)
                        {
                            MinEventMile = byte.Parse(eventMileStr[0]);
                            MaxEventMile = byte.Parse(eventMileStr[1]);
                        }
                        else if (eventMileStr.Length == 1)
                        {
                            MinEventMile = byte.Parse(eventMileStr[0]);
                            MaxEventMile = MinEventMile + 1;
                        }
                        else
                        {
                            MinEventMile = 1;
                            MaxEventMile = MinEventMile + 1;
                            Debug.LogWarning(string.Format("冒險ID:{0}的事件里程格式錯誤"));
                        }
                        if (MinEventMile <= 0)
                            Debug.LogWarning(string.Format("冒險ID:{0}的事件數最小不可低於0"));
                        break;
                    case "MonsterWeight":
                        MonsterWeight = int.Parse(item[key].ToString());
                        break;
                    case "InvestigateWeight":
                        InvestigateWeight = int.Parse(item[key].ToString());
                        break;
                    case "AccidentWeight":
                        AccidentWeight = int.Parse(item[key].ToString());
                        break;
                    case "CampWeight":
                        CampWeight = int.Parse(item[key].ToString());
                        break;
                    case "Unknown":
                        Unknown = float.Parse(item[key].ToString());
                        break;
                    case "MonsterEvent":
                        MonsterEvent = int.Parse(item[key].ToString());
                        break;
                    case "InvestigateGroup":
                        InvestigateGroup = int.Parse(item[key].ToString());
                        break;
                    case "AccidentGroup":
                        AccidentGroup = int.Parse(item[key].ToString());
                        break;
                    case "CampGroup":
                        CampGroup = int.Parse(item[key].ToString());
                        break;
                    default:
                        Debug.LogWarning(string.Format("Adventure表有不明屬性:{0}", key));
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
