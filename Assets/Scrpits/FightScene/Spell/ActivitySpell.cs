using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
public class ActivitySpell : Spell
{
    public new PlayerChara Self;
    //消耗精神
    public int ConsumeVitality { get; private set; }
    //施法圖像名稱
    public string IconName { get; private set; }
    //施法類型
    public SpellType Type { get; private set; }
    //可否在非戰鬥時施放
    public bool InSpareTime { get; private set; }
    // 冷卻百分比
    public float CDRaito { get; protected set; }
    //結束CD
    public bool FinishCD { get; protected set; }
    /// <summary>
    /// 初始化主動施法，傳入施法ID
    /// </summary>
    public ActivitySpell(int _spellID, PlayerChara _self)
        : base(_spellID, _self)
    {
        Self = _self;
        InitSpellData();
    }
    /// <summary>
    /// 初始化施法資料
    /// </summary>
    protected void InitSpellData()
    {
        Name = GameDictionary.ASpellDic[ID].Name;
        CD = GameDictionary.ASpellDic[ID].CD;
        ConsumeVitality = GameDictionary.ASpellDic[ID].ConsumeVitality;
        FinishCD = true;
        CDTimer = 0;
        UpdateCDRatio();
        IsAttack = GameDictionary.ASpellDic[ID].IsAttack;
        //初始化施法執行效果清單
        string executeListStr = GameDictionary.ASpellDic[ID].TriggerTarget;
        InitExecute(executeListStr);
        IconName = GameDictionary.ASpellDic[ID].IconName;
        Type = (SpellType)Enum.Parse(typeof(SpellType), GameDictionary.ASpellDic[ID].Type);
        InSpareTime = GameDictionary.ASpellDic[ID].InSpareTime;
    }

    /// <summary>
    /// 施法CD時間流逝
    /// </summary>
    public override void TimePass()
    {
        if (FinishCD)
            return;
        base.TimePass();
        if (CDTimer <= 0)
        {
            FinishCD = true;
            CDTimer = 0;
        }
        UpdateCDRatio();
    }
    /// <summary>
    /// 執行施法
    /// </summary>
    public override void Execute()
    {
        //如果不是遭遇戰鬥時只能施放特定類法術
        if (!FightScene.Fight)
            if (!InSpareTime)
                return;
        //CD還沒到就返回
        if (!FinishCD)
            return;
        //精神不足就返回
        if (ConsumeVitality > Self.CurVP)
            return;
        //消耗精神
        Self.ConsumeVitality(ConsumeVitality);
        base.Execute();
        FinishCD = false;
        UpdateCDRatio();
    }
    /// <summary>
    /// 更新施法冷卻百分比與施法冷卻圖像
    /// </summary>
    void UpdateCDRatio()
    {
        //更新冷卻百分比
        CDRaito = CDTimer / CD;
        //更新施法冷卻圖像
        CharaDataUI.UpdateSpellCD(Self.Index);
    }
}
