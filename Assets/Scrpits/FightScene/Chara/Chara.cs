using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract partial class Chara : MonoBehaviour
{
    /// <summary>
    /// 起始設定
    /// </summary>
    public virtual void IniChara(byte _index, Dictionary<string, string> _attrsDic)
    {
        AttrsDic = _attrsDic;
        MyTransform = transform;
        ID = int.Parse(AttrsDic["ID"]);
        Name = AttrsDic["Name"];
        Index = _index;
        //狀態
        MaxHP = int.Parse(AttrsDic["MaxHP"]);
        CurHP = int.Parse(AttrsDic["CurHP"]);
        UpdateHealthRatio();
        IsAlive = true;
        //防禦
        PDefense = int.Parse(AttrsDic["BaseDefense"]);
        BufferPDefense = 0;
        BufferPResistanceRate = 1;
        //攻擊
        PAttack = int.Parse(AttrsDic["BaseAttack"]);
        EquipPAttack = 0;
        EquipPLethalityRate = 1;
        BufferPAttack = 0;
        BufferPLethalityRate = 1;
        //被動施法
        PassiveSpellList = new List<PassiveSpell>();
        //其他
        LiftPower = int.Parse(AttrsDic["LiftPower"]);
        //更新負重百分比
        UpdateWeightRatio();
        //初始化Buffer
        IniBuffer();
        //初始化動作
        IniMotion();
        //初始化施法列表(施法現在改由裝備去初始化)
        //InitSpell();
    }
    /// <summary>
    /// 對角色造成物理傷害，傳入[造成的傷害][是否在ICON顯示效果動畫]
    /// </summary>
    public virtual void ReceivePhysicalDamge(int _damage, bool _showIconAni, HitTextType _hitTextType, float _showDelay)
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
        HitTextController.ShowHitText(this, _damage, _hitTextType, _showDelay);
        UpdateHealthRatio();
        //更新腳色介面
        CharaDataUI.UpdateHealth(Index);
        //檢查是否存活
        AliveCheck();
    }
    /// <summary>
    /// 對角色造成治癒，傳入[造成的治癒][是否在ICON顯示效果動畫]
    /// </summary>
    public virtual void ReceiveCure(int _cure, bool _showIconAni, HitTextType _hitTextType, float _showDelay)
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
        HitTextController.ShowHitText(this, _cure, _hitTextType, _showDelay);
        //更新腳色介面
        CharaDataUI.UpdateHealth(Index);
    }
    /// <summary>
    /// 更新血量健康率
    /// </summary>
    protected void UpdateHealthRatio()
    {
        HealthRatio = (float)((float)CurHP / (float)MaxHP);
    }
    /// <summary>
    /// 更新負重百分比
    /// </summary>
    protected virtual void UpdateWeightRatio()
    {
        WeightRatio = (float)Weight / (float)LiftPower;
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
}
