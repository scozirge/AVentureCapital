using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Buffer : ExecuteCom
{
    // 執行元件類型
    public ExecuteType ExecuteComType { get; protected set; }
    //效果類型
    public BufferType TheBufferType { get; protected set; }
    //是否為正面狀態
    public bool IsBuff { get; protected set; }
    //是否為負面狀態
    public bool IsDeBuff { get; protected set; }
    //觸發機率
    public float Probability { get; protected set; }
    //持續時間
    public float Duration { get; set; }
    //此狀態持續時，每經過一段執行時間會造成的效果清單
    public List<ExecuteCom> TriggerExecuteList;
    //觸發週期時間
    public float Circle { get; set; }
    //得到狀態時，是否起始就會觸發Damge & Cure
    public bool IniTrigger { get; protected set; }
    //是否為可疊加效果
    //腳色如果中了同樣的BufferID的Buffer，會判斷是否為可疊加的Buffer，不可疊加的Buffer會重置持續時間，並取代掉舊的Buffer，
    //而可疊加的Buffer會重複獲得新Buffer且不會影響到舊的Buffer
    public bool Stackable { get; protected set; }
    //最高疊加層數
    public int MaxStack { get; protected set; }
    //物攻加值
    public int PAttack { get; private set; }
    //物傷乘值
    public float PLethalityRate { get; private set; }
    //魔攻加值
    public int MAttack { get; private set; }
    //魔傷乘值
    public float MLethalityRate { get; private set; }
    //物防加值
    public int PDefense { get; private set; }
    //物抗乘值
    public float PResistenceRate { get; private set; }
    //魔防加值
    public int MDefense { get; private set; }
    //魔抗乘值
    public float MResistenceRate { get; private set; }
    /// <summary>
    /// 初始化施法狀態效果
    /// </summary>
    public Buffer(int _bufferID, Chara _self)
        : base(_bufferID, _self)
    {
        if (_bufferID == 0)
        {
            Debug.LogWarning("BufferID為0");
            return;
        }
        ExecuteComType = ExecuteType.Buffer;
        TheBufferType = GameDictionary.BufferDic[ID].Type;
        IsBuff = GameDictionary.BufferDic[ID].IsBuff;
        IsDeBuff = GameDictionary.BufferDic[ID].IsDeBuff;
        Probability = GameDictionary.BufferDic[ID].Probability;
        Duration = GameDictionary.BufferDic[ID].Duration;
        Circle = GameDictionary.BufferDic[ID].Circle;
        IniTrigger = GameDictionary.BufferDic[ID].IniTrigger;
        Stackable = GameDictionary.BufferDic[ID].Stackable;
        MaxStack = GameDictionary.BufferDic[ID].MaxStack;
        PAttack = GameDictionary.BufferDic[ID].PAttack;
        PLethalityRate = GameDictionary.BufferDic[ID].PLethalityRate;
        MAttack = GameDictionary.BufferDic[ID].MAttack;
        MLethalityRate = GameDictionary.BufferDic[ID].MLethalityRate;
        PDefense = GameDictionary.BufferDic[ID].PDefense;
        PResistenceRate = GameDictionary.BufferDic[ID].PResistanceRate;
        MDefense = GameDictionary.BufferDic[ID].MDefense;
        MResistenceRate = GameDictionary.BufferDic[ID].MResistanceRate;
        //初始化施法執行效果清單
        InitExecute();
    }
    /// <summary>
    /// 初始化施法執行效果清單
    /// </summary>
    void InitExecute()
    {
        TriggerExecuteList = new List<ExecuteCom>();
        string executeListStr = GameDictionary.BufferDic[ID].TriggerExecute;
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
                    BufferDamage damage = new BufferDamage(executeID, Self);
                    TriggerExecuteList.Add(damage);
                    break;
                case "C"://治癒效果
                    Cure cure = new BufferCure(executeID, Self);
                    TriggerExecuteList.Add(cure);
                    break;
                case "B"://狀態效果
                    Buffer buffer = new Buffer(executeID, Self);
                    TriggerExecuteList.Add(buffer);
                    break;
                default:
                    Debug.LogWarning(string.Format("BufferID:{0}的觸發效果類型{0)無法判定，必須為D、C、B", ID, type));
                    break;
            }
        }
    }
    /// <summary>
    /// 用於腳色施法執行狀態時，傳入目標，對目標賦予此狀態
    /// </summary>
    public override void Execute(Chara _target)
    {
        base.Execute(_target);
        Debug.Log(string.Format("{0}施放對{1}附加{2}效果", Self.Name, _target.Name, TheBufferType));//ex:勇者施放砍殺對大惡魔附加流血狀態
        _target.ReceiveBuffer(this);
    }
}
