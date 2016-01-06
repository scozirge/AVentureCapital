using UnityEngine;
using System.Collections;

public abstract class ExecuteCom
{//執行效果的基底類別，子類別有Damage,Cure,Buffer

    //執行元件ID
    public int ID { get; protected set; }
    //自身
    public Chara Self { get; protected set; }
    // 不可在這裡設定目標，因為此腳色的技能目標會更動，如果在這裡設定目標，會發生狀態給出去後狀態的目標又改變
    //public Chara Target { get; protected set; }

    public ExecuteCom(int _executeID, Chara _self)
    {
        ID = _executeID;
        Self = _self;
    }
    /// <summary>
    /// 執行
    /// </summary>
    public virtual void Execute(Chara _target)
    {
    }
}
