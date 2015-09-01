using UnityEngine;
using System.Collections;

public class BufferDamage : Damage
{//為狀態引發的傷害(BufferDamage)，與施法執行的傷害(Damage)差別在於Damge是在施法執行時才決定目標，而BufferDamage是在狀態執行時就給予觸發的目標

    /// <summary>
    /// 初始化狀態的傷害觸發效果
    /// </summary>
    public BufferDamage(string _actionName, ExecuteType _type, Chara _self, Chara _target, float _actionAttackRate)
        : base(_actionName, _type, _self, _actionAttackRate)
    {
        Target = _target;
    }
    /// <summary>
    /// 複寫Damage傳入目標的Execute方法，狀態引發的傷害目標是初始化時就給予了，不能再執行Execute時給予
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
        //取得實際傷害量
        TrueDamage = GetDamage();
        Debug.Log(string.Format("{0}受到{1}狀態影響，造成{2}點{3}", Self.Name, ActionName, TrueDamage, Type));//ex:大惡魔受到砍殺狀態影響，造成56點傷害
        Target.GetDamge(TrueDamage);
    }

}
