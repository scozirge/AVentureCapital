using UnityEngine;
using System.Collections;

public class Cure : ExecuteCom
{
    //基礎治癒量
    public int BaseCure { get; protected set; }
    //絕對治癒
    public int AbsoluteCure { get; protected set; }
    //最終治癒量
    public int TrueCure { get; protected set; }
    //效果觸發機率
    public float Probability { get; protected set; }
    /// <summary>
    /// 初始化施法治癒效果
    /// </summary>
    public Cure(int _cureID, string _spellName, ExecuteType _type, Chara _self)
        : base(_cureID, _spellName, _type, _self)
    {
        Probability = GameDictionary.CureDic[ID].Probability;
        BaseCure = GameDictionary.CureDic[ID].BaseCure;
        AbsoluteCure = GameDictionary.CureDic[ID].AbsoluteCure;
    }
    public override void Execute(Chara _target)
    {
        base.Execute(_target);
        TrueCure = GetCure();//取得實際治癒量
        Debug.Log(string.Format("{0}施放{1}對{2}恢復{3}點{4}", Self.Name, SpellName, _target.Name, TrueCure, Type));//ex:勇者施放治癒隊友造成46點恢復
        _target.ReceiveCure(TrueCure, true, HitTextType.Cure);
    }
    protected int GetCure()
    {
        int cure = BaseCure + AbsoluteCure;
        return cure;
    }
}
