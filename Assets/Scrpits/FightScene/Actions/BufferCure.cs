using UnityEngine;
using System.Collections;

public class BufferCure : Cure
{//為狀態引發的治癒(BufferCure)，與施法執行的治癒(Cure)差別在於Cure是在施法執行時才決定目標，而BufferCure是在狀態執行時就給予觸發的目標
    public BufferCure(string _actionName, ExecuteType _type, Chara _self, Chara _target, int _baseCure)
        : base(_actionName, _type, _self, _baseCure)
    {
        Target = _target;
    }
    /// <summary>
    /// 複寫Cure傳入目標的Execute方法，狀態引發的治癒目標是初始化時就給予了，不能再執行Execute時給予
    /// </summary>
    public override void Execute(Chara _target)
    {
        Execute();
    }
    /// <summary>
    /// 執行
    /// </summary>
    public void Execute()
    {
        TrueCure = GetCure();//取得實際治癒量
        Debug.Log(string.Format("{0}受到{1}狀態影響，造成{2}點{3}", Self.Name, ActionName, TrueCure, Type));//ex:勇者受到祝福狀態影響，造成56點治癒
        Target.GetCure(TrueCure);
    }
}
