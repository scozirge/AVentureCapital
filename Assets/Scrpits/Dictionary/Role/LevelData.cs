using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class LevelData
{
    public int Level { get; private set; }
    public int NeedExp { get; private set; }
    public int Point { get; private set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, LevelData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Level").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["Level"];
        for (int i = 0; i < items.Count; i++)
        {
            LevelData data = new LevelData(items[i]);
            int lv = data.Level;
            if (_dic.ContainsKey(lv))
            {
                Debug.LogWarning("Level表的等級重複");
                break;
            }
            _dic.Add(lv, data);
        }
    }
    LevelData(JsonData _item)
    {
        try
        {
            JsonData item = _item;
            foreach (string key in item.Keys)
            {
                switch (key)
                {
                    case "Level":
                        Level = int.Parse(item[key].ToString());
                        break;
                    case "NeedExp":
                        NeedExp = int.Parse(item[key].ToString());
                        break;
                    case "Point":
                        Point = int.Parse(item[key].ToString());
                        break;
                    default:
                        Debug.LogWarning(string.Format("Level表有不明屬性:{0}", key));
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

