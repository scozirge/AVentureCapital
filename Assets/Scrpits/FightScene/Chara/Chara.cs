﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract partial class Chara : MonoBehaviour
{
    protected Transform MyTransform;
    //動作列表
    public List<Action> ActionList { get; protected set; }
    /// <summary>
    /// 起始設定
    /// </summary>
    public virtual void StartSet(Dictionary<string, string> _attrDic, List<Action> _actionList)
    {
        MyTransform = transform;
        Name = _attrDic["Name"];
        MaxHP = int.Parse(_attrDic["MaxHP"]);
        CurHP = int.Parse(_attrDic["CurHP"]);
        MaxMind = int.Parse(_attrDic["MaxMind"]);
        CurMind = int.Parse(_attrDic["CurMind"]);
        BaseDefense = int.Parse(_attrDic["BaseDefense"]);
        EquipDefense = int.Parse(_attrDic["EquipDefense"]);
        EquipDefenseOdds = float.Parse(_attrDic["EquipDefenseOdds"]);
        BaseAttack = int.Parse(_attrDic["BaseAttack"]);
        EquipAttack = int.Parse(_attrDic["EquipAttack"]);
        ActionList = _actionList;
        IsAlive = true;
        //初始設定動作
        SetMotion();
    }
    /// <summary>
    /// 傳入傷害量，造成傷害
    /// </summary>
    public virtual void GetDamge(int _damage)
    {
        //不可對死者進行攻擊
        if (!IsAlive)
            return;
        //傷害不小於等於0
        if (_damage <= 0)
            return;
        //傷害最大等於剩餘血量
        if (CurHP - _damage < 0)
            _damage = CurHP;
        CurHP -= _damage;
        AliveCheck();
    }
    /// <summary>
    /// 傳入治癒量，恢復血量
    /// </summary>
    public virtual void GetCure(int _cure)
    {
        //不可對死者進行治癒
        if (!IsAlive)
            return;
        //治癒量不可小於等於0
        if (_cure <= 0)
            return;
        //治癒量大於損失的血量
        if (CurHP + _cure > MaxHP)
            _cure = MaxHP - CurHP;
        CurHP += _cure;
    }
    /// <summary>
    /// 檢查是否還存活
    /// </summary>
    protected virtual void AliveCheck()
    {
        if (CurHP <= 0)
        {
            Debug.Log(string.Format("{0}死亡", Name));
            IsAlive = false;
        }
    }
    public virtual void TimePass()
    {
        for (int i = 0; i < ActionList.Count; i++)
        {
            if (ActionList[i].ExecuteCheck())
            {
                //執行動作
                ActionList[i].Execute();
                //播放動作
                PlayMotion(Motion.Action);
            }
        }
    }
}
