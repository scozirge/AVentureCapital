using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class InvestigateEventData
{
    public int ID { get; private set; }
    public int GroupID { get; private set; }
    public string Description { get; private set; }
    public string Talk1 { get; private set; }
    public string Talk2 { get; private set; }
    public string ConfirmTalk { get; private set; }
    public string CancelTalk { get; private set; }
    public int[] Result { get; private set; }
    public int[] ResultWeight { get; private set; }

    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, List<InvestigateEventData>> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/InvestigateEvent").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["InvestigateEvent"];
        for (int i = 0; i < items.Count; i++)
        {
            InvestigateEventData armorData = new InvestigateEventData(items[i]);
            int id = int.Parse(items[i]["ID"].ToString());
            int groupID = int.Parse(items[i]["GroupID"].ToString());
            if (_dic.ContainsKey(groupID))
                _dic[groupID].Add(armorData);
            else
            {
                List<InvestigateEventData> eventDataList = new List<InvestigateEventData>();
                eventDataList.Add(armorData);
                _dic.Add(groupID, eventDataList);
            }
        }
    }
    InvestigateEventData(JsonData _item)
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
                    case "Description":
                        Description = item[key].ToString();
                        break;
                    case "Talk1":
                        Talk1 = item[key].ToString();
                        break;
                    case "Talk2":
                        Talk2 = item[key].ToString();
                        break;
                    case "ConfirmTalk":
                        ConfirmTalk = item[key].ToString();
                        break;
                    case "CancelTalk":
                        CancelTalk = item[key].ToString();
                        break;
                    case "Result":
                        string[] resultStrs = item[key].ToString().Split(',');
                        Result = new int[resultStrs.Length];
                        for (int i = 0; i < Result.Length; i++)
                        {
                            int resultID = int.Parse(resultStrs[i]);
                            if (resultID == 0)
                            {
                                Debug.LogWarning(string.Format("調查事件ID:{0}的ResultID為0", ID));
                                continue;
                            }
                            Result[i] = resultID;
                        }
                        break;
                    case "ResultWeight":
                        string[] resultWeightStrs = item[key].ToString().Split(',');
                        if (resultWeightStrs.Length != Result.Length)
                            Debug.LogWarning("出怪群組長度跟權重長度不一樣");
                        ResultWeight = new int[resultWeightStrs.Length];
                        for (int i = 0; i < ResultWeight.Length; i++)
                        {
                            int resultWeight = int.Parse(resultWeightStrs[i]);
                            if (resultWeight == 0)
                            {
                                Debug.LogWarning(string.Format("調查事件ID:{0}的ResultWeight為0", ID));
                                continue;
                            }
                            ResultWeight[i] = resultWeight;
                        }
                        break;
                    default:
                        Debug.LogWarning(string.Format("InvestigateEvent表有不明屬性:{0}", key));
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
