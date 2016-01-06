using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterGetter
{
    /// <summary>
    /// 傳入怪物事件取得怪物ID
    /// </summary>
    public static int[] GetMonsterIDsFromEvent(int _monsterEventID)
    {
        int[] monsterIDs;
        MonsterEventData data = GameDictionary.MonsterEventDic[_monsterEventID];
        if (data.SpecificMonster != null && data.SpecificMonster.Length != 0)
        {
            monsterIDs = data.SpecificMonster;
        }
        else
        {
            int monsterNum = Random.Range(data.MinSpawn, data.MaxSpawn + 1);
            int groupIndex = 0;
            monsterIDs = new int[monsterNum];
            for (int i = 0; i < monsterNum; i++)
            {
                groupIndex = Calculator.WeightIndexGetter(data.Group, data.GroupWeight);
                monsterIDs[i] = GetMonsterIDFromGroup(data.Group[groupIndex]);
            }
        }
        return monsterIDs;
    }
    /// <summary>
    /// 傳入怪物群組ID取得怪物ID
    /// </summary>
    public static int GetMonsterIDFromGroup(int _monsterGroupID)
    {
        int monsterID = 0;
        List<MonsterData> monsterList = GameDictionary.MonsterGroupDic[_monsterGroupID];
        int randIndex = Random.Range(0, monsterList.Count);
        monsterID = monsterList[randIndex].ID;
        return monsterID;
    }
    /// <summary>
    /// 傳入怪物ID取得怪物屬性字典
    /// </summary>
    public static Dictionary<string, string> GetMonsterDic(int _id)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        MonsterData data = GameDictionary.MonsterDic[_id];
        dic.Add("ID", data.ID.ToString());
        dic.Add("Name", data.Name);
        dic.Add("Level", data.Level.ToString());
        dic.Add("MaxHP", data.Health.ToString());
        dic.Add("CurHP", data.Health.ToString());
        dic.Add("PAttack", data.PAttack.ToString());
        dic.Add("PDefense", data.PDefense.ToString());
        dic.Add("SpellList", data.Spells);
        dic.Add("LiftPower", "100");
        return dic;
    }
    /// <summary>
    /// 傳入怪物事件取得怪物字典陣列
    /// </summary>
    public static Dictionary<string, string>[] GetMonsterDicsFromEvent(int _monsterEventID)
    {
        int[] monsterIDs = GetMonsterIDsFromEvent(_monsterEventID);
        Dictionary<string, string>[] _dics = new Dictionary<string, string>[monsterIDs.Length];
        for (int i = 0; i < monsterIDs.Length; i++)
        {
            _dics[i] = GetMonsterDic(monsterIDs[i]);
        }
        return _dics;
    }
}
