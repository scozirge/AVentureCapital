using UnityEngine;
using System.Collections;

public partial class FightScene
{
    static Animator Ani_BG;
    /// <summary>
    /// 起始設定Scene
    /// </summary>
    static void SetScene()
    {
        Ani_BG = MyTransform.FindChild("BG").FindChild("BackGround").GetComponent<Animator>();
        Ani_BG.enabled = false;
    }
    /// <summary>
    /// 開始冒險
    /// </summary>
    public static void StartAdventure()
    {
        Adventure = true;
        //播放背景動畫
        Ani_BG.enabled = true;
        //腳色播放向前走動畫
        SetPlayerCharaMotion(Motion.GoForward, true);
    }
    /// <summary>
    /// 遭遇敵方
    /// </summary>
    static void MeetEnemy()
    {
        //敵方進場
        EnemyAnimator.GoIn();
    }
    /// <summary>
    /// 開始戰鬥
    /// </summary>
    public static void StartFight()
    {
        //停止冒險
        Adventure = false;
        //停止背景動畫
        Ani_BG.enabled = false;
        //開始戰鬥
        Fight = true;
        //腳色播放待機動畫
        SetPlayerCharaMotion(Motion.Stay, true);
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
    }

}
