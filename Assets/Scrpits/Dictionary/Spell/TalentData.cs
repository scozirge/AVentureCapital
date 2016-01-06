using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class TalentData
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string SpriteName { get; private set; }
    public Sprite IconSprite;
    public int GainBuffer { get; private set; }
    public int GainActivitySpell { get; private set; }
    public int GainPassiveSpell { get; private set; }
    public MainAttribute ModulateAttribute { get; private set; }
    public AddAttribute[] AddAttributes { get; private set; }
    public struct AddAttribute
    {
        public MinorAttribute MinorAttr { get; private set; }
        public int Value { get; private set; }
        public AddAttribute(MinorAttribute _attr, int _value)
        {
            MinorAttr = _attr;
            Value = _value;
        }
    }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, TalentData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Talent").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["Talent"];
        for (int i = 0; i < items.Count; i++)
        {
            TalentData data = new TalentData(items[i]);
            int lv = data.ID;
            if (_dic.ContainsKey(lv))
            {
                Debug.LogWarning("Talent表的ID重複");
                break;
            }
            _dic.Add(lv, data);
        }
    }
    TalentData(JsonData _item)
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
                    case "SpriteName":
                        SpriteName = item[key].ToString();
                        SetSprite();
                        break;
                    case "GainBuffer":
                        GainBuffer = int.Parse(item[key].ToString());
                        break;
                    case "GainActivitySpell":
                        GainActivitySpell = int.Parse(item[key].ToString());
                        break;
                    case "GainPassiveSpell":
                        GainPassiveSpell = int.Parse(item[key].ToString());
                        break;
                    case "MainAttributeExtraAdd":
                        SetModulateAttribute(item[key].ToString());
                        break;
                    default:
                        Debug.LogWarning(string.Format("Talent表有不明屬性:{0}", key));
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
    /// 設定主屬性額外加值屬性
    /// </summary>
    void SetModulateAttribute(string _str)
    {
        try
        {
            string[] strArray = _str.Split(':');
            ModulateAttribute = (MainAttribute)Enum.Parse(typeof(MainAttribute), strArray[0]);
            string[] addAttrStrs = strArray[1].Split(',');
            AddAttributes = new AddAttribute[addAttrStrs.Length];
            for (int i = 0; i < addAttrStrs.Length; i++)
            {
                string[] values = addAttrStrs[i].Split('+');
                AddAttribute addAttr = new AddAttribute((MinorAttribute)Enum.Parse(typeof(MinorAttribute), values[0]), int.Parse(values[1]));
                AddAttributes[i] = addAttr;
            }
        }
        catch (Exception ex)
        {
            Debug.LogWarning("Talent表設定ModulateAttribute時發生錯誤");
            Debug.LogException(ex);
        }
    }
    void SetSprite()
    {
        IconSprite = GameDictionary.SpriteDic[SpriteName].MySprite;
    }
}

