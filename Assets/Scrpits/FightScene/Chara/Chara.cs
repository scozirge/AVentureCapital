using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract partial class Chara : MonoBehaviour
{
    protected Transform MyTransform;
    //目標
    public Chara Target { get; protected set; }
    //動作列表
    public List<Action> ActionList { get; private set; }
    /// <summary>
    /// 起始設定
    /// </summary>
    public virtual void StartSet()
    {
        MyTransform = transform;
        //初始設定動作
        SetMotion();
        Name = "腳色";
        MaxHP = 100;
        CurHP = 100;
        MaxMind = 100;
        CurMind = 100;
        BaseDefense = 40;
        EquipDefense = 60;
        EquipDefeseOdds = 1.2f;
        BaseAttack = 50;
        EquipAttack = 70;
        IsAlive = true;
        ActionList = new List<Action>();
        Damage dmg = new Damage(ExecuteType.Damage, 1.2f);
        Cure cure = new Cure(ExecuteType.Cure, 10);
        Buffer buffer = new Buffer(ExecuteType.Buffer, 0.1f);
        List<ExecuteCom> executeList = new List<ExecuteCom>();
        executeList.Add(dmg);
        executeList.Add(cure);
        executeList.Add(buffer);
        Action ac = new Action("砍殺", 0.3f, executeList, this, FightScene.EChara);
        ActionList.Add(ac);
        Target = null;
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
            IsAlive = false;
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
