using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class EventResultData
{
    public int ID { get; private set; }
    public string Description { get; private set; }
    public int MonsterEvent { get; private set; }
    public int Gold { get; private set; }
    public int Clue { get; private set; }
    public int Root { get; private set; }
    public int ElderSign { get; private set; }
    public int Drop { get; private set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, EventResultData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/EventResult").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["EventResult"];
        for (int i = 0; i < items.Count; i++)
        {
            EventResultData armorData = new EventResultData(items[i]);
            int id = int.Parse(items[i]["ID"].ToString());
            _dic.Add(id, armorData);
        }
    }
    EventResultData(JsonData _item)
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
                    case "Description":
                        Description = item[key].ToString();
                        break;
                    case "MonsterEvent":
                        MonsterEvent = int.Parse(item[key].ToString());
                        break;
                    case "Gold":
                        Gold = int.Parse(item[key].ToString());
                        break;
                    case "Clue":
                        Clue = int.Parse(item[key].ToString());
                        break;
                    case "Root":
                        Root = int.Parse(item[key].ToString());
                        break;
                    case "Drop":
                        Drop = int.Parse(item[key].ToString());
                        break;
                    default:
                        Debug.LogWarning(string.Format("EventResult表有不明屬性:{0}", key));
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
    /// <summary>
    /// 取得戰利品回饋描述
    /// </summary>
    public string GetFeedbackDescription()
    {
        string str = "";
        if (Gold > 0)
            str += string.Format("獲得金幣{0}", Gold);
        if (Clue > 0)
        {
            if (str != "")
                str += ",";
            str += string.Format("取得{0}個線索", Clue);
        }
        if (Root > 0)
        {
            if (str != "")
                str += ",";
            str += string.Format("獲得戰利品{0}件", Root);
        }
        if (MonsterEvent > 0)
        {
            if (str != "")
                str += ",並";
            str += "展開戰鬥";
        }
        if (str == "")
            str = "什麼事都沒有發生";
        return str;
    }
    /// <summary>
    /// 檢查是否有戰鬥
    /// </summary>
    public bool CheckFight()
    {
        if (MonsterEvent > 0)
            return true;
        return false;
    }
}

