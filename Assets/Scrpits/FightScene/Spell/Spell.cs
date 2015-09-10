using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sell
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
    public bool IsAttackAction;
    /// <summary>
    /// 設定施法內容
    /// </summary>
    public Sell(string _name, float _time, List<ExecuteCom> _executeList, Chara _self, bool _attackAction)
    {
        Name = _name;
        CD = _time;
        CDTimer = CD;
        ExecuteList = _executeList;
        Self = _self;
        IsAttackAction = _attackAction;
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
        //執行施法
        for (int i = 0; i < ExecuteList.Count; i++)
        {
            ExecuteList[i].Execute(SelectTarget());
        }
        FightSceneUI.RefreshHPUI();
    }
    Chara SelectTarget()
    {
        //判斷目標
        Chara target;
        if (Self.TheCharaType == CharaType.Player)
        {
            if (IsAttackAction)
            {
                target = FightScene.EChara;
            }
            else
            {
                int rnd = Random.Range(0, FightScene.PAliveCharaList.Count);
                target = FightScene.PAliveCharaList[rnd];
            }
        }
        else
        {
            if (IsAttackAction)
            {
                int rnd = Random.Range(0, FightScene.PAliveCharaList.Count);
                target = FightScene.PAliveCharaList[rnd];
            }
            else
            {
                target = FightScene.EChara;
            }
        }
        return target;
    }
}
