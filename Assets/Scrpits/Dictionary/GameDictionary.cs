using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDictionary
{
    public static Dictionary<string, string> TmpChara1Dic { get; private set; }
    public static Dictionary<string, string> TmpChara2Dic { get; private set; }
    public static Dictionary<string, string> TmpChara3Dic { get; private set; }
    public static Dictionary<string, string> TmpEnemyDic { get; private set; }
    public static List<Action> Chara1ActionList { get; private set; }
    public static List<Action> Chara2ActionList { get; private set; }
    public static List<Action> Chara3ActionList { get; private set; }
    public static List<Action> EnemyActionList { get; private set; }
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
        TmpChara1Dic.Add("EquipDefenseOdds", "1.1");
        TmpChara1Dic.Add("BaseAttack", "60");
        TmpChara1Dic.Add("EquipAttack", "50");

        TmpChara2Dic.Add("Name", "腳色2");
        TmpChara2Dic.Add("MaxHP", "420");
        TmpChara2Dic.Add("CurHP", "420");
        TmpChara2Dic.Add("MaxMind", "380");
        TmpChara2Dic.Add("CurMind", "380");
        TmpChara2Dic.Add("BaseDefense", "30");
        TmpChara2Dic.Add("EquipDefense", "30");
        TmpChara2Dic.Add("EquipDefenseOdds", "1.2");
        TmpChara2Dic.Add("BaseAttack", "40");
        TmpChara2Dic.Add("EquipAttack", "50");

        TmpChara3Dic.Add("Name", "腳色3");
        TmpChara3Dic.Add("MaxHP", "450");
        TmpChara3Dic.Add("CurHP", "450");
        TmpChara3Dic.Add("MaxMind", "330");
        TmpChara3Dic.Add("CurMind", "330");
        TmpChara3Dic.Add("BaseDefense", "40");
        TmpChara3Dic.Add("EquipDefense", "30");
        TmpChara3Dic.Add("EquipDefenseOdds", "1.2");
        TmpChara3Dic.Add("BaseAttack", "50");
        TmpChara3Dic.Add("EquipAttack", "50");

        TmpEnemyDic.Add("Name", "大惡魔");
        TmpEnemyDic.Add("MaxHP", "1050");
        TmpEnemyDic.Add("CurHP", "1050");
        TmpEnemyDic.Add("MaxMind", "930");
        TmpEnemyDic.Add("CurMind", "930");
        TmpEnemyDic.Add("BaseDefense", "80");
        TmpEnemyDic.Add("EquipDefense", "50");
        TmpEnemyDic.Add("EquipDefenseOdds", "1");
        TmpEnemyDic.Add("BaseAttack", "80");
        TmpEnemyDic.Add("EquipAttack", "150");

        Chara1ActionList = new List<Action>();
        Damage dmg = new Damage(ExecuteType.Damage, 1.3f);
        List<ExecuteCom> executeList = new List<ExecuteCom>();
        executeList.Add(dmg);
        Action ac = new Action("砍殺", 0.3f, executeList, FightScene.PCharaList[0], true);
        Chara1ActionList.Add(ac);

        Chara2ActionList = new List<Action>();
        Damage dmg2 = new Damage(ExecuteType.Damage, 1f);
        List<ExecuteCom> executeList2 = new List<ExecuteCom>();
        executeList2.Add(dmg2);
        Action ac2 = new Action("戳刺", 0.2f, executeList2, FightScene.PCharaList[1], true);
        Chara2ActionList.Add(ac2);

        Chara3ActionList = new List<Action>();
        Cure cure3 = new Cure(ExecuteType.Cure, 30);
        List<ExecuteCom> executeList3 = new List<ExecuteCom>();
        executeList3.Add(cure3);
        Action ac3 = new Action("治癒", 0.3f, executeList3, FightScene.PCharaList[2], false);
        Chara3ActionList.Add(ac3);

        EnemyActionList = new List<Action>();
        Damage dmg4 = new Damage(ExecuteType.Damage, 1.3f);
        List<ExecuteCom> executeList4 = new List<ExecuteCom>();
        executeList4.Add(dmg4);
        Action ac4 = new Action("撕咬", 0.4f, executeList4, FightScene.EChara, true);
        EnemyActionList.Add(ac4);
    }
}
