using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class GameDictionary
{
    //施法字典
    public static Dictionary<int, ActivitySpellData> ASpellDic;
    public static Dictionary<int, PassiveSpellData> PSpellDic;
    public static Dictionary<int, DamageData> DamageDic;
    public static Dictionary<int, CureData> CureDic;
    public static Dictionary<int, BufferData> BufferDic;
    //裝備字典
    public static Dictionary<int, WeaponData> WeaponDic;
    public static Dictionary<int, ArmorData> GuardDic;
    public static Dictionary<int, ProtectorData> EquipmentDic;
    /// <summary>
    /// 將Json資料寫入字典裡
    /// </summary>
    static void LoadJsonDataToDic()
    {
        //被動施法
        PSpellDic = new Dictionary<int, PassiveSpellData>();
        PassiveSpellData.SetData(PSpellDic);
        //主動施法
        ASpellDic = new Dictionary<int, ActivitySpellData>();
        ActivitySpellData.SetData(ASpellDic);
        DamageDic = new Dictionary<int, DamageData>();
        DamageData.SetData(DamageDic);
        CureDic = new Dictionary<int, CureData>();
        CureData.SetData(CureDic);
        BufferDic = new Dictionary<int, BufferData>();
        BufferData.SetData(BufferDic);
        //武器
        WeaponDic = new Dictionary<int, WeaponData>();
        WeaponData.SetData(WeaponDic);
        //防具
        GuardDic = new Dictionary<int, ArmorData>();
        ArmorData.SetData(GuardDic);
        //裝備
        EquipmentDic = new Dictionary<int, ProtectorData>();
        ProtectorData.SetData(EquipmentDic);
    }

}
