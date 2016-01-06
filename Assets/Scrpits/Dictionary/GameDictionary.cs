using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public partial class GameDictionary
{
    //暫時
    public static Dictionary<string, string> TmpChara1Dic { get; private set; }
    public static Dictionary<string, string> TmpChara2Dic { get; private set; }
    public static Dictionary<string, string> TmpChara3Dic { get; private set; }
    public static Dictionary<string, string> TmpEnemy1Dic { get; private set; }
    public static Dictionary<string, string> TmpEnemy2Dic { get; private set; }
    public static Dictionary<string, string> TmpEnemy3Dic { get; private set; }
    //音樂音效字典
    public static Dictionary<Audios, AudioClip> AudioDic;
    //施法類型顏色字典
    public static Dictionary<SpellType, Color32> SpellColorDic;
    /// <summary>
    /// 設定字典
    /// </summary>
    public static void InitDic()
    {
        //將Json資料寫入字典裡
        LoadJsonDataToDic();
        //設定音源字典
        SetAudioDic();
        //設定施法顏色字典
        SetSpellColorDic();
        TmpChara1Dic = new Dictionary<string, string>();
        TmpChara2Dic = new Dictionary<string, string>();
        TmpChara3Dic = new Dictionary<string, string>();
        TmpEnemy1Dic = new Dictionary<string, string>();
        TmpEnemy2Dic = new Dictionary<string, string>();
        TmpEnemy3Dic = new Dictionary<string, string>();
        TmpChara1Dic.Add("ID", "1");
        TmpChara1Dic.Add("Role", "1");
        TmpChara1Dic.Add("Level", "1");
        TmpChara1Dic.Add("Exp", "30");
        TmpChara1Dic.Add("Constitution", "10");
        TmpChara1Dic.Add("Mind", "10");
        TmpChara1Dic.Add("Strength", "13");
        TmpChara1Dic.Add("Faith", "10");
        TmpChara1Dic.Add("Alert", "10");
        TmpChara1Dic.Add("Will", "10");
        TmpChara1Dic.Add("Skill", "10");
        TmpChara1Dic.Add("Agility", "10");
        TmpChara1Dic.Add("Point", "3");
        TmpChara1Dic.Add("CurHP", "100");
        TmpChara1Dic.Add("CurVP", "30");
        TmpChara1Dic.Add("Talent", "1");
        TmpChara1Dic.Add("Weapon", "1,11");
        TmpChara1Dic.Add("Armor", "100000001");
        TmpChara1Dic.Add("Protector", "200000001,200000011,200000021,200000031");


        TmpChara2Dic.Add("ID", "1");
        TmpChara2Dic.Add("Role", "2");
        TmpChara2Dic.Add("Level", "1");
        TmpChara2Dic.Add("Exp", "50");
        TmpChara2Dic.Add("Constitution", "10");
        TmpChara2Dic.Add("Mind", "10");
        TmpChara2Dic.Add("Strength", "13");
        TmpChara2Dic.Add("Faith", "10");
        TmpChara2Dic.Add("Alert", "10");
        TmpChara2Dic.Add("Will", "10");
        TmpChara2Dic.Add("Skill", "10");
        TmpChara2Dic.Add("Agility", "10");
        TmpChara2Dic.Add("Point", "3");
        TmpChara2Dic.Add("CurHP", "100");
        TmpChara2Dic.Add("CurVP", "30");
        TmpChara2Dic.Add("Talent", "1");
        TmpChara2Dic.Add("Weapon", "1,11");
        TmpChara2Dic.Add("Armor", "100000001");
        TmpChara2Dic.Add("Protector", "200000001,200000011,200000021,200000031");

        TmpChara3Dic.Add("ID", "3");
        TmpChara3Dic.Add("Name", "腳色3");
        TmpChara3Dic.Add("Strength", "10");
        TmpChara3Dic.Add("Agility", "20");
        TmpChara3Dic.Add("MaxHP", "500");
        TmpChara3Dic.Add("CurHP", "500");
        TmpChara3Dic.Add("MaxVP", "50");
        TmpChara3Dic.Add("CurVP", "50");
        TmpChara3Dic.Add("PDefense", "40");
        TmpChara3Dic.Add("EquipDefense", "30");
        TmpChara3Dic.Add("EquipDefenseRate", "1.2");
        TmpChara3Dic.Add("PAttack", "50");
        TmpChara3Dic.Add("EquipAttack", "50");
        TmpChara3Dic.Add("Weapons", "21");
        TmpChara3Dic.Add("Armor", "0");
        TmpChara3Dic.Add("Protectors", "0");
        TmpChara3Dic.Add("ActivitySpellList", "21");
        TmpChara3Dic.Add("LiftPower", "100");
        TmpChara3Dic.Add("Weight", "60");

        TmpEnemy1Dic.Add("ID", "4");
        TmpEnemy1Dic.Add("Name", "大惡魔A");
        TmpEnemy1Dic.Add("MaxHP", "100");
        TmpEnemy1Dic.Add("CurHP", "100");
        TmpEnemy1Dic.Add("MaxVP", "200");
        TmpEnemy1Dic.Add("CurVP", "200");
        TmpEnemy1Dic.Add("PDefense", "80");
        TmpEnemy1Dic.Add("EquipDefense", "50");
        TmpEnemy1Dic.Add("EquipDefenseRate", "1");
        TmpEnemy1Dic.Add("PAttack", "80");
        TmpEnemy1Dic.Add("EquipAttack", "50");
        TmpEnemy1Dic.Add("SpellList", "1,21");
        TmpEnemy1Dic.Add("LiftPower", "100");
        TmpEnemy1Dic.Add("Weight", "20");

        TmpEnemy2Dic.Add("ID", "5");
        TmpEnemy2Dic.Add("Name", "大惡魔B");
        TmpEnemy2Dic.Add("MaxHP", "50");
        TmpEnemy2Dic.Add("CurHP", "50");
        TmpEnemy2Dic.Add("MaxVP", "280");
        TmpEnemy2Dic.Add("CurVP", "280");
        TmpEnemy2Dic.Add("PDefense", "80");
        TmpEnemy2Dic.Add("EquipDefense", "50");
        TmpEnemy2Dic.Add("EquipDefenseRate", "1");
        TmpEnemy2Dic.Add("PAttack", "80");
        TmpEnemy2Dic.Add("EquipAttack", "150");
        TmpEnemy2Dic.Add("SpellList", "1");
        TmpEnemy2Dic.Add("LiftPower", "100");
        TmpEnemy2Dic.Add("Weight", "30");

        TmpEnemy3Dic.Add("ID", "6");
        TmpEnemy3Dic.Add("Name", "大惡魔C");
        TmpEnemy3Dic.Add("MaxHP", "70");
        TmpEnemy3Dic.Add("CurHP", "70");
        TmpEnemy3Dic.Add("MaxVP", "380");
        TmpEnemy3Dic.Add("CurVP", "380");
        TmpEnemy3Dic.Add("PDefense", "80");
        TmpEnemy3Dic.Add("EquipDefense", "50");
        TmpEnemy3Dic.Add("EquipDefenseRate", "1");
        TmpEnemy3Dic.Add("PAttack", "80");
        TmpEnemy3Dic.Add("EquipAttack", "150");
        TmpEnemy3Dic.Add("SpellList", "11");
        TmpEnemy3Dic.Add("LiftPower", "100");
        TmpEnemy3Dic.Add("Weight", "70");
    }
    /// <summary>
    /// 設定音源字典
    /// </summary>
    static void SetAudioDic()
    {
        AudioDic = new Dictionary<Audios, AudioClip>();
        AudioDic.Add(Audios.Fight, Resources.Load<AudioClip>(string.Format("Audio/WAV/{0}", Audios.Fight)));
        AudioDic.Add(Audios.GoForward, Resources.Load<AudioClip>(string.Format("Audio/WAV/{0}", Audios.GoForward)));
    }
    /// <summary>
    /// 設定施法顏色字典
    /// </summary>
    static void SetSpellColorDic()
    {
        SpellColorDic = new Dictionary<SpellType, Color32>();
        SpellColorDic.Add(SpellType.Attack, new Color32(168, 91, 91, 255));
        SpellColorDic.Add(SpellType.Buffer, new Color32(117, 177, 103, 255));
        SpellColorDic.Add(SpellType.DeBuffer, new Color32(164, 120, 167, 255));
    }
}
