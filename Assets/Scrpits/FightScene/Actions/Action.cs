using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Action
{
    //動作名稱
    public string Name { get; private set; }
    //動作時間
    public float Time { get; private set; }
    //執行動作剩餘時間
    public float RemainTime { get; private set; }
    const float TimeUnit = 0.1f;
    //執行列表
    public List<ExecuteCom> ExecuteList;
    //自身
    public Chara Self;
    //目標
    public Chara Target;
    /// <summary>
    /// 設定動作內容
    /// </summary>
    public Action(string _name, float _time, List<ExecuteCom> _executeList, Chara _self, Chara _target)
    {
        Name = _name;
        Time = _time;
        RemainTime = Time;
        ExecuteList = _executeList;
        Self = _self;
        Target = _target;
    }
    /// <summary>
    /// 判斷CD是否到達可以進行此動作
    /// </summary>
    public bool ExecuteCheck()
    {
        bool execute = false;
        if (RemainTime > 0)
        {
            RemainTime -= TimeUnit;
        }
        else
        {
            execute = true;
            RemainTime = Time;
        }
        return execute;
    }
    /// <summary>
    /// 執行動作
    /// </summary>
    public void Execute()
    {
        for (int i = 0; i < ExecuteList.Count; i++)
        {
            ExecuteList[i].Execute(Self, Target);
        }
        FightSceneUI.RefreshHPUI();
    }
}
