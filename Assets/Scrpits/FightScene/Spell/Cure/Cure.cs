using UnityEngine;
using System.Collections;

public class Cure : ExecuteCom
{
    // 執行元件類型
    public ExecuteType ExecuteComType { get; protected set; }
    //基礎治癒量
    public int BaseCure { get; protected set; }
    //絕對治癒
    public int AbsoluteCure { get; protected set; }
    //最終治癒量
    public int TrueCure { get; protected set; }
    //效果觸發機率
    public float Probability { get; protected set; }
    //延遲顯示扣血
    public float ShowDelay { get; private set; }
    /// <summary>
    /// 初始化施法治癒效果
    /// </summary>
    public Cure(int _cureID, Chara _self)
        : base(_cureID, _self)
    {
        ExecuteComType = ExecuteType.Cure;
        Probability = GameDictionary.CureDic[ID].Probability;
        BaseCure = GameDictionary.CureDic[ID].BaseCure;
        AbsoluteCure = GameDictionary.CureDic[ID].AbsoluteCure;
        ShowDelay = GameDictionary.CureDic[ID].ShowDelay;
    }
    public override void Execute(Chara _target)
    {
        base.Execute(_target);
        TrueCure = GetCure();//取得實際治癒量
        Debug.Log(string.Format("{0}對{1}恢復{2}點{3}", Self.Name, _target.Name, TrueCure, ExecuteComType));//ex:勇者施放治癒隊友造成46點恢復
        _target.ReceiveCure(TrueCure, true, HitTextType.Cure, ShowDelay);
    }
    protected int GetCure()
    {
        int cure = BaseCure + AbsoluteCure;
        return cure;
    }
}
