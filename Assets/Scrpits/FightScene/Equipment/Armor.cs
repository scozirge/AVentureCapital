using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Armor : Equipment
{
    public int BufferID { get; protected set; }
    /// <summary>
    /// 初始化武器，傳入武器ID
    /// </summary>
    public Armor(int _armorID)
        : base(_armorID)
    {
        Type = EquipmentTYpe.Armor;
        if (!GameDictionary.ArmorDic.ContainsKey(ID))
        {
            Debug.LogWarning("不存在的護甲ID:" + ID);
            return;
        }
        ArmorData armorData = GameDictionary.ArmorDic[ID];
        InitEquipment(armorData);
        BufferID = armorData.BufferID;
    }
}
