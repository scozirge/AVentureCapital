using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Buffer : ExecuteCom
{
    //此執行元件提供的貢獻率
    public float ContributionRate { get; protected set; }
    //得到狀態時，是否起始就會觸發Damge & Cure
    public bool StartTrigger { get; protected set; }
    //是否為可疊加效果
    public bool IsDeckBuffer { get; protected set; }
    //最高疊加層數
    public int MaxDeck { get; protected set; }
    //效果類型
    public BufferType BufferType { get; protected set; }
    //此狀態持續時，每經過一段執行時間會造成的傷害效果
    public Damage TheDamage { get; protected set; }
    //此狀態持續時，每經過一段時間會造成的治癒效果
    public Cure TheCure { get; protected set; }
    //增加的攻擊加值
    public int BufferAttackVlaue { get; protected set; }
    //增加的攻擊乘值
    public float BufferAttackRate { get; protected set; }
    //增加的防禦加值
    public int BufferDefenseVlaue { get; protected set; }
    //增加的防禦乘值
    public float BufferDefenseRate { get; protected set; }
    public Buffer(ExecuteType _type, Dictionary<string, string> _attrDic)
        : base(_type)
    {
        BufferAttackVlaue = int.Parse(_attrDic["BufferAttackValue"]);
        BufferAttackRate = float.Parse(_attrDic["BufferAttackRate"]);
        BufferDefenseVlaue = int.Parse(_attrDic["BufferDefenseValue"]);
        BufferDefenseRate = float.Parse(_attrDic["BufferDefenseRate"]);
        ContributionRate = float.Parse(_attrDic["ContributionRate"]);
    }
    public override void Execute(string _actionName, Chara _self, Chara _target)
    {
        base.Execute(_actionName, _self, _target);
        Debug.Log(string.Format("對{0}施放{1}", Target.Name, Type));
    }
}
