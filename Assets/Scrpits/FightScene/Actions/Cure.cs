using UnityEngine;
using System.Collections;

public class Cure : ExecuteCom
{
    //基礎治癒量
    public int BaseCure { get; private set; }
    //最終治癒量
    public int TrueCure { get; private set; }
    //此執行元件提供的貢獻值
    public int Contribution { get; protected set; }
    public Cure(ExecuteType _type, int _baseCure)
        : base(_type)
    {
        BaseCure = _baseCure;
    }
    public override void Execute(string _actionName, Chara _self, Chara _target)
    {
        base.Execute(_actionName, _self, _target);
        TrueCure = GetCure(_self, _target);//取得實際治癒量
        Debug.Log(string.Format("{0}{1}{2}造成{3}點{4}", Self.Name, ActionName, Target.Name, TrueCure, Type));//ex:勇者治癒隊友造成46點恢復
        _target.GetCure(TrueCure);
    }
    int GetCure(Chara _self, Chara _target)
    {
        int cure = BaseCure;
        Contribution = cure;
        return cure;
    }
}
