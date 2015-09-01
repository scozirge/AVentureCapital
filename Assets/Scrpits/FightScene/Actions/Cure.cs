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
    public Cure(string _actionName, ExecuteType _type, Chara _self, int _baseCure)
        : base(_actionName, _type, _self)
    {
        BaseCure = _baseCure;
    }
    public override void Execute(Chara _target)
    {
        base.Execute(_target);
        TrueCure = GetCure();//取得實際治癒量
        Debug.Log(string.Format("{0}施放{1}{2}造成{3}點{4}", Self.Name, ActionName, Target.Name, TrueCure, Type));//ex:勇者施放治癒隊友造成46點恢復
        Target.GetCure(TrueCure);
    }
    int GetCure()
    {
        int cure = BaseCure;
        Contribution = cure;
        return cure;
    }
}
