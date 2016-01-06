using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class SpriteData
{
    public string Name { get; private set; }
    public string Path { get; private set; }
    public Sprite MySprite;
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<string, SpriteData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Sprite").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["Sprite"];
        for (int i = 0; i < items.Count; i++)
        {
            SpriteData data = new SpriteData(items[i]);
            string id = data.Name;
            if (_dic.ContainsKey(id))
            {
                Debug.LogWarning("Sprite表的ID重複");
                break;
            }
            _dic.Add(id, data);
        }
    }
    SpriteData(JsonData _item)
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
                    case "Path":
                        Path = item[key].ToString();
                        break;
                    default:
                        Debug.LogWarning(string.Format("Sprite表有不明屬性:{0}", key));
                        break;
                }
            }
            SetSprite();
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
    void SetSprite()
    {
        MySprite = Resources.Load<Sprite>(Path);
    }
}

