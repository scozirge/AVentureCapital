using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class GameDictionary
{
    //施法字典
    public static Dictionary<int, ActivitySpellData> ASpellDic;
    public static Dictionary<int, SpellData> SpellDic;
    public static Dictionary<int, DamageData> DamageDic;
    public static Dictionary<int, CureData> CureDic;
    public static Dictionary<int, BufferData> BufferDic;
    /// <summary>
    /// 將Json資料寫入字典裡
    /// </summary>
    static void LoadJsonDataToDic()
    {
        //施法
        SpellDic = new Dictionary<int, SpellData>();
        SpellData.SetData(SpellDic);
        ASpellDic = new Dictionary<int, ActivitySpellData>();
        ActivitySpellData.SetData(ASpellDic);
        DamageDic = new Dictionary<int, DamageData>();
        DamageData.SetData(DamageDic);
        CureDic = new Dictionary<int, CureData>();
        CureData.SetData(CureDic);
        BufferDic = new Dictionary<int, BufferData>();
        BufferData.SetData(BufferDic);
    }

}
