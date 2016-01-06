using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class CampEventData
{
    public int ID { get; private set; }
    public int GroupID { get; private set; }
    public string Talk1 { get; private set; }
    public string Description { get; private set; }
    public int RecoverLevel { get; private set; }
    public string ConfirmTalk { get; private set; }
    public string CancelTalk { get; private set; }
    public int Weight { get; private set; }

    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, List<CampEventData>> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Camp").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["Camp"];
        for (int i = 0; i < items.Count; i++)
        {
            CampEventData armorData = new CampEventData(items[i]);
            int id = int.Parse(items[i]["ID"].ToString());
            int groupID = int.Parse(items[i]["GroupID"].ToString());
            if (_dic.ContainsKey(groupID))
                _dic[groupID].Add(armorData);
            else
            {
                List<CampEventData> eventDataList = new List<CampEventData>();
                eventDataList.Add(armorData);
                _dic.Add(groupID, eventDataList);
            }
        }
    }
    CampEventData(JsonData _item)
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
                    case "GroupID":
                        GroupID = int.Parse(item[key].ToString());
                        break;
                    case "Talk1":
                        Talk1 = item[key].ToString();
                        break;
                    case "Description":
                        Description = item[key].ToString();
                        break;
                    case "RecoverLevel":
                        RecoverLevel = int.Parse(item[key].ToString());
                        break;
                    case "ConfirmTalk":
                        ConfirmTalk = item[key].ToString();
                        break;
                    case "CancelTalk":
                        CancelTalk = item[key].ToString();
                        break;
                    default:
                        Debug.LogWarning(string.Format("Camp表有不明屬性:{0}", key));
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

