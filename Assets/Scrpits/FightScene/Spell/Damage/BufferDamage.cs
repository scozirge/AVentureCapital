using UnityEngine;
using System.Collections;

public class BufferDamage : Damage
{//為狀態引發的傷害(BufferDamage)

    /// <summary>
    /// 初始化狀態的傷害觸發效果
    /// </summary>
    public BufferDamage(int _damageID, Chara _self)
        : base(_damageID, _self)
    {
    }
    /// <summary>
    /// 複寫Damage傳入目標的Execute方法，狀態引發的傷害目標是初始化時就給予了，不能再執行Execute時給予
    /// </summary>
    public override void Execute(Chara _target)
    {
        //取得實際傷害量
        TrueDamage = GetDamage(_target);
        Debug.Log(string.Format("{0}受到{1}點{2}", Self.Name, TrueDamage, ExecuteComType));//ex:大惡魔受到砍殺狀態影響，造成56點傷害
        _target.ReceivePhysicalDamge(TrueDamage, false, HitTextType.DOT, ShowDelay);
    }
}
