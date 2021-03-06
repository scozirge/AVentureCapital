﻿using UnityEngine;
using System.Collections;

public class Damage : ExecuteCom
{
    // 執行元件類型
    public ExecuteType ExecuteComType { get; protected set; }
    //物攻加值
    public int PAttack { get; protected set; }
    //物傷乘值
    public float PLethalityRate { get; protected set; }
    //魔攻加值
    public int MAttack { get; protected set; }
    //魔傷乘值
    public float MLethalityRate { get; protected set; }
    //絕對傷害
    public int AbsoluteDamage { get; protected set; }
    //造成的實際傷害
    public int TrueDamage { get; protected set; }
    //效果觸發機率
    public float Probability { get; protected set; }
    //延遲顯示扣血
    public float ShowDelay { get; private set; }
    /// <summary>
    /// 初始化施法的傷害效果
    /// </summary>
    public Damage(int _damageID, Chara _self)
        : base(_damageID, _self)
    {
        ExecuteComType = ExecuteType.Damage;
        Probability = GameDictionary.DamageDic[ID].Probability;
        ShowDelay = GameDictionary.DamageDic[ID].ShowDelay;
        PAttack = GameDictionary.DamageDic[ID].PAttack;
        PLethalityRate = GameDictionary.DamageDic[ID].PLethalityRate;
        MAttack = GameDictionary.DamageDic[ID].MAttack;
        MLethalityRate = GameDictionary.DamageDic[ID].MLethalityRate;
        AbsoluteDamage = GameDictionary.DamageDic[ID].AbsoluteDamage;
    }
    /// <summary>
    /// 用於腳色施法執行傷害效果時，傳入目標，對目標造成傷害
    /// </summary>
    public override void Execute(Chara _target)
    {
        base.Execute(_target);
        //取得實際傷害量
        TrueDamage = GetDamage(_target);
        Debug.Log(string.Format("{0}對{1}造成{2}點{3}", Self.Name, _target.Name, TrueDamage, ExecuteComType));//ex:勇者施放砍殺大惡魔造成46點傷害
        _target.ReceivePhysicalDamge(TrueDamage, true, HitTextType.Hit, ShowDelay);
    }
    /// <summary>
    /// 取得傷害
    /// </summary>
    protected virtual int GetDamage(Chara _target)
    {
        ///////////////////////////////物理傷害運算////////////////////////////////
        int pDamage = 0;
        //物理殺傷力= (腳色物攻值+裝備物攻值+效果物攻值+技能物攻值) *(效果物傷乘值) * (技能物傷乘值)
        int pLethality = (int)((Self.PAttack + Self.EquipPAttack + Self.BufferPAttack + PAttack) * (Self.BufferPLethalityRate) * (PLethalityRate) * (Self.EquipPLethalityRate));
        //物抗力=(腳色防禦值+裝備防禦值+效果防禦加值) *(效果防禦乘值)*(裝備抵抗乘值)
        int pResistance = (int)((_target.PDefense + _target.EquipPDefense + _target.BufferPDefense) * _target.BufferPResistanceRate * _target.EquipPResistanceRate);
        //物理傷害值=(物理殺傷力*100)/(100+物抗力)
        pDamage = (int)((100 * pLethality) / (100 + pResistance));
        ///////////////////////////////魔法傷害運算////////////////////////////////
        int mDamage = 0;
        //////////////////////////////總傷害運算//////////////////////////////////
        //總傷害值=(物理傷害值+魔法傷害值)*(裝備傷害乘值)*(效果傷害乘值)+(絕對傷害值)
        int damage = (pDamage + mDamage) + (AbsoluteDamage);
        return damage;
    }
}
