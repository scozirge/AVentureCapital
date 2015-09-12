using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Buffer : ExecuteCom
{
    //BufferID，腳色如果中了同樣的BufferID的Buffer，會判斷是否為可疊加的Buffer，不可疊加的Buffer會重置持續時間，並取代掉舊的Buffer，
    //而可疊加的Buffer會重複獲得新Buffer且不會影響到舊的Buffer
    public int ID { get; protected set; }
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
    //此狀態持續時，每經過一段執行時間會造成的傷害效果
    public BufferDamage TriggerDamage { get; protected set; }
    //此狀態持續時，每經過一段時間會造成的治癒效果
    public BufferCure TriggerCure { get; protected set; }
    //觸發週期時間
    public float Circle { get; set; }
    //得到狀態時，是否起始就會觸發Damge & Cure
    public bool IniTrigger { get; protected set; }
    //是否為可疊加效果
    public bool Stackable { get; protected set; }
    //最高疊加層數
    public int MaxStack { get; protected set; }
    //增加的攻擊加值
    public int AttackVlaue { get; protected set; }
    //增加的攻擊乘值
    public float AttackRate { get; protected set; }
    //增加的防禦加值
    public int DefenseVlaue { get; protected set; }
    //增加的防禦乘值
    public float DefenseRate { get; protected set; }
    //此執行效果提供的貢獻率
    public float ContributionRate { get; protected set; }

    public Buffer(string _actionName, ExecuteType _type, Chara _self, Dictionary<string, string> _attrDic)
        : base(_actionName, _type, _self)
    {
        ID = int.Parse(_attrDic["BufferID"]);
        TheBufferType = (BufferType)Enum.Parse(typeof(BufferType), _attrDic["Type"], false);
        IsBuff = bool.Parse((_attrDic["IsBuff"]));
        IsDeBuff = bool.Parse((_attrDic["IsDeBuff"]));
        Probability = float.Parse(_attrDic["Probability"]);
        Duration = float.Parse(_attrDic["Duration"]);
        //TriggerDamage
        //TriggerCure
        Circle = float.Parse(_attrDic["Circle"]);
        IniTrigger = bool.Parse((_attrDic["IniTrigger"]));
        Stackable = bool.Parse((_attrDic["Stackable"]));
        MaxStack = int.Parse(_attrDic["MaxStack"]);
        AttackVlaue = int.Parse(_attrDic["BufferAttackValue"]);
        AttackRate = float.Parse(_attrDic["BufferAttackRate"]);
        DefenseVlaue = int.Parse(_attrDic["BufferDefenseValue"]);
        DefenseRate = float.Parse(_attrDic["BufferDefenseRate"]);
        ContributionRate = float.Parse(_attrDic["ContributionRate"]);
    }
    /// <summary>
    /// 用於腳色施法執行狀態時，傳入目標，對目標賦予此狀態
    /// </summary>
    public override void Execute(Chara _target)
    {
        base.Execute(_target);
        Debug.Log(string.Format("{0}施放{1}對{2}附加{3}{4}", Self.Name, ActionName, Target.Name, TheBufferType, Type));//ex:勇者施放砍殺對大惡魔附加流血狀態
        Target.GetBuffer(this);
    }
}
