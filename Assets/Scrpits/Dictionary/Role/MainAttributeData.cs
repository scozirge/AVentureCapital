using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class MainAttributeData
{
    public MainAttribute MainAttribute { get; private set; }
    public int Health { get; protected set; }
    public int HealthRecover { get; protected set; }
    public int Vitality { get; protected set; }
    public int VitalityRecover { get; protected set; }
    public int PAttack { get; protected set; }
    public int MAttack { get; protected set; }
    public int PDefense { get; protected set; }
    public int MDefense { get; protected set; }
    public int Accuracy { get; protected set; }
    public int Dodge { get; protected set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<MainAttribute, MainAttributeData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/MainAttribute").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["MainAttribute"];
        for (int i = 0; i < items.Count; i++)
        {
            MainAttributeData data = new MainAttributeData(items[i]);
            MainAttribute attribute = (MainAttribute)Enum.Parse(typeof(MainAttribute), items[i]["MainAttribute"].ToString());
            if (_dic.ContainsKey(attribute))
            {
                Debug.LogWarning("MainAttribute的主屬性名稱重複");
                break;
            }
            _dic.Add(attribute, data);
        }
    }
    MainAttributeData(JsonData _item)
    {
        try
        {
            JsonData item = _item;
            foreach (string key in item.Keys)
            {
                switch (key)
                {
                    case "MainAttribute":
                        MainAttribute = (MainAttribute)Enum.Parse(typeof(MainAttribute), item[key].ToString());
                        break;
                    case "Health":
                        Health = int.Parse(item[key].ToString());
                        break;
                    case "HealthRecover":
                        HealthRecover = int.Parse(item[key].ToString());
                        break;
                    case "Vitality":
                        Vitality = int.Parse(item[key].ToString());
                        break;
                    case "VitalityRecover":
                        VitalityRecover = int.Parse(item[key].ToString());
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
                    case "Accuracy":
                        Accuracy = int.Parse(item[key].ToString());
                        break;
                    case "Dodge":
                        Dodge = int.Parse(item[key].ToString());
                        break;
                    default:
                        Debug.LogWarning(string.Format("MainAttribute表有不明屬性:{0}", key));
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

