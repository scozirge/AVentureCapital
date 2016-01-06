using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class FightScene
{
    static Animator Ani_BG;
    /// <summary>
    /// 起始設定Scene
    /// </summary>
    static void IniScene()
    {
        Ani_BG = MyTransform.FindChild("BG").FindChild("BackGround").GetComponent<Animator>();
        Ani_BG.enabled = false;
    }
    /// <summary>
    /// 開始冒險
    /// </summary>
    public static void StartAdventure()
    {
        //播放行進音樂
        AudioPlayer.Play(Audios.GoForward);
        //開始冒險
        Adventure = true;
        //停止戰鬥
        Fight = false;
        //播放背景動畫
        Ani_BG.enabled = true;
        //腳色播放向前走動畫
        SetPlayerCharaMotion(Motion.GoForward, true);
    }
    /// <summary>
    /// 遭遇敵方
    /// </summary>
    public static void MeetEnemy(Dictionary<string, string>[] _enemysDic)
    {
        //停止冒險
        Adventure = false;
        //重置敵人
        ResetEnemy();
        //設置敵人
        SetEnemy(_enemysDic);
        //敵方進場
        EnemyAnimator.GoIn();
    }
    /// <summary>
    /// 開始戰鬥
    /// </summary>
    public static void StartFight()
    {
        //播放戰鬥音樂
        AudioPlayer.Play(Audios.Fight);
        //開始戰鬥
        Fight = true;
        //停止背景動畫
        Ani_BG.enabled = false;
        //腳色播放待機動畫
        SetPlayerCharaMotion(Motion.Stay, true);
    }
    /// <summary>
    /// 遭遇調查事件
    /// </summary>
    public static void InvestigateEvent()
    {
        //停止冒險
        Adventure = false;
        //停止背景動畫
        Ani_BG.enabled = false;
        //播放戰鬥音樂
        AudioPlayer.Play(Audios.Fight);
        //腳色播放待機動畫
        SetPlayerCharaMotion(Motion.Stay, true);
    }
    /// <summary>
    /// 遭遇意外事件
    /// </summary>
    public static void AccidentEvent()
    {
        //停止冒險
        Adventure = false;
        //停止背景動畫
        Ani_BG.enabled = false;
        //播放戰鬥音樂
        AudioPlayer.Play(Audios.Fight);
        //腳色播放待機動畫
        SetPlayerCharaMotion(Motion.Stay, true);
    }
    /// <summary>
    /// 埋伏事件
    /// </summary>
    public static void AmbushEvent(Dictionary<string, string>[] _enemysDic)
    {
        //開始戰鬥
        Fight = true;
        //重置敵人
        ResetEnemy();
        //設置敵人
        SetEnemy(_enemysDic);
        //敵方進場
        EnemyAnimator.GoIn();
    }
    /// <summary>
    /// 繼續冒險
    /// </summary>
    public static void KeepAdventure()
    {
        //播放行進音樂
        AudioPlayer.Play(Audios.GoForward);
        //開始冒險
        Adventure = true;
        //停止戰鬥
        Fight = false;
        //播放背景動畫
        Ani_BG.enabled = true;
        //腳色播放向前走動畫
        SetPlayerCharaMotion(Motion.GoForward, true);
        //敵方出場
        EnemyAnimator.GoOut();
    }
    /// <summary>
    /// 1.檢查更新還活者的腳色清單
    /// 2.在腳色死亡時呼叫
    /// </summary>
    public static void CheckAliveChara()
    {
        //Player
        for (int i = 0; i < PAliveCharaList.Count; i++)
        {
            if (!PAliveCharaList[i].IsAlive)
                PAliveCharaList.RemoveAt(i);
        }
        //Enemy
        for (int i = 0; i < EAliveCharaList.Count; i++)
        {
            if (!EAliveCharaList[i].IsAlive)
                EAliveCharaList.RemoveAt(i);
        }
        //敵方腳色死亡檢查，若都死亡則繼續冒險
        CheckKeepAdventure();
    }
    /// <summary>
    /// 敵方腳色死亡檢查，若都死亡則繼續冒險
    /// </summary>
    static void CheckKeepAdventure()
    {
        if (EAliveCharaList.Count == 0)
            FightTitleController.ShowClearTitle();//播放消滅敵方標題
    }

}
