using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class GameDictionary
{
    //暫時
    public static Dictionary<string, string> TmpChara1Dic { get; private set; }
    public static Dictionary<string, string> TmpChara2Dic { get; private set; }
    public static Dictionary<string, string> TmpChara3Dic { get; private set; }
    public static Dictionary<string, string> TmpEnemyDic { get; private set; }
    //音樂音效字典
    public static Dictionary<Audios, AudioClip> AudioDic;
    /// <summary>
    /// 設定字典
    /// </summary>
    public static void SetDic()
    {
        LoadJsonDataToDic();
        LoadAudioData();
        TmpChara1Dic = new Dictionary<string, string>();
        TmpChara2Dic = new Dictionary<string, string>();
        TmpChara3Dic = new Dictionary<string, string>();
        TmpEnemyDic = new Dictionary<string, string>();
        TmpChara1Dic.Add("Name", "腳色1");
        TmpChara1Dic.Add("MaxHP", "1050");
        TmpChara1Dic.Add("CurHP", "1050");
        TmpChara1Dic.Add("MaxMind", "680");
        TmpChara1Dic.Add("CurMind", "680");
        TmpChara1Dic.Add("BaseDefense", "40");
        TmpChara1Dic.Add("EquipDefense", "30");
        TmpChara1Dic.Add("EquipDefenseRate", "1");
        TmpChara1Dic.Add("BaseAttack", "60");
        TmpChara1Dic.Add("EquipAttack", "50");
        TmpChara1Dic.Add("SpellList", "21");
        TmpChara1Dic.Add("ActivitySpellList", "0");

        TmpChara2Dic.Add("Name", "腳色2");
        TmpChara2Dic.Add("MaxHP", "1020");
        TmpChara2Dic.Add("CurHP", "1020");
        TmpChara2Dic.Add("MaxMind", "380");
        TmpChara2Dic.Add("CurMind", "380");
        TmpChara2Dic.Add("BaseDefense", "30");
        TmpChara2Dic.Add("EquipDefense", "30");
        TmpChara2Dic.Add("EquipDefenseRate", "1.2");
        TmpChara2Dic.Add("BaseAttack", "40");
        TmpChara2Dic.Add("EquipAttack", "50");
        TmpChara2Dic.Add("SpellList", "0");
        TmpChara2Dic.Add("ActivitySpellList", "0");

        TmpChara3Dic.Add("Name", "腳色3");
        TmpChara3Dic.Add("MaxHP", "1000");
        TmpChara3Dic.Add("CurHP", "1000");
        TmpChara3Dic.Add("MaxMind", "330");
        TmpChara3Dic.Add("CurMind", "330");
        TmpChara3Dic.Add("BaseDefense", "40");
        TmpChara3Dic.Add("EquipDefense", "30");
        TmpChara3Dic.Add("EquipDefenseRate", "1.2");
        TmpChara3Dic.Add("BaseAttack", "50");
        TmpChara3Dic.Add("EquipAttack", "50");
        TmpChara3Dic.Add("SpellList", "0");
        TmpChara3Dic.Add("ActivitySpellList", "0");

        TmpEnemyDic.Add("Name", "大惡魔");
        TmpEnemyDic.Add("MaxHP", "1050");
        TmpEnemyDic.Add("CurHP", "1050");
        TmpEnemyDic.Add("MaxMind", "930");
        TmpEnemyDic.Add("CurMind", "930");
        TmpEnemyDic.Add("BaseDefense", "80");
        TmpEnemyDic.Add("EquipDefense", "50");
        TmpEnemyDic.Add("EquipDefenseRate", "1");
        TmpEnemyDic.Add("BaseAttack", "80");
        TmpEnemyDic.Add("EquipAttack", "150");
        TmpEnemyDic.Add("SpellList", "0");
    }
    static void LoadAudioData()
    {
        AudioDic = new Dictionary<Audios, AudioClip>();
        AudioDic.Add(Audios.Fight, Resources.Load<AudioClip>(string.Format("Audio/WAV/{0}", Audios.Fight)));
        AudioDic.Add(Audios.GoForward, Resources.Load<AudioClip>(string.Format("Audio/WAV/{0}", Audios.GoForward)));
    }
}
