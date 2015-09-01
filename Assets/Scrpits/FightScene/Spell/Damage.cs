using UnityEngine;
using System.Collections;

public class Damage : ExecuteCom
{
    //技能強度
    public float ActionAttackRate { get; protected set; }
    //造成的實際傷害
    public int TrueDamage { get; protected set; }
    //此執行元件提供的貢獻值
    public int Contribution { get; protected set; }
    /// <summary>
    /// 初始化施法的傷害效果
    /// </summary>
    public Damage(string _actionName, ExecuteType _type, Chara _self, float _actionAttackRate)
        : base(_actionName, _type, _self)
    {
        ActionAttackRate = _actionAttackRate;
    }
    /// <summary>
    /// 用於腳色施法執行傷害效果時，傳入目標，對目標造成傷害
    /// </summary>
    public override void Execute(Chara _target)
    {
        base.Execute(_target);
        //取得實際傷害量
        TrueDamage = GetDamage();
        Debug.Log(string.Format("{0}施放{1}{2}造成{3}點{4}", Self.Name, ActionName, Target.Name, TrueDamage, Type));//ex:勇者施放砍殺大惡魔造成46點傷害
        Target.GetDamge(TrueDamage);
    }
    protected virtual int GetDamage()
    {
        int damage = 0;
        //物理殺傷力= (腳色攻擊值+裝備攻擊值+效果攻擊加值) *(效果攻擊乘值) * (技能強度) * ((1+(目前精神/最大精神))/2)
        int lethality = (int)((Self.BaseAttack + Self.EquipAttack + Self.BufferAttackVlue) * (Self.BufferAttackRate) * (ActionAttackRate) * ((1 + (Self.CurMind / Self.MaxMind)) / 2));
        Contribution = lethality;
        //(腳色防禦值+裝備防禦值+效果防禦加值) *(效果防禦乘值)*(裝備抵抗強度)
        int resistance = (int)((Target.BaseDefense + Target.EquipDefense + Target.BufferDefenseValue) * Target.BufferDefenseRate * Target.EquipDefenseRate);
        //物理傷害值=(物理殺傷力*100)/(100+抵抗力)*武器相剋率)
        damage = (int)((100 * lethality) / (100 + resistance));
        return damage;
    }
}
