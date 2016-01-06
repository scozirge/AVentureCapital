using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EventGetter
{
    /// <summary>
    /// 從調查事件群組隨機取得事件
    /// </summary>
    public static InvestigateEventData GetInvestigateInGroup(int _groupID)
    {
        List<InvestigateEventData> list = GameDictionary.InvestigateEventDic[_groupID];
        int rand = Random.Range(0, list.Count);
        return list[rand];
    }
    /// <summary>
    /// 從意外事件群組隨機取得事件
    /// </summary>
    public static AccidentEventData GetAccidentInGroup(int _groupID)
    {
        List<AccidentEventData> list = GameDictionary.AccidentEventDic[_groupID];
        int rand = Random.Range(0, list.Count);
        return list[rand];
    }
    /// <summary>
    /// 從紮營事件群組隨機取得事件
    /// </summary>
    public static CampEventData GetCampInGroup(int _groupID)
    {
        List<CampEventData> list = GameDictionary.CampDic[_groupID];
        int rand = Random.Range(0, list.Count);
        return list[rand];
    }
}
