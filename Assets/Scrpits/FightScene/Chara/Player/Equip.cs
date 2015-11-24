using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class PlayerChara : Chara
{
    /// <summary>
    /// 初始化裝備
    /// </summary>
    void InitEquipment()
    {
        InitWeapon();
    }
    /// <summary>
    /// 初始化武器
    /// </summary>
    void InitWeapon()
    {
        string[] weaponStrs = AttrsDic["Weapons"].Split(',');
        if (weaponStrs.Length > 2)
        {
            Debug.LogWarning("裝備超過2把武器");
            return;
        }
        for (int i = 0; i < weaponStrs.Length; i++)
        {
            int weaponID = int.Parse(weaponStrs[i]);
            if (weaponID == 0)
                return;
            Weapon weapon = new Weapon(weaponID);
            EquipWeapon(weapon);
        }
    }
    /// <summary>
    /// 穿上武器
    /// </summary>
    void EquipWeapon(Weapon _weapon)
    {
        //穿上裝備，如果返回false代表無法裝備
        if (!_weapon.Equip())
            return;
        Equip(_weapon);
        SetPassiveSpell(_weapon.SpellID);
    }
    /// <summary>
    /// 穿上裝備
    /// </summary>
    void Equip(Equipment _equipment)
    {
        EquipPAttack += _equipment.PAttack;
        EquipMAttack += _equipment.MAttack;
        EquipPLethalityRate += _equipment.PLethalityRate;
        EquipMLethalityRate += _equipment.MLethalityRate;
        EquipPDefense += _equipment.PDefense;
        EquipMDefense += _equipment.MDefense;
        EquipPResistanceRate += _equipment.PResistanceRate;
        EquipMResistanceRate += _equipment.MResistanceRate;
    }
    /// <summary>
    /// 設定武器的被動施法
    /// </summary>
    void SetPassiveSpell(int _spellID)
    {
        if (_spellID == 0)
            return;
        PassiveSpell spell = new PassiveSpell(_spellID, this);
        PassiveSpellList.Add(spell);
    }
}
