using UnityEngine;
using System.Collections;

public class BufferDamage : ExecuteCom
{//與動作的傷害處發效果差別在於動作是在動作執行時才決定目標，而狀態觸發的傷害效果是在狀態執行時就給予觸發的傷害效果目標

    //技能強度
    public float ActionAttackRate { get; protected set; }
    //造成的實際傷害
    public int TrueDamage { get; protected set; }
    //此執行元件提供的貢獻值
    public int Contribution { get; protected set; }
    /// <summary>
    /// 初始化狀態的傷害觸發效果
    /// </summary>
    public BufferDamage(string _actionName, ExecuteType _type, Chara _self,Chara _target, float _actionAttackRate)
        : base(_actionName, _type, _self)
    {
        Target = _target;
        ActionAttackRate = _actionAttackRate;
    }
    /// <summary>
    /// 用於腳色動作執行傷害效果時，傳入目標，對目標造成傷害
    /// </summary>
    public override void Execute(Chara _target)
    {
        /*
        base.Execute();
        Target = _target;
        //取得實際傷害量
        TrueDamage = GetDamage();
        Debug.Log(string.Format("{0}施放{1}{2}造成{3}點{4}", Self.Name, ActionName, Target.Name, TrueDamage, Type));//ex:勇者施放砍殺大惡魔造成46點傷害
        Target.GetDamge(TrueDamage);
        */
    }
    public void Execute()
    {

    }

}
