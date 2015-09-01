using UnityEngine;
using System.Collections;

public abstract class ExecuteCom
{//執行效果的基底類別，子類別有Damage,Cure,Buffer

    //發動此執行元件的動作名稱
    public string ActionName { get; protected set; }
    // 類型
    public ExecuteType Type { get; protected set; }
    //自身
    public Chara Self { get; protected set; }
    // 目標
    public Chara Target { get; protected set; }

    public ExecuteCom(string _actionName, ExecuteType _type, Chara _self)
    {
        ActionName = _actionName;
        Type = _type;
        Self = _self;
    }


    /// <summary>
    /// 執行
    /// </summary>
    public virtual void Execute(Chara _target)
    {
        Target = _target;
    }
}
