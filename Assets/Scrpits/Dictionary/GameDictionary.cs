using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDictionary
{
    public static Dictionary<string, string> TmpChara1Dic { get; private set; }
    public static Dictionary<string, string> TmpChara2Dic { get; private set; }
    public static Dictionary<string, string> TmpChara3Dic { get; private set; }
    public static Dictionary<string, string> TmpEnemyDic { get; private set; }
    public static List<Sell> Chara1ActionList { get; private set; }
    public static List<Sell> Chara2ActionList { get; private set; }
    public static List<Sell> Chara3ActionList { get; private set; }
    public static List<Sell> EnemyActionList { get; private set; }
    /// <summary>
    /// 設定字典
    /// </summary>
    public static void SetDic()
    {
        TmpChara1Dic = new Dictionary<string, string>();
        TmpChara2Dic = new Dictionary<string, string>();
        TmpChara3Dic = new Dictionary<string, string>();
        TmpEnemyDic = new Dictionary<string, string>();
        TmpChara1Dic.Add("Name", "腳色1");
        TmpChara1Dic.Add("MaxHP", "520");
        TmpChara1Dic.Add("CurHP", "520");
        TmpChara1Dic.Add("MaxMind", "680");
        TmpChara1Dic.Add("CurMind", "680");
        TmpChara1Dic.Add("BaseDefense", "40");
        TmpChara1Dic.Add("EquipDefense", "30");
        TmpChara1Dic.Add("EquipDefenseRate", "1");
        TmpChara1Dic.Add("BaseAttack", "60");
        TmpChara1Dic.Add("EquipAttack", "50");

        TmpChara2Dic.Add("Name", "腳色2");
        TmpChara2Dic.Add("MaxHP", "420");
        TmpChara2Dic.Add("CurHP", "420");
        TmpChara2Dic.Add("MaxMind", "380");
        TmpChara2Dic.Add("CurMind", "380");
        TmpChara2Dic.Add("BaseDefense", "30");
        TmpChara2Dic.Add("EquipDefense", "30");
        TmpChara2Dic.Add("EquipDefenseRate", "1.2");
        TmpChara2Dic.Add("BaseAttack", "40");
        TmpChara2Dic.Add("EquipAttack", "50");

        TmpChara3Dic.Add("Name", "腳色3");
        TmpChara3Dic.Add("MaxHP", "450");
        TmpChara3Dic.Add("CurHP", "450");
        TmpChara3Dic.Add("MaxMind", "330");
        TmpChara3Dic.Add("CurMind", "330");
        TmpChara3Dic.Add("BaseDefense", "40");
        TmpChara3Dic.Add("EquipDefense", "30");
        TmpChara3Dic.Add("EquipDefenseRate", "1.2");
        TmpChara3Dic.Add("BaseAttack", "50");
        TmpChara3Dic.Add("EquipAttack", "50");

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

        Chara1ActionList = new List<Sell>();
        Damage dmg = new Damage("砍殺", ExecuteType.Damage, FightScene.PCharaList[0], 1.3f);
        List<ExecuteCom> executeList = new List<ExecuteCom>();
        executeList.Add(dmg);
        Sell ac = new Sell("砍殺", 0.2f, executeList, FightScene.PCharaList[0], true);
        Chara1ActionList.Add(ac);

        Chara2ActionList = new List<Sell>();
        Damage dmg2 = new Damage("戳刺", ExecuteType.Damage, FightScene.PCharaList[1], 1f);
        List<ExecuteCom> executeList2 = new List<ExecuteCom>();
        executeList2.Add(dmg2);
        Sell ac2 = new Sell("戳刺", 0.1f, executeList2, FightScene.PCharaList[1], true);
        Chara2ActionList.Add(ac2);

        Chara3ActionList = new List<Sell>();
        Cure cure3 = new Cure("治癒", ExecuteType.Cure, FightScene.PCharaList[2], 30);
        List<ExecuteCom> executeList3 = new List<ExecuteCom>();
        executeList3.Add(cure3);
        Sell ac3 = new Sell("治癒", 0.2f, executeList3, FightScene.PCharaList[2], false);
        Chara3ActionList.Add(ac3);

        EnemyActionList = new List<Sell>();
        Damage dmg4 = new Damage("撕咬", ExecuteType.Damage, FightScene.EChara, 1.3f);
        List<ExecuteCom> executeList4 = new List<ExecuteCom>();
        executeList4.Add(dmg4);
        Sell ac4 = new Sell("撕咬", 0.25f, executeList4, FightScene.EChara, true);
        EnemyActionList.Add(ac4);
    }
}
