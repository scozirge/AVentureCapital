using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract partial class Chara : MonoBehaviour
{
    /// <summary>
    /// 起始設定
    /// </summary>
    public virtual void IniChara(int _index, Dictionary<string, string> _attrsDic)
    {
        AttrsDic = _attrsDic;
        MyTransform = transform;
        Name = AttrsDic["Name"];
        Index = _index;
        //狀態
        MaxHP = int.Parse(AttrsDic["MaxHP"]);
        CurHP = int.Parse(AttrsDic["CurHP"]);
        UpdateHealthRatio();
        IsAlive = true;
        //防禦
        BaseDefense = int.Parse(AttrsDic["BaseDefense"]);
        EquipDefense = int.Parse(AttrsDic["EquipDefense"]);
        BufferDefenseValue = 0;
        BufferDefenseRate = 1;
        EquipDefenseRate = float.Parse(AttrsDic["EquipDefenseRate"]);
        //攻擊
        BaseAttack = int.Parse(AttrsDic["BaseAttack"]);
        EquipAttack = int.Parse(AttrsDic["EquipAttack"]);
        BufferAttackVlue = 0;
        BufferAttackRate = 1;
        //初始化Buffer
        IniBuffer();
        //初始化動作
        IniMotion();
        //初始化施法列表
        InitSpell();
    }
    /// <summary>
    /// 初始化技能
    /// </summary>
    protected virtual void InitSpell()
    {
        SpellList = new List<Spell>();
        string spellListStr = AttrsDic["SpellList"];
        string[] spellIDStr = spellListStr.Split(',');
        for (int i = 0; i < spellIDStr.Length;i++ )
        {
            int spellID = int.Parse(spellIDStr[i]);
            if (spellID == 0)
                continue;
            Spell spell = new Spell(spellID, this);
            SpellList.Add(spell);
        }
    }
    /// <summary>
    /// 對角色造成物理傷害，傳入[造成的傷害][是否在ICON顯示效果動畫]
    /// </summary>
    public virtual void ReceivePhysicalDamge(int _damage, bool _showIconAni, HitTextType _hitTextType)
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
        HitTextController.ShowHitText(this, _damage, _hitTextType);
        UpdateHealthRatio();
        //更新腳色介面
        CharaDataUI.UpdateData(Index);
        //檢查是否存活
        AliveCheck();
    }
    /// <summary>
    /// 對角色造成治癒，傳入[造成的治癒][是否在ICON顯示效果動畫]
    /// </summary>
    public virtual void ReceiveCure(int _cure, bool _showIconAni, HitTextType _hitTextType)
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
        UpdateHealthRatio();
        HitTextController.ShowHitText(this, _cure, _hitTextType);
        //更新腳色介面
        CharaDataUI.UpdateData(Index);
    }
    /// <summary>
    /// 更新血量健康率
    /// </summary>
    protected void UpdateHealthRatio()
    {
        HealthRatio = (float)((float)CurHP / (float)MaxHP);
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
        //狀態觸發判定
        BufferCheck();
        //施法判定
        SpellCheck();
    }
    /// <summary>
    /// 狀態觸發判定
    /// </summary>
    protected virtual void BufferCheck()
    {
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
    }
    /// <summary>
    /// 施法判定
    /// </summary>
    protected virtual void SpellCheck()
    {
        //施法
        for (int i = 0; i < SpellList.Count; i++)
        {
            SpellList[i].ExecuteCheck();
        }
    }
}
