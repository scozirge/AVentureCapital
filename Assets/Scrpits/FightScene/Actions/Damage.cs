using UnityEngine;
using System.Collections;

public class Damage : ExecuteCom
{
    //技能強度
    public float ActionAttackOdds { get; private set; }
    //造成的實際傷害
    public int TrueDamage { get; private set; }
    //此執行元件提供的貢獻值
    public int Contribution { get; protected set; }
    public Damage(ExecuteType _type, float _actionAttackOdds)
        : base(_type)
    {
        ActionAttackOdds = _actionAttackOdds;
    }
    public override void Execute(Chara _self, Chara _target)
    {
        base.Execute(_self, _target);
        //取得實際傷害量
        TrueDamage = GetDamage(_self, _target);
        Debug.Log(string.Format("對{0}執行{1}造成{2}傷害", Target.Name, Type, TrueDamage));
        _target.GetDamge(TrueDamage);
    }
    int GetDamage(Chara _self, Chara _target)
    {
        int damage = 0;
        int lethality = (int)((_self.BaseAttack + _self.EquipAttack) * (ActionAttackOdds) * ((1 + (_self.CurMind / _self.MaxMind)) / 2));
        Contribution = lethality;
        int resistance = (int)((_target.BaseDefense + _target.EquipDefense) * _target.EquipDefeseOdds);
        damage = (int)((100 * lethality) / (100 + resistance));
        return damage;
    }
}
