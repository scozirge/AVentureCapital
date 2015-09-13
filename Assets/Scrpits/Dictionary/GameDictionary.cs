using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class GameDictionary
{
    public static Dictionary<string, string> TmpChara1Dic { get; private set; }
    public static Dictionary<string, string> TmpChara2Dic { get; private set; }
    public static Dictionary<string, string> TmpChara3Dic { get; private set; }
    public static Dictionary<string, string> TmpEnemyDic { get; private set; }
    public static List<Spell> Chara1ActionList { get; private set; }
    public static List<Spell> Chara2ActionList { get; private set; }
    public static List<Spell> Chara3ActionList { get; private set; }
    public static List<Spell> EnemyActionList { get; private set; }
    /// <summary>
    /// 設定字典
    /// </summary>
    public static void SetDic()
    {
        LoadJsonDataToDic();
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

        Chara1ActionList = new List<Spell>();
        Damage dmg = new Damage("砍殺", ExecuteType.Damage, FightScene.PCharaList[0], 1.3f);
        Dictionary<string, string> bufferDic = new Dictionary<string, string>();
        /*
        ID = int.Parse(_attrDic["BufferID"]);
        TheBufferType = (BufferType)Enum.Parse(typeof(BufferType), _attrDic["Type"], false);
        IsBuff = bool.Parse((_attrDic["IsBuff"]));
        IsDeBuff = bool.Parse((_attrDic["IsDeBuff"]));
        Probability = float.Parse(_attrDic["Probability"]);
        Duration = float.Parse(_attrDic["Duration"]);
        //TriggerDamage
        //TriggerCure
        Circle = float.Parse(_attrDic["Circle"]);
        IniTrigger = bool.Parse((_attrDic["IniTrigger"]));
        Stackable = bool.Parse((_attrDic["Stackable"]));
        MaxStack = int.Parse(_attrDic["MaxStack"]);
        BufferAttackVlaue = int.Parse(_attrDic["BufferAttackValue"]);
        BufferAttackRate = float.Parse(_attrDic["BufferAttackRate"]);
        BufferDefenseVlaue = int.Parse(_attrDic["BufferDefenseValue"]);
        BufferDefenseRate = float.Parse(_attrDic["BufferDefenseRate"]);
        ContributionRate = float.Parse(_attrDic["ContributionRate"]);
         */
        bufferDic.Add("BufferID", "1");
        bufferDic.Add("Type", "PhysicalDamage");
        bufferDic.Add("IsBuff", "True");
        bufferDic.Add("IsDeBuff", "False");
        bufferDic.Add("Probability", "1");
        bufferDic.Add("Duration", "9");
        bufferDic.Add("Circle", "3");
        bufferDic.Add("IniTrigger", "True");
        bufferDic.Add("Stackable", "True");
        bufferDic.Add("MaxStack", "0");
        bufferDic.Add("BufferAttackValue", "50");
        bufferDic.Add("BufferAttackRate", "0.5");
        bufferDic.Add("BufferDefenseValue", "50");
        bufferDic.Add("BufferDefenseRate", "0.5");
        bufferDic.Add("ContributionRate", "0.1");
        Buffer buffer = new Buffer("砍殺", ExecuteType.Buffer, FightScene.PCharaList[0], bufferDic);
        List<ExecuteCom> executeList = new List<ExecuteCom>();
        executeList.Add(dmg);
        executeList.Add(buffer);
        Spell ac = new Spell("砍殺", 2f, executeList, FightScene.PCharaList[0], true);
        Chara1ActionList.Add(ac);

        Chara2ActionList = new List<Spell>();
        Damage dmg2 = new Damage("戳刺", ExecuteType.Damage, FightScene.PCharaList[1], 1f);
        List<ExecuteCom> executeList2 = new List<ExecuteCom>();
        executeList2.Add(dmg2);
        Spell ac2 = new Spell("戳刺", 1f, executeList2, FightScene.PCharaList[1], true);
        Chara2ActionList.Add(ac2);

        Chara3ActionList = new List<Spell>();
        Cure cure3 = new Cure("治癒", ExecuteType.Cure, FightScene.PCharaList[2], 30);
        List<ExecuteCom> executeList3 = new List<ExecuteCom>();
        executeList3.Add(cure3);
        Spell ac3 = new Spell("治癒", 2f, executeList3, FightScene.PCharaList[2], false);
        Chara3ActionList.Add(ac3);

        EnemyActionList = new List<Spell>();
        Damage dmg4 = new Damage("撕咬", ExecuteType.Damage, FightScene.EChara, 1.3f);
        List<ExecuteCom> executeList4 = new List<ExecuteCom>();
        executeList4.Add(dmg4);
        Spell ac4 = new Spell("撕咬", 2.5f, executeList4, FightScene.EChara, true);
        EnemyActionList.Add(ac4);
    }
}
