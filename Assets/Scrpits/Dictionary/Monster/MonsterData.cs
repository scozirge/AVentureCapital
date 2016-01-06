using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class MonsterData
{
    public int ID { get; private set; }
    public int Level { get; private set; }
    public int Group { get; private set; }
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int PAttack { get; private set; }
    public int MAttack { get; private set; }
    public int PDefense { get; private set; }
    public int MDefense { get; private set; }
    public string Spells { get; private set; }
    public int Drop { get; private set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, List<MonsterData>> _groupDic,Dictionary<int,MonsterData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Monster").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["Monster"];
        for (int i = 0; i < items.Count; i++)
        {
            MonsterData armorData = new MonsterData(items[i]);
            int id = int.Parse(items[i]["ID"].ToString());
            int groupID = int.Parse(items[i]["Group"].ToString());
            _dic.Add(id, armorData);
            if (_groupDic.ContainsKey(groupID))
                _groupDic[groupID].Add(armorData);
            else
            {
                List<MonsterData> eventDataList = new List<MonsterData>();
                eventDataList.Add(armorData);
                _groupDic.Add(groupID, eventDataList);
            }
        }
    }
    MonsterData(JsonData _item)
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
                    case "Level":
                        Level = int.Parse(item[key].ToString());
                        break;
                    case "Group":
                        Group = int.Parse(item[key].ToString());
                        break;
                    case "Name":
                        Name = item[key].ToString();
                        break;
                    case "Health":
                        Health = int.Parse(item[key].ToString());
                        break;
                    case "PAttack":
                        PAttack = int.Parse(item[key].ToString());
                        break;
                    case "MAttack":
                        MAttack = int.Parse(item[key].ToString());
                        break;
                    case "PDefense":
                        PDefense = int.Parse(item[key].ToString());
                        break;
                    case "MDefense":
                        MDefense = int.Parse(item[key].ToString());
                        break;
                    case "Spell":
                        Spells = item[key].ToString();
                        break;
                    case "Drop":
                        Drop = int.Parse(item[key].ToString());
                        break;
                    default:
                        Debug.LogWarning(string.Format("MonsterData表有不明屬性:{0}", key));
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
