using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class DropData
{
    public int ID { get; private set; }
    int[] Weapons { get; set; }
    int[] WeaponWeights { get; set; }
    int[] Armors { get; set; }
    int[] ArmorWeights { get; set; }
    int[] Protectors { get; set; }
    int[] ProtectorWeights { get; set; }
    public int[] AllThings { get; private set; }
    public int[] AllWeights { get; private set; }

    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, DropData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Drop").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["Drop"];
        for (int i = 0; i < items.Count; i++)
        {
            DropData dropData = new DropData(items[i]);
            int id = int.Parse(items[i]["ID"].ToString());
            _dic.Add(id, dropData);
        }
    }
    DropData(JsonData _item)
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
                    case "Weapon":
                        Weapons = TextManager.StringSplitToIntArray(item[key].ToString(), ',');
                        break;
                    case "WeaponWeight":
                        WeaponWeights = TextManager.StringSplitToIntArray(item[key].ToString(), ',');
                        break;
                    case "Armor":
                        Armors = TextManager.StringSplitToIntArray(item[key].ToString(), ',');
                        break;
                    case "ArmorWeight":
                        ArmorWeights = TextManager.StringSplitToIntArray(item[key].ToString(), ',');
                        break;
                    case "Proctor":
                        Protectors = TextManager.StringSplitToIntArray(item[key].ToString(), ',');
                        break;
                    case "ProctorWeight":
                        ProtectorWeights = TextManager.StringSplitToIntArray(item[key].ToString(), ',');
                        break;
                    default:
                        Debug.LogWarning(string.Format("Drop表有不明屬性:{0}", key));
                        break;
                }
            }
            SetThings();
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
    void SetThings()
    {
        //總品項數量
        int thingCount=0;
        if(Weapons!=null)
            thingCount += Weapons.Length;
        if(Armors!=null)
            thingCount+=Armors.Length;
        if(Protectors!=null)
            thingCount+=Protectors.Length;
        //總品項權重數量
        int weightCount = 0;
        if (WeaponWeights != null)
            weightCount += WeaponWeights.Length;
        if (ArmorWeights != null)
            weightCount += ArmorWeights.Length;
        if (ProtectorWeights != null)
            weightCount += ProtectorWeights.Length;
        if (thingCount != weightCount)
        {
            Debug.LogWarning(string.Format("掉落ID:{0}的品項數量與權重數量不一致", ID));
            return;
        }
        AllThings = new int[thingCount];
        AllWeights = new int[weightCount];
        int index = 0;
        //武器
        if (Weapons!=null)
        {
            for (int i = 0; i < Weapons.Length; i++)
            {
                if (Weapons[i] == 0 || WeaponWeights[i] == 0)
                    continue;
                AllThings[index] = Weapons[i];
                AllWeights[index] = WeaponWeights[i];
                index++;
            }
        }
        //護甲
        if (Armors!=null)
        {
            for (int i = 0; i < Armors.Length; i++)
            {
                if (Armors[i] == 0 || ArmorWeights[i] == 0)
                    continue;
                AllThings[index] = Armors[i];
                AllWeights[index] = ArmorWeights[i];
                index++;
            }
        }
        //護具
        if(Protectors!=null)
        {
            for (int i = 0; i < Protectors.Length; i++)
            {
                if (Protectors[i] == 0 || ProtectorWeights[i] == 0)
                    continue;
                AllThings[index] = Protectors[i];
                AllWeights[index] = ProtectorWeights[i];
                index++;
            }
        }
    }
}
