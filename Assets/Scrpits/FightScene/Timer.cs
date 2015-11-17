using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class FightScene
{
    //是否開始戰鬥
    public static bool Fight;
    static bool Action;//戰鬥中是否有人在執行動作，如果有，則暫停計時器以免多人同時進行動作
    static List<Chara> ActionCharaList;//腳色準備動作的清單    
    static List<int> DontPassSpellTimeCharaIDList;//不執行施法時間流逝的清單
    //戰鬥每個影格單位時間
    const float TimeUnit = 1;
    //戰鬥一刻的時間
    const float FightTimeRoundUnits = 0.1f;
    //戰鬥計時器
    static float FightTimer;
    //冒險每個影格單位時間
    const float AdventureTimeUnit = 1;
    //冒險一刻的時間
    const float AdventureRoundUnits = 0.1f;
    //冒險里程碑間隔幾刻
    const byte MilestoneTime = 30;
    //目前行徑的里程
    byte CurMiles;
    //冒險計時器
    static float AdventureTimer;

    /// <summary>
    /// 起始設定計時器
    /// </summary>
    static void SetTimer()
    {
        FightTimer = FightTimeRoundUnits;
        Fight = false;
        ActionCharaList = new List<Chara>();
        DontPassSpellTimeCharaIDList = new List<int>();
        AdventureTimer = AdventureRoundUnits;
        Adventure = false;
    }
    /// <summary>
    /// 計時一個單位時間是否到達
    /// </summary>
    static bool CheckFightTimeUnit()
    {
        bool executeRound = false;
        if (FightTimer > 0)
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
    static bool CheckAdventureTimeUnit()
    {
        bool executeRound = false;
        if (AdventureTimer > 0)
        {
            AdventureTimer -= AdventureTimeUnit * Time.deltaTime;
        }
        else
        {
            executeRound = true;
            AdventureTimer = AdventureRoundUnits;
        }
        return executeRound;
    }
    /// <summary>
    /// 設定是否執行動作，執行動作中會暫停計時器以免多人同時進行動作
    /// </summary>
    public static void SetAction(bool _action)
    {
        Action = _action;
    }
    void Update()
    {
        //StartFight=true時才啟動戰鬥計時器
        if (Fight)
            FightTimeProgress();
        //StartAdventrue為true時才啟動冒險計時器
        if (Adventure)
            AdvantureTimeProgress();
    }
    /// <summary>
    /// 冒險時間排成處理
    /// </summary>
    void AdvantureTimeProgress()
    {
        if(CheckAdventureTimeUnit())
        {
            //執行主動施法時間流逝
            PassCharaActivitySpellTime();
            //里程數增加
            CurMiles++;
            if (CurMiles>=MilestoneTime)
            {
                CurMiles = 0;
                MeetEnemy();
            }
        }        
    }
    /// <summary>
    /// 戰鬥時間排成處理
    /// </summary>
    void FightTimeProgress()
    {
        //檢查一單位時間是否到了，時間到就檢查所有腳色的TimePass
        if (CheckFightTimeUnit())
        {
            //執行主動施法時間流逝
            PassCharaActivitySpellTime();
            //有人在執行動作則暫停計時狀態時間流逝與被動施法時間流逝以避免多人同時進行動作
            if (Action)
                return;
            //如果沒有腳色正準備施法，就進行狀態時間流逝
            if (ActionCharaList.Count == 0)
            {
                DontPassSpellTimeCharaIDList.Clear();
                //腳色狀態時間流逝
                PassStatus();
            }
            //將準備施法的腳色加到到清單中
            CheckCharaAction();
            //如果ActionCharaList.Count大於1代表有多個腳色同時進行施法
            if (ActionCharaList.Count > 1)
            {
                //如果同時有多個準備行動的腳色，就對清單進行排序
                SortReadyChara();
                //排序第一的腳色先進行施法時間流逝，並傳回是否為多次施法，若不是才結束此腳色的施法
                if (!ActionCharaList[0].SpellTimePass())
                {
                    //因為此腳色已執行過施法時間流逝，所以加入不執行清單
                    DontPassSpellTimeCharaIDList.Add(ActionCharaList[0].ID);
                    //已執行過施法所以從清單中移除
                    ActionCharaList.RemoveAt(0);
                }
            }
            else
            {
                //腳色施法時間流逝
                PassCharaSpellTime();
                //已執行過施法所以從清單中移除
                if (ActionCharaList.Count > 0)
                    ActionCharaList.RemoveAt(0);
            }
        }
    }
    /// <summary>
    /// 腳色狀態時間流逝
    /// </summary>
    void PassStatus()
    {
        for (int i = 0; i < PAliveCharaList.Count; i++)
        {
            //狀態時間流逝
            PAliveCharaList[i].BufferTimePass();
        }
        for (int i = 0; i < EAliveCharaList.Count; i++)
        {
            //狀態時間流逝
            EAliveCharaList[i].BufferTimePass();
        }
    }
    /// <summary>
    /// 將準備施法的腳色加到到清單中
    /// </summary>
    void CheckCharaAction()
    {
        ActionCharaList.Clear();
        for (int i = 0; i < PAliveCharaList.Count; i++)
        {
            //如果此腳色可以施法，則加入準備施法清單(此項一定要在狀態時間流逝之後，否則可能發生被判斷為可施法，卻因為狀態流逝導致施法延誤)
            if (PAliveCharaList[i].SpellCheck())
            {
                ActionCharaList.Add(PAliveCharaList[i]);//加入腳色準備行動清單
            }
        }
        for (int i = 0; i < EAliveCharaList.Count; i++)
        {
            //如果此腳色可以施法，則加入準備施法清單(此項一定要在狀態時間流逝之後，否則可能發生被判斷為可施法，卻因為狀態流逝導致施法延誤)
            if (EAliveCharaList[i].SpellCheck())
            {
                ActionCharaList.Add(EAliveCharaList[i]);//加入腳色準備行動清單
            }
        }
    }
    /// <summary>
    /// 對準備行動的角色依照負重百分比進行排序
    /// </summary>
    void SortReadyChara()
    {
        ActionCharaList.Sort((x, y) => { return x.WeightRatio.CompareTo(y.WeightRatio); });
    }
    /// <summary>
    /// 腳色施法時間流逝
    /// </summary>
    void PassCharaSpellTime()
    {
        for (int i = 0; i < PAliveCharaList.Count; i++)
        {
            if (!DontPassSpellTimeCharaIDList.Contains(PAliveCharaList[i].ID))
            {
                //施法時間流逝
                PAliveCharaList[i].SpellTimePass();
                //因為此腳色已執行過施法時間流逝，所以加入不執行清單
                DontPassSpellTimeCharaIDList.Add(PAliveCharaList[i].ID);
            }
        }
        for (int i = 0; i < EAliveCharaList.Count; i++)
        {
            if (!DontPassSpellTimeCharaIDList.Contains(EAliveCharaList[i].ID))
            {
                //施法時間流逝
                EAliveCharaList[i].SpellTimePass();
                //因為此腳色已執行過施法時間流逝，所以加入不執行清單
                DontPassSpellTimeCharaIDList.Add(EAliveCharaList[i].ID);
            }
        }
    }
    /// <summary>
    /// 腳色主動施法時間流逝
    /// </summary>
    void PassCharaActivitySpellTime()
    {
        for (int i = 0; i < PAliveCharaList.Count; i++)
        {
            PAliveCharaList[i].ActivitySpellTimePass();
        }
    }
}
