using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Adventure
{
    public AdventureData Data { get; private set; }
    int EventNum { get; set; }
    MilestoneEvent[] EventTypes { get; set; }
    int[] EventWeights { get; set; }
    int EventSumWeight { get; set; }
    int[] EventMiles { get; set; }
    bool[] UnknownEvents { get; set; }//該事件是否為未知事件
    int UnknownWeight { get; set; }//未知出現的權重
    /// <summary>
    /// 初始化冒險
    /// </summary>
    public Adventure(int _adventureID)
    {
        Data = GameDictionary.AdventureDic[_adventureID];
        //共有4種事件類型的權重
        EventWeights = new int[4];
        EventWeights[0] = Data.MonsterWeight;
        EventWeights[1] = Data.InvestigateWeight;
        EventWeights[2] = Data.AccidentWeight;
        EventWeights[3] = Data.CampWeight;
        //計算總權重
        for (int i = 0; i < EventWeights.Length; i++)
        {
            EventSumWeight += EventWeights[i];
        }
        //設定未知事件出現的機率權重
        UnknownWeight = (int)(Data.Unknown * 100);
        //新的冒險
        NewAdventure();
    }
    /// <summary>
    /// 產生新的冒險(從rand一次事件數量)
    /// </summary>
    public void NewAdventure()
    {
        EventNum = Random.Range(Data.MinEvent, Data.MaxEvent);
        //初始化事件數量危亂數事件+1(+1是因為包含起點城鎮)
        EventTypes = new MilestoneEvent[EventNum + 1];
        //初始化事件位於的里程數陣列
        EventMiles = new int[EventNum + 1];
        //初始化未知事件
        UnknownEvents = new bool[EventTypes.Length];
    }
    /// <summary>
    /// 取得符合冒險條件，事件位於的里程數陣列
    /// </summary>
    public int[] GetEventMiles()
    {
        EventMiles[0] = 0;
        int curMile = 0;
        for (byte i = 1; i < EventMiles.Length; i++)
        {
            int randMile = Random.Range(Data.MinEventMile, Data.MaxEventMile);
            curMile += randMile;
            EventMiles[i] += curMile;
        }
        return EventMiles;
    }
    /// <summary>
    /// 取得符合冒險條件的事件陣列
    /// </summary>
    public MilestoneEvent[] GetEventTypes()
    {
        EventTypes[0] = MilestoneEvent.Town;
        int randEventWeight = 0;
        for (int i = 1; i < EventNum + 1; i++)
        {
            randEventWeight = Random.Range(0, EventSumWeight);
            for (int j = 0; j < EventWeights.Length; j++)
            {
                randEventWeight -= EventWeights[j];
                if (randEventWeight < 0)
                {
                    EventTypes[i] = (MilestoneEvent)j;
                    break;
                }
            }
        }
        return EventTypes;
    }
    /// <summary>
    /// 取得未知事件出現的位置
    /// </summary>
    public bool[] GetUnknownEvent()
    {
        //從i=1開始跑，因為第一個事件是起始城鎮不會出現未知
        for (int i = 1; i < UnknownEvents.Length; i++)
        {
            int randWeight = Random.Range(0, 100);
            if (UnknownWeight > randWeight)
                UnknownEvents[i] = true;
        }
        return UnknownEvents;
    }
}
