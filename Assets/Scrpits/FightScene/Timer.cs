using UnityEngine;
using System.Collections;

public partial class FightScene
{
    //戰鬥每個影格單位時間
    const float TimeUnit = 1;
    //戰鬥一輪的單位時間
    const float FightTimeRoundUnits = 0.1f;
    //戰鬥計時器
    static float FightTimer;
    //冒險每個影格單位時間
    const float AdventureTimeUnit = 1;
    //冒險一輪的單位時間
    const float AdventureRoundUnits = 5;
    //冒險計時器
    static float AdventureTimer;
    
    /// <summary>
    /// 起始設定計時器
    /// </summary>
    static void SetTimer()
    {
        FightTimer = FightTimeRoundUnits;
        Fight = false;
        AdventureTimer = AdventureRoundUnits;
        Adventure = false;
    }
    /// <summary>
    /// 計時一個單位時間是否到達
    /// </summary>
    static bool CheckFightTimeUnit()
    {
        bool executeRound = false;
        if(FightTimer>0)
        {
            FightTimer -= TimeUnit * Time.deltaTime;
        }
        else
        {
            executeRound = true;
            FightTimer = FightTimeRoundUnits;
        }
        return executeRound;
    }
    /// <summary>
    /// 冒險計時器，倒數幾秒時間到遇到怪物或寶箱
    /// </summary>
    static void CheckAdventureTimeUnit()
    {
        if (AdventureTimer > 0)
        {
            AdventureTimer -= AdventureTimeUnit * Time.deltaTime;
        }
        else
        {
            AdventureTimer = AdventureRoundUnits;
            //遭遇敵方
            MeetEnemy();
        }
    }
}
