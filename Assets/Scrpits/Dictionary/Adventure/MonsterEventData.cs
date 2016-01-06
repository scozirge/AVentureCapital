using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class MonsterEventData
{
    public int ID { get; private set; }
    public int[] SpecificMonster { get; private set; }
    public int[] Group { get; private set; }
    public int[] GroupWeight { get; private set; }
    public byte MinSpawn { get; private set; }
    public byte MaxSpawn { get; private set; }

    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, MonsterEventData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/MonsterEvent").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["MonsterEvent"];
        for (int i = 0; i < items.Count; i++)
        {
            MonsterEventData armorData = new MonsterEventData(items[i]);
            int id = int.Parse(items[i]["ID"].ToString());
            _dic.Add(id, armorData);
        }
    }
    MonsterEventData(JsonData _item)
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
                    case "SpecificMonster":
                        string[] monsterStrs = item[key].ToString().Split(',');
                        if (monsterStrs.Length > 3)
                        {
                            SpecificMonster = new int[3];
                            Debug.LogWarning("出怪數量大於3");
                        }
                        else
                            SpecificMonster = new int[monsterStrs.Length];
                        for (int i = 0; i < SpecificMonster.Length; i++)
                        {
                            int monsterID = int.Parse(monsterStrs[i]);
                            if (monsterID == 0)
                            {
                                Debug.LogWarning("出怪群組ID不可為0");
                                continue;
                            }
                            SpecificMonster[i] = monsterID;
                        }
                        break;
                    case "Group":
                        string[] groupStrs = item[key].ToString().Split(',');
                        Group = new int[groupStrs.Length];
                        for (int i = 0; i < Group.Length; i++)
                        {
                            int groupID = int.Parse(groupStrs[i]);
                            if (groupID == 0)
                            {
                                Debug.LogWarning(string.Format("出怪事件ID:{0}的GroupID為0", ID));
                                continue;
                            }
                            Group[i] = groupID;
                        }
                        break;
                    case "GroupWeight":
                        string[] groupWeightStrs = item[key].ToString().Split(',');
                        if (groupWeightStrs.Length != Group.Length)
                            Debug.LogWarning("出怪群組長度跟權重長度不一樣");
                        GroupWeight = new int[groupWeightStrs.Length];
                        for (int i = 0; i < GroupWeight.Length; i++)
                        {
                            int groupWeight = int.Parse(groupWeightStrs[i]);
                            if (groupWeight == 0)
                            {
                                Debug.LogWarning(string.Format("出怪事件ID:{0}的GroupWeight為0", ID));
                                continue;
                            }
                            GroupWeight[i] = groupWeight;
                        }
                        break;
                    case "SpawnNum":
                        string[] spawnNumStr = item[key].ToString().Split(':');
                        MinSpawn = byte.Parse(spawnNumStr[0]);
                        MaxSpawn = byte.Parse(spawnNumStr[1]);
                        break;
                    default:
                        Debug.LogWarning(string.Format("MonsterEvent表有不明屬性:{0}", key));
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
