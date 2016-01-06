using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class MainChara
{
    /// <summary>
    /// 起始設定
    /// </summary>
    public MainChara(byte _index, Dictionary<string, string> _attrsDic)
    {
        AttrsDic = _attrsDic;
        Index = _index;
        ID = int.Parse(AttrsDic["ID"]);
        Role = GameDictionary.RoleDic[int.Parse(AttrsDic["Role"])];
        Level = int.Parse(AttrsDic["Level"]);
        CurExp = int.Parse(AttrsDic["Exp"]);
        Point = int.Parse(AttrsDic["Point"]);
        GrowConstitution = int.Parse(AttrsDic["Constitution"]);
        GrowStrength = int.Parse(AttrsDic["Strength"]);
        GrowMind = int.Parse(AttrsDic["Mind"]);
        GrowFaith = int.Parse(AttrsDic["Faith"]);
        GrowAlert = int.Parse(AttrsDic["Alert"]);
        GrowWill = int.Parse(AttrsDic["Will"]);
        GrowSkill = int.Parse(AttrsDic["Skill"]);
        GrowAgility = int.Parse(AttrsDic["Agility"]);
        //狀態
        CurHealth = int.Parse(AttrsDic["CurHP"]);
        CurVitality = int.Parse(AttrsDic["CurVP"]);
        //天賦
        MyTalent = GameDictionary.TalentDic[int.Parse(AttrsDic["Talent"])];
        //武器
        MyWeapons = new WeaponData[2];
        int[] weaponIDs = TextManager.StringSplitToIntArray(AttrsDic["Weapon"], ',');
        for (int i = 0; i < MyWeapons.Length; i++)
        {
            if (i < weaponIDs.Length)
                MyWeapons[i] = GameDictionary.WeaponDic[weaponIDs[i]];
            else
                MyWeapons[i] = null;
        }
        //主防具
        MyArmor = GameDictionary.ArmorDic[int.Parse(AttrsDic["Armor"])];
        //副防具
        MyProtectors = new ProtectorData[4];
        int[] ProtectorIDs = TextManager.StringSplitToIntArray(AttrsDic["Protector"], ',');
        for (int i = 0; i < MyProtectors.Length; i++)
        {
            if (i < ProtectorIDs.Length)
                MyProtectors[i] = GameDictionary.ProtectorDic[ProtectorIDs[i]];
            else
                MyProtectors[i] = null;
        }
    }
}
