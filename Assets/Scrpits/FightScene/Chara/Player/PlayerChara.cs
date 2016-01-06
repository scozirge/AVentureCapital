using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class PlayerChara : Chara
{
    /// <summary>
    /// 起始設定
    /// </summary>
    public override void IniChara(byte _index, Dictionary<string, string> _attrDic)
    {
        base.IniChara(_index, _attrDic);
        AbsIndex = _index;
        TheCharaType = CharaType.Player;
        MaxVP = int.Parse(AttrsDic["MaxVP"]);
        CurVP = int.Parse(AttrsDic["CurVP"]);
        Strength = int.Parse(AttrsDic["Strength"]);
        Agile = int.Parse(AttrsDic["Agile"]);
        UpdateVitalityRatio();
        //初始化裝備
        InitEquipment();
        //初始化主動施法
        InitActivitySpell();
        //將此玩家腳色加入字典
        FightScene.PCharaDic.Add(Index.ToString(), this);
        FightScene.PCharaList.Add(this);
        FightScene.PAliveCharaList.Add(this);
    }
    /// <summary>
    /// 對角色造成物理傷害，傳入[造成的傷害][是否在ICON顯示效果動畫]
    /// </summary>
    public override void ReceivePhysicalDamge(int _damage, bool _showIconAni, HitTextType _hitTextType, float _showDelay)
    {
        base.ReceivePhysicalDamge(_damage, _showIconAni, _hitTextType, _showDelay);
        //是否在Icon顯示腳色被擊中效果
        if (_showIconAni)
            CharaDataUI.ShowDamageAni(Index);
    }
    /// <summary>
    /// 對角色造成治癒，傳入[造成的治癒][是否在ICON顯示效果動畫]
    /// </summary>
    public override void ReceiveCure(int _cure, bool _showIconAni, HitTextType _hitTextType, float _showDelay)
    {
        base.ReceiveCure(_cure, _showIconAni, _hitTextType, _showDelay);
        if (_showIconAni)
            CharaDataUI.ShowHealingHealthAni(Index);
    }
    /// <summary>
    /// 檢查是否還存活
    /// </summary>
    protected override void AliveCheck()
    {
        base.AliveCheck();
        //如果腳色死亡就執行死亡IconUI
        if (!IsAlive)
            CharaDataUI.Dead(Index);
    }
    /// <summary>
    /// 消耗精神，傳入[消耗的精神][是否在ICON顯示效果動畫]
    /// </summary>
    public void ConsumeVitality(int _vitality)
    {
        //死者不會消耗精神
        if (!IsAlive)
            return;
        //消耗量不可小於等於0
        if (_vitality <= 0)
            return;
        //消耗最大等於剩餘精神
        if (CurVP - _vitality < 0)
            _vitality = CurVP;
        CurVP -= _vitality;
        UpdateVitalityRatio();
        //更新腳色介面
        CharaDataUI.UpdateVitality(Index);
    }
    /// <summary>
    /// 更新精神健康率
    /// </summary>
    protected void UpdateVitalityRatio()
    {
        VitalityRatio = (float)((float)CurVP / (float)MaxVP);
    }
}
