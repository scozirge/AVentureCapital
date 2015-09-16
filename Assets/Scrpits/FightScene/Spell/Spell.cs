using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spell
{
    //施法名稱
    public string Name { get; private set; }
    //施法時間
    public float CD { get; private set; }
    //執行施法剩餘時間
    public float CDTimer { get; private set; }
    //每次時間流逝的單位時間
    const float TimeUnit = 0.1f;
    //執行列表
    public List<ExecuteCom> ExecuteList;
    //自身
    public Chara Self;
    //是否為攻擊施法
    public bool IsAttack;
    /// <summary>
    /// 設定施法內容
    /// </summary>
    public Spell(string _name, float _time, List<ExecuteCom> _executeList, Chara _self, bool _attack)
    {
        Name = _name;
        CD = _time;
        CDTimer = CD;
        ExecuteList = _executeList;
        Self = _self;
        IsAttack = _attack;
    }
    /// <summary>
    /// 判斷CD是否到達可以進行此施法
    /// </summary>
    public bool ExecuteCheck()
    {
        bool execute = false;
        if (CDTimer > 0)
        {
            CDTimer -= TimeUnit;
        }
        else
        {
            execute = true;
            CDTimer = CD;
            Execute();
        }
        return execute;
    }
    /// <summary>
    /// 執行施法
    /// </summary>
    void Execute()
    {
        //此施法的暫時目標
        Chara CurTarget = SelectTarget();
        //如果沒有可做為目標的腳色，取消執行施法
        if (CurTarget == null)
        {
            Debug.Log("無可做為目標的腳色，取消執行施法");
            return;
        }
        if (IsAttack)
        {
            //播放攻擊動作
            Self.PlayMotion(Motion.Attack, 0);
            //播放挨打動作
            CurTarget.PlayMotion(Motion.Beaten, 0);
        }
        else
        {
            //播放攻擊動作
            Self.PlayMotion(Motion.Support, 0);
        }
        //執行施法
        for (int i = 0; i < ExecuteList.Count; i++)
        {
            ExecuteList[i].Execute(CurTarget);
        }
        FightSceneUI.RefreshHPUI();
    }
    /// <summary>
    /// 選擇目標
    /// </summary>
    Chara SelectTarget()
    {
        //判斷目標
        Chara target;
        //判斷目標是玩家還是敵人
        bool targetIsEnemy = false;
        if (Self.TheCharaType == CharaType.Player)
        {
            if (IsAttack)
                targetIsEnemy = true;
            else
                targetIsEnemy = false;
        }
        else
        {
            if (IsAttack)
                targetIsEnemy = false;
            else
                targetIsEnemy = true;
        }
        //從可被當做目標的清單中隨機挑一個腳色作為目標
        if (targetIsEnemy)
        {
            //若是沒有可做為目標的腳色，則return null
            if (FightScene.EAliveCharaList.Count == 0)
                return null;
            int rnd = Random.Range(0, FightScene.EAliveCharaList.Count);
            target = FightScene.EAliveCharaList[rnd];
        }
        else
        {
            //若是沒有可做為目標的腳色，則return null
            if (FightScene.PAliveCharaList.Count == 0)
                return null;
            int rnd = Random.Range(0, FightScene.PAliveCharaList.Count);
            target = FightScene.PAliveCharaList[rnd];
        }
        return target;
    }
}
