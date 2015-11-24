using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class ProtectorData : EquipmentData
{
    public ProtectorType Type;
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, ProtectorData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Protector").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData protectorItems = jd["Protector"];
        for (int i = 0; i < protectorItems.Count; i++)
        {
            ProtectorData protectorData = new ProtectorData(protectorItems[i]);
            int id = int.Parse(protectorItems[i]["ID"].ToString());
            _dic.Add(id, protectorData);
        }
    }
    ProtectorData(JsonData _item)
        : base(_item)
    {
        try
        {
            JsonData item = _item;
            foreach (string key in item.Keys)
            {
                switch (key)
                {
                    case "Type":
                        Type = (ProtectorType)Enum.Parse(typeof(ProtectorType), item[key].ToString());
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
