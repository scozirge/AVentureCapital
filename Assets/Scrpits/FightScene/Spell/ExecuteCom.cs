using UnityEngine;
using System.Collections;

public abstract class ExecuteCom
{//執行效果的基底類別，子類別有Damage,Cure,Buffer

    //發動此執行元件的施法名稱
    public string SpellName { get; protected set; }
    // 類型
    public ExecuteType Type { get; protected set; }
    //自身
    public Chara Self { get; protected set; }
    // 不可在這裡設定目標，因為此腳色的技能目標會更動，如果在這裡設定目標，會發生狀態的給出去後狀態的目標又改變
    //public Chara Target { get; protected set; }

    public ExecuteCom(string _spellName, ExecuteType _type, Chara _self)
    {
        SpellName = _spellName;
        Type = _type;
        Self = _self;
    }
    /// <summary>
    /// 執行
    /// </summary>
    public virtual void Execute(Chara _target)
    {
    }
}
