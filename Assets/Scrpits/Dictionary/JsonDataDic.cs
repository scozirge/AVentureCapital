using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class GameDictionary
{
    //文字字典
    public static Dictionary<string, String_AttributeData> String_AttributeDic;
    //Sprite字典
    public static Dictionary<string, SpriteData> SpriteDic;
    //施法字典
    public static Dictionary<int, ActivitySpellData> ASpellDic;
    public static Dictionary<int, PassiveSpellData> PSpellDic;
    public static Dictionary<int, DamageData> DamageDic;
    public static Dictionary<int, CureData> CureDic;
    public static Dictionary<int, BufferData> BufferDic;
    //天賦字典
    public static Dictionary<int, TalentData> TalentDic;
    //裝備字典
    public static Dictionary<int, WeaponData> WeaponDic;
    public static Dictionary<int, ArmorData> ArmorDic;
    public static Dictionary<int, ProtectorData> ProtectorDic;
    //掉落字典
    public static Dictionary<int, DropData> DropDic;
    //冒險字典
    public static Dictionary<int, AdventureData> AdventureDic;
    public static Dictionary<int, MonsterEventData> MonsterEventDic;
    public static Dictionary<int, List<InvestigateEventData>> InvestigateEventDic;
    public static Dictionary<int, List<AccidentEventData>> AccidentEventDic;
    public static Dictionary<int, EventResultData> EventResultDic;
    public static Dictionary<int, List<CampEventData>> CampDic;
    //怪物字典
    public static Dictionary<int, MonsterData> MonsterDic;
    public static Dictionary<int, List<MonsterData>> MonsterGroupDic;
    //腳色字典
    public static Dictionary<int, RoleData> RoleDic;
    //主屬性字典
    public static Dictionary<MainAttribute, MainAttributeData> MainAttributeDic;
    //等級字典
    public static Dictionary<int, LevelData> LevelDic;
    /// <summary>
    /// 將Json資料寫入字典裡
    /// </summary>
    static void LoadJsonDataToDic()
    {
        //文字字典
        String_AttributeDic = new Dictionary<string, String_AttributeData>();
        String_AttributeData.SetData(String_AttributeDic);
        //Sprite字典
        SpriteDic = new Dictionary<string, SpriteData>();
        SpriteData.SetData(SpriteDic);
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
        //天賦字典
        TalentDic = new Dictionary<int, TalentData>();
        TalentData.SetData(TalentDic);
        //武器
        WeaponDic = new Dictionary<int, WeaponData>();
        WeaponData.SetData(WeaponDic);
        //防具
        ArmorDic = new Dictionary<int, ArmorData>();
        ArmorData.SetData(ArmorDic);
        //裝備
        ProtectorDic = new Dictionary<int, ProtectorData>();
        ProtectorData.SetData(ProtectorDic);
        //裝備
        DropDic = new Dictionary<int, DropData>();
        DropData.SetData(DropDic);
        //冒險
        AdventureDic = new Dictionary<int, AdventureData>();
        AdventureData.SetData(AdventureDic);
        //出怪事件
        MonsterEventDic = new Dictionary<int, MonsterEventData>();
        MonsterEventData.SetData(MonsterEventDic);
        //調查事件
        InvestigateEventDic = new Dictionary<int, List<InvestigateEventData>>();
        InvestigateEventData.SetData(InvestigateEventDic);
        //意外事件
        AccidentEventDic = new Dictionary<int, List<AccidentEventData>>();
        AccidentEventData.SetData(AccidentEventDic);
        //結果事件
        EventResultDic = new Dictionary<int, EventResultData>();
        EventResultData.SetData(EventResultDic);
        //紮營事件
        CampDic = new Dictionary<int, List<CampEventData>>();
        CampEventData.SetData(CampDic);
        //怪物
        MonsterGroupDic = new Dictionary<int, List<MonsterData>>();
        MonsterDic = new Dictionary<int, MonsterData>();
        MonsterData.SetData(MonsterGroupDic, MonsterDic);
        //腳色字典
        RoleDic = new Dictionary<int, RoleData>();
        RoleData.SetData(RoleDic);
        //主屬性字典
        MainAttributeDic = new Dictionary<MainAttribute, MainAttributeData>();
        MainAttributeData.SetData(MainAttributeDic);
        //等級字典
        LevelDic = new Dictionary<int, LevelData>();
        LevelData.SetData(LevelDic);
    }
}
