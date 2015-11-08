using UnityEngine;
using System.Collections;

public class BufferCure : Cure
{//為狀態引發的治癒(BufferCure)
    public BufferCure(int _cureID, string _actionName, ExecuteType _type, Chara _self)
        : base(_cureID, _actionName, _type, _self)
    {
    }
    /// <summary>
    /// 複寫Cure傳入目標的Execute方法，狀態引發的治癒目標是初始化時就給予了，不能再執行Execute時給予
    /// </summary>
    public override void Execute(Chara _target)
    {
        TrueCure = GetCure();//取得實際治癒量
        Debug.Log(string.Format("{0}受到{1}狀態影響，造成{2}點{3}", Self.Name, SpellName, TrueCure, Type));//ex:勇者受到祝福狀態影響，造成56點治癒
        _target.ReceiveCure(TrueCure, false, HitTextType.Cure);
    }
}
