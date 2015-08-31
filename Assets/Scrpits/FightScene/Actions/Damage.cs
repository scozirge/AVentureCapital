using UnityEngine;
using System.Collections;

public class Damage : ExecuteCom
{
    //技能強度
    public float ActionAttackRate { get; private set; }
    //造成的實際傷害
    public int TrueDamage { get; private set; }
    //此執行元件提供的貢獻值
    public int Contribution { get; protected set; }
    public Damage(ExecuteType _type, float _actionAttackRate)
        : base(_type)
    {
        ActionAttackRate = _actionAttackRate;
    }
    public override void Execute(string _actionName, Chara _self, Chara _target)
    {
        base.Execute(_actionName, _self, _target);
        //取得實際傷害量
        TrueDamage = GetDamage(_self, _target);
        Debug.Log(string.Format("{0}{1}{2}造成{3}點{4}", Self.Name, ActionName, Target.Name, TrueDamage, Type));//ex:勇者砍殺大惡魔造成46點傷害
        _target.GetDamge(TrueDamage);
    }
    int GetDamage(Chara _self, Chara _target)
    {
        int damage = 0;
        //物理殺傷力= (腳色攻擊值+裝備攻擊值+效果攻擊加值) *(效果攻擊乘值) * (技能強度) * ((1+(目前精神/最大精神))/2)
        int lethality = (int)((_self.BaseAttack + _self.EquipAttack + _self.BufferAttackVlue) * (_self.BufferAttackRate) * (ActionAttackRate) * ((1 + (_self.CurMind / _self.MaxMind)) / 2));
        Contribution = lethality;
        //(腳色防禦值+裝備防禦值+效果防禦加值) *(效果防禦乘值)*(裝備抵抗強度)
        int resistance = (int)((_target.BaseDefense + _target.EquipDefense + _target.BufferDefenseValue) * _target.BufferDefenseRate * _target.EquipDefenseRate);
        //物理傷害值=(物理殺傷力*100)/(100+抵抗力)*武器相剋率)
        damage = (int)((100 * lethality) / (100 + resistance));
        return damage;
    }
}
