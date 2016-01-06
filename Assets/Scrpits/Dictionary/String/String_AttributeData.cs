using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class String_AttributeData
{
    public string Name { get; private set; }
    public string ZH_TW { get; protected set; }
    public string ZH_CN { get; protected set; }
    public string EN { get; protected set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<string, String_AttributeData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/String_Attribute").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["String_Attribute"];
        for (int i = 0; i < items.Count; i++)
        {
            String_AttributeData data = new String_AttributeData(items[i]);
            string name = items[i]["Name"].ToString();
            if (_dic.ContainsKey(name))
            {
                Debug.LogWarning("String_Attribute的主屬性名稱重複");
                break;
            }
            _dic.Add(name, data);
        }
    }
    String_AttributeData(JsonData _item)
    {
        try
        {
            JsonData item = _item;
            foreach (string key in item.Keys)
            {
                switch (key)
                {
                    case "Name":
                        Name = item[key].ToString();
                        break;
                    case "ZH-TW":
                        ZH_TW = item[key].ToString();
                        break;
                    case "ZH-CN":
                        ZH_CN = item[key].ToString();
                        break;
                    case "EN":
                        EN = item[key].ToString();
                        break;
                    default:
                        Debug.LogWarning(string.Format("String_Attribute表有不明屬性:{0}", key));
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

