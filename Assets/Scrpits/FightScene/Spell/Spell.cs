﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spell
{
    //施法編號
    public int ID { get; private set; }
    //施法名稱
    public string Name { get; private set; }
    //施法時間
    public float CD { get; private set; }
    //執行施法剩餘時間
    public float CDTimer { get; private set; }
    //每次時間流逝的單位時間
    const float TimeUnit = 0.1f;
    //執行列表
    public List<ExecuteCom> TriggerTargetList;
    //自身
    public Chara Self;
    //是否為攻擊施法
    public bool IsAttack;
    /// <summary>
    /// 初始化施法，傳入施法ID
    /// </summary>
    public Spell(int _spellID, Chara _self)
    {
        ID = _spellID;
        Name = GameDictionary.SpellDic[ID].Name;
        CD = GameDictionary.SpellDic[ID].CD;
        CDTimer = CD;
        Self = _self;
        IsAttack = GameDictionary.SpellDic[ID].IsAttack;
        //初始化施法執行效果清單
        InitExecute();
    }
    /// <summary>
    /// 初始化施法執行效果清單
    /// </summary>
    void InitExecute()
    {
        TriggerTargetList = new List<ExecuteCom>();
        string executeListStr = GameDictionary.SpellDic[ID].TriggerTarget;
        string[] executeStr = executeListStr.Split(',');
        //以迴圈加入所有執行元件
        for (int i = 0; i < executeStr.Length; i++)
        {
            string[] executeColumn = executeStr[i].Split(':');
            //執行類型
            string type = executeColumn[0];
            //執行ID
            int executeID = int.Parse(executeColumn[1]);
            //如果執行ID為0則跳過此執行
            if (executeID == 0)
                continue;
            //依照執行類型與執行ID加入執行的元件
            switch (type)
            {
                case "D"://傷害效果
                    Damage damage = new Damage(executeID, Name, ExecuteType.Damage, Self);
                    TriggerTargetList.Add(damage);
                    break;
                case "C"://治癒效果
                    Cure cure = new Cure(executeID, Name, ExecuteType.Damage, Self);
                    TriggerTargetList.Add(cure);
                    break;
                case "B"://狀態效果
                    Buffer buffer = new Buffer(executeID, Name, ExecuteType.Damage, Self);
                    TriggerTargetList.Add(buffer);
                    break;
                default:
                    Debug.LogWarning(string.Format("施法ID:{0}的施法效果類型{0)無法判定，必須為D、C、B", ID, type));
                    break;
            }
        }
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
        for (int i = 0; i < TriggerTargetList.Count; i++)
        {
            TriggerTargetList[i].Execute(CurTarget);
        }
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
