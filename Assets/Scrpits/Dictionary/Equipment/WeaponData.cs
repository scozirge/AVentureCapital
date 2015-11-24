using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class WeaponData : EquipmentData
{
    public int SpellID { get; private set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, WeaponData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Weapon").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData spellItems = jd["Weapon"];
        for (int i = 0; i < spellItems.Count; i++)
        {
            WeaponData weaponData = new WeaponData(spellItems[i]);
            int id = int.Parse(spellItems[i]["ID"].ToString());
            _dic.Add(id, weaponData);
        }
    }
    WeaponData(JsonData _item)
        : base(_item)
    {
        try
        {
            JsonData item = _item;
            foreach (string key in item.Keys)
            {
                switch (key)
                {
                    case "SpellID":
                        SpellID = int.Parse(item[key].ToString());
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
