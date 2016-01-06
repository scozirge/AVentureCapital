using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon : Equipment
{
    public int SpellID { get; protected set; }
    /// <summary>
    /// 初始化武器，傳入武器ID
    /// </summary>
    public Weapon(int _weaponID)
        : base(_weaponID)
    {
        Type = EquipmentTYpe.Weapon;
        if (!GameDictionary.WeaponDic.ContainsKey(ID))
        {
            Debug.LogWarning("不存在的武器ID:" + ID);
            return;
        }
        WeaponData weaponData = GameDictionary.WeaponDic[ID];
        InitEquipment(weaponData);
        SpellID = weaponData.SpellID;
    }
}
