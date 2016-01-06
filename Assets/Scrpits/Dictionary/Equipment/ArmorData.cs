using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class ArmorData : EquipmentData
{
    public int BufferID { get; private set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, ArmorData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Armor").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData armorItems = jd["Armor"];
        for (int i = 0; i < armorItems.Count; i++)
        {
            ArmorData armorData = new ArmorData(armorItems[i]);
            int id = int.Parse(armorItems[i]["ID"].ToString());
            _dic.Add(id, armorData);
        }
    }
    ArmorData(JsonData _item)
        : base(_item)
    {
        try
        {
            JsonData item = _item;
            foreach (string key in item.Keys)
            {
                switch (key)
                {
                    case "BufferID":
                        BufferID = int.Parse(item[key].ToString());
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
