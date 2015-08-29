using UnityEngine;
using System.Collections;

public abstract class ExecuteCom
{//執行效果的基底類別，子類別有Damage,Cure,Buffer

    /// 類型
    public ExecuteType Type { get; protected set; }
    //自身
    public Chara Self { get; protected set; }
    /// 目標
    public Chara Target { get; protected set; }

    public ExecuteCom(ExecuteType _type)
    {
        Type = _type;
    }


    /// <summary>
    /// 執行
    /// </summary>
    public virtual void Execute(Chara _self, Chara _target)
    {
        Self = _self;
        Target = _target;
    }
}
