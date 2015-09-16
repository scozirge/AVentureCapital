using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract partial class Chara : MonoBehaviour
{
    protected Transform MyTransform;
    //施法列表
    public List<Spell> ActionList { get; protected set; }
    /// <summary>
    /// 起始設定
    /// </summary>
    public virtual void IniChara(int _index, Dictionary<string, string> _attrDic, List<Spell> _actionList)
    {
        MyTransform = transform;
        Name = _attrDic["Name"];
        Index = _index;
        //狀態
        MaxHP = int.Parse(_attrDic["MaxHP"]);
        CurHP = int.Parse(_attrDic["CurHP"]);
        MaxMind = int.Parse(_attrDic["MaxMind"]);
        CurMind = int.Parse(_attrDic["CurMind"]);
        IsAlive = true;
        //防禦
        BaseDefense = int.Parse(_attrDic["BaseDefense"]);
        EquipDefense = int.Parse(_attrDic["EquipDefense"]);
        BufferDefenseValue = 0;
        BufferDefenseRate = 1;
        EquipDefenseRate = float.Parse(_attrDic["EquipDefenseRate"]);
        //攻擊
        BaseAttack = int.Parse(_attrDic["BaseAttack"]);
        EquipAttack = int.Parse(_attrDic["EquipAttack"]);
        BufferAttackVlue = 0;
        BufferAttackRate = 1;
        //施法
        ActionList = _actionList;
        //初始化Buffer
        IniBuffer();
        //初始化動作
        IniMotion();
    }
    /// <summary>
    /// 傳入傷害量，造成傷害
    /// </summary>
    public virtual void ReceiveDamge(int _damage)
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
    public virtual void ReceiveCure(int _cure)
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
        //腳色死亡
        if (CurHP <= 0)
        {
            Debug.Log(string.Format("{0}死亡", Name));
            IsAlive = false;
            PlayMotion(Motion.Die, 0);
            FightScene.CheckAliveChara();//更新死亡腳色清單
        }
    }
    /// <summary>
    /// 1.時間流逝，代表此腳色有時間元素的屬性都要計算經過時間，例如施法執行、狀態效果的時間
    /// 2.會先觸發狀態效果再進行施法判定
    /// </summary>
    public virtual void TimePass()
    {
        //如果腳色死亡，時間則不再流逝(不會觸發狀態，也不會進行施法)
        if (!IsAlive)
            return;
        //觸發狀態
        List<int> bufferKeys = new List<int>(BufferDic.Keys);
        for (int i = 0; i < bufferKeys.Count; i++)
        {
            for (int j = 0; j < BufferDic[bufferKeys[i]].Count; j++)
            {
                BufferDic[bufferKeys[i]][j].ExecuteCheck();
                //如果在執行ExecuteCheck後發現BufferDic已經不存在ID，代表此狀態在ExecuteCheck中判定時效已過而遭刪除
                //跳出迴圈
                if (!BufferDic.ContainsKey(bufferKeys[i]))
                    break;
            }
        }
        //施法
        for (int i = 0; i < ActionList.Count; i++)
        {
            ActionList[i].ExecuteCheck();
        }

    }
}
