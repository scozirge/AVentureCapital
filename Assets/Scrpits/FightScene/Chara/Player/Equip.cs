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
        InitArmor();
        InitProtector();
    }
    ////////////////////////////////////////////////////////////////武器/////////////////////////////////////////////////////////
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
        Equip(_weapon, true);//穿上裝備
        AddPassiveSpell(_weapon.SpellID);
    }
    /// <summary>
    /// 新增武器的被動施法
    /// </summary>
    void AddPassiveSpell(int _spellID)
    {
        if (_spellID == 0)
            return;
        PassiveSpell spell = new PassiveSpell(_spellID, this);
        PassiveSpellList.Add(spell);
    }
    /// <summary>
    /// 脫下武器
    /// </summary>
    void TakeOffWeapon(Weapon _weapon)
    {
        //脫下裝備，如果返回false代表無法脫下
        if (!_weapon.TakeOff())
            return;
        Equip(_weapon, false);//脫下裝備
        RemovePassiveSpell(_weapon.ID);
    }
    /// <summary>
    /// 移除武器的被動施法
    /// </summary>
    void RemovePassiveSpell(int _spellID)
    {
        if (_spellID == 0)
            return;
        bool result = false;
        //以迴圈搜尋同此ID的被動施法，並移除
        for (int i = 0; i < PassiveSpellList.Count; i++)
        {
            if (PassiveSpellList[i].ID == _spellID)
            {
                PassiveSpellList.RemoveAt(i);
                break;
            }
        }
        if (!result)
            Debug.LogWarning(string.Format("脫下武器時，找不到要移除的被動施法ID({0})", _spellID));
    }
    ////////////////////////////////////////////////////////////////護甲/////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 初始化護甲
    /// </summary>
    void InitArmor()
    {
        int armorID = int.Parse(AttrsDic["Armor"]);
        if (armorID == 0)
            return;
        Armor armor = new Armor(armorID);
        EquipArmor(armor);
    }
    /// <summary>
    /// 穿上護甲
    /// </summary>
    void EquipArmor(Armor _armor)
    {
        //穿上裝備，如果返回false代表無法裝備
        if (!_armor.Equip())
            return;
        Equip(_armor, true);//穿上裝備
        AddArmorBuffer(_armor.BufferID);
    }
    /// <summary>
    /// 新增護甲的Buffer
    /// </summary>
    void AddArmorBuffer(int _bufferID)
    {
        ReceivePermanentBuffer(new Buffer(_bufferID, this));
    }
    /// <summary>
    /// 脫下護甲
    /// </summary>
    void TakeOffArmor(Armor _armor)
    {
        //穿上裝備，如果返回false代表無法裝備
        if (!_armor.TakeOff())
            return;
        Equip(_armor, false);//脫下裝備
        RemoveArmorBuffer(_armor.BufferID);
    }
    /// <summary>
    /// 新增護甲的Buffer
    /// </summary>
    void RemoveArmorBuffer(int _bufferID)
    {
        if (_bufferID == 0)
            return;
        RemovePermanentBuffer(_bufferID);
    }
    ////////////////////////////////////////////////////////////////防具/////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 初始化防具
    /// </summary>
    void InitProtector()
    {
        string[] protectorsStr = AttrsDic["Protectors"].Split(',');
        for (int i = 0; i < protectorsStr.Length; i++)
        {
            int protectorID = int.Parse(protectorsStr[i]);
            if (protectorID == 0)
                return;
            Protector protector = new Protector(protectorID);
            EquipProtector(protector);
        }
    }
    /// <summary>
    /// 穿上防具
    /// </summary>
    void EquipProtector(Protector _protector)
    {
        //穿上防具，如果返回false代表無法防具
        if (!_protector.Equip())
            return;
        Equip(_protector, true);//穿上防具
    }
    /// <summary>
    /// 脫下防具
    /// </summary>
    void TakeOffProtector(Protector _protector)
    {
        //穿上防具，如果返回false代表無法防具
        if (!_protector.TakeOff())
            return;
        Equip(_protector, false);//脫下防具
    }
    /////////////////////////////////////////////////////////////////////裝備共用///////////////////////////////////////////////////////////
    /// <summary>
    /// 穿上裝備，傳入bool值穿上還是脫下
    /// </summary>
    void Equip(Equipment _equipment, bool _equip)
    {
        sbyte value = 1;
        if (!_equip)
            value = -1;
        EquipConstitution += _equipment.Constitution * value;
        EquipMind += _equipment.Mind * value;
        EquipStrength += _equipment.Strength * value;
        EquipFaith += _equipment.Faith * value;
        EquipAlert += _equipment.Alert * value;
        EquipWill += _equipment.Will * value;
        EquipSkill += _equipment.Skill * value;
        EquipAgile += _equipment.Agile * value;
        EquipPower += _equipment.Power * value;
        EquipPAttack += _equipment.PAttack * value;
        EquipMAttack += _equipment.MAttack * value;
        EquipPLethalityRate += _equipment.PLethalityRate * value;
        EquipMLethalityRate += _equipment.MLethalityRate * value;
        EquipPDefense += _equipment.PDefense * value;
        EquipMDefense += _equipment.MDefense * value;
        EquipPResistanceRate += _equipment.PResistanceRate * value;
        EquipMResistanceRate += _equipment.MResistanceRate * value;
    }
}
