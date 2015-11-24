using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public static void SetDic()
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
        TmpChara1Dic.Add("Name", "腳色1");
        TmpChara1Dic.Add("MaxHP", "1050");
        TmpChara1Dic.Add("CurHP", "1050");
        TmpChara1Dic.Add("MaxVP", "20");
        TmpChara1Dic.Add("CurVP", "20");
        TmpChara1Dic.Add("BaseDefense", "40");
        TmpChara1Dic.Add("EquipDefense", "30");
        TmpChara1Dic.Add("EquipDefenseRate", "1");
        TmpChara1Dic.Add("BaseAttack", "60");
        TmpChara1Dic.Add("EquipAttack", "50");
        TmpChara1Dic.Add("Weapons", "11");
        TmpChara1Dic.Add("ActivitySpellList", "1");
        TmpChara1Dic.Add("LiftPower", "100");
        TmpChara1Dic.Add("Weight", "100");

        TmpChara2Dic.Add("ID", "2");
        TmpChara2Dic.Add("Name", "腳色2");
        TmpChara2Dic.Add("MaxHP", "1020");
        TmpChara2Dic.Add("CurHP", "1020");
        TmpChara2Dic.Add("MaxVP", "20");
        TmpChara2Dic.Add("CurVP", "20");
        TmpChara2Dic.Add("BaseDefense", "30");
        TmpChara2Dic.Add("EquipDefense", "30");
        TmpChara2Dic.Add("EquipDefenseRate", "1.2");
        TmpChara2Dic.Add("BaseAttack", "40");
        TmpChara2Dic.Add("EquipAttack", "50");
        TmpChara2Dic.Add("Weapons", "0");
        TmpChara2Dic.Add("ActivitySpellList", "11,11");
        TmpChara2Dic.Add("LiftPower", "100");
        TmpChara2Dic.Add("Weight", "30");

        TmpChara3Dic.Add("ID", "3");
        TmpChara3Dic.Add("Name", "腳色3");
        TmpChara3Dic.Add("MaxHP", "1000");
        TmpChara3Dic.Add("CurHP", "1000");
        TmpChara3Dic.Add("MaxVP", "20");
        TmpChara3Dic.Add("CurVP", "20");
        TmpChara3Dic.Add("BaseDefense", "40");
        TmpChara3Dic.Add("EquipDefense", "30");
        TmpChara3Dic.Add("EquipDefenseRate", "1.2");
        TmpChara3Dic.Add("BaseAttack", "50");
        TmpChara3Dic.Add("EquipAttack", "50");
        TmpChara3Dic.Add("Weapons", "0");
        TmpChara3Dic.Add("ActivitySpellList", "21");
        TmpChara3Dic.Add("LiftPower", "100");
        TmpChara3Dic.Add("Weight", "60");

        TmpEnemy1Dic.Add("ID", "4");
        TmpEnemy1Dic.Add("Name", "大惡魔A");
        TmpEnemy1Dic.Add("MaxHP", "1050");
        TmpEnemy1Dic.Add("CurHP", "1050");
        TmpEnemy1Dic.Add("MaxVP", "680");
        TmpEnemy1Dic.Add("CurVP", "680");
        TmpEnemy1Dic.Add("BaseDefense", "80");
        TmpEnemy1Dic.Add("EquipDefense", "50");
        TmpEnemy1Dic.Add("EquipDefenseRate", "1");
        TmpEnemy1Dic.Add("BaseAttack", "80");
        TmpEnemy1Dic.Add("EquipAttack", "150");
        TmpEnemy1Dic.Add("SpellList", "1,21");
        TmpEnemy1Dic.Add("LiftPower", "100");
        TmpEnemy1Dic.Add("Weight", "20");

        TmpEnemy2Dic.Add("ID", "5");
        TmpEnemy2Dic.Add("Name", "大惡魔B");
        TmpEnemy2Dic.Add("MaxHP", "1050");
        TmpEnemy2Dic.Add("CurHP", "1050");
        TmpEnemy2Dic.Add("MaxVP", "680");
        TmpEnemy2Dic.Add("CurVP", "680");
        TmpEnemy2Dic.Add("BaseDefense", "80");
        TmpEnemy2Dic.Add("EquipDefense", "50");
        TmpEnemy2Dic.Add("EquipDefenseRate", "1");
        TmpEnemy2Dic.Add("BaseAttack", "80");
        TmpEnemy2Dic.Add("EquipAttack", "150");
        TmpEnemy2Dic.Add("SpellList", "1");
        TmpEnemy2Dic.Add("LiftPower", "100");
        TmpEnemy2Dic.Add("Weight", "30");

        TmpEnemy3Dic.Add("ID", "6");
        TmpEnemy3Dic.Add("Name", "大惡魔C");
        TmpEnemy3Dic.Add("MaxHP", "1050");
        TmpEnemy3Dic.Add("CurHP", "1050");
        TmpEnemy3Dic.Add("MaxVP", "680");
        TmpEnemy3Dic.Add("CurVP", "680");
        TmpEnemy3Dic.Add("BaseDefense", "80");
        TmpEnemy3Dic.Add("EquipDefense", "50");
        TmpEnemy3Dic.Add("EquipDefenseRate", "1");
        TmpEnemy3Dic.Add("BaseAttack", "80");
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
