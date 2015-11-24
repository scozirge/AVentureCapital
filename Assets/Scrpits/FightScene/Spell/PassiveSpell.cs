using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PassiveSpell : Spell
{
    /// <summary>
    /// 初始化施法，傳入施法ID
    /// </summary>
    public PassiveSpell(int _spellID, Chara _self)
        : base(_spellID, _self)
    {
        InitSpellData();
    }
    protected void InitSpellData()
    {
        Name = GameDictionary.PSpellDic[ID].Name;
        CD = GameDictionary.PSpellDic[ID].CD;
        CDTimer = CD;
        IsAttack = GameDictionary.PSpellDic[ID].IsAttack;
        //初始化施法執行效果清單
        string executeListStr = GameDictionary.PSpellDic[ID].TriggerTarget;
        InitExecute(executeListStr);
    }
    /// <summary>
    /// 施法CD時間流逝
    /// </summary>
    public override void TimePass()
    {
        base.TimePass();
        if (CDTimer <= 0)
        {
            Execute();
        }
    }
}
