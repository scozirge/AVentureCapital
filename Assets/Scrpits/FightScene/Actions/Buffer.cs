using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Buffer : ExecuteCom
{
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
    public Damage TriggerDamage { get; protected set; }
    //此狀態持續時，每經過一段時間會造成的治癒效果
    public Cure TriggerCure { get; protected set; }
    //觸發週期時間
    public float Circle { get; set; }
    //得到狀態時，是否起始就會觸發Damge & Cure
    public bool IniTrigger { get; protected set; }
    //是否為可疊加效果
    public bool Stackable { get; protected set; }
    //最高疊加層數
    public int MaxStack { get; protected set; }
    //增加的攻擊加值
    public int BufferAttackVlaue { get; protected set; }
    //增加的攻擊乘值
    public float BufferAttackRate { get; protected set; }
    //增加的防禦加值
    public int BufferDefenseVlaue { get; protected set; }
    //增加的防禦乘值
    public float BufferDefenseRate { get; protected set; }
    //此執行效果提供的貢獻率
    public float ContributionRate { get; protected set; }

    public Buffer(string _actionName, ExecuteType _type, Chara _self, Dictionary<string, string> _attrDic)
        : base(_actionName, _type, _self)
    {
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
        BufferAttackVlaue = int.Parse(_attrDic["BufferAttackValue"]);
        BufferAttackRate = float.Parse(_attrDic["BufferAttackRate"]);
        BufferDefenseVlaue = int.Parse(_attrDic["BufferDefenseValue"]);
        BufferDefenseRate = float.Parse(_attrDic["BufferDefenseRate"]);
        ContributionRate = float.Parse(_attrDic["ContributionRate"]);
    }
}
