using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class PlayerChara : Chara
{
    /// <summary>
    /// 起始設定
    /// </summary>
    public override void IniChara(int _index, Dictionary<string, string> _attrDic)
    {
        base.IniChara(_index, _attrDic);
        TheCharaType = CharaType.Player;
    }
    /// <summary>
    /// 初始化主動施法
    /// </summary>
    void InitActivitySpell()
    {
        ActivitySpellList = new List<Spell>();
        string activitySpellListStr = AttrsDic["ActivitySpellList"];
        string[] spellIDStr = activitySpellListStr.Split(',');
        for (int i = 0; i < spellIDStr.Length; i++)
        {
            int spellID = int.Parse(spellIDStr[i]);
            if (spellID == 0)
                continue;
            Spell spell = new Spell(spellID, this);
            ActivitySpellList.Add(spell);
        }
    }
    /// <summary>
    /// 對角色造成物理傷害，傳入[造成的傷害][是否在ICON顯示效果動畫]
    /// </summary>
    public override void ReceivePhysicalDamge(int _damage, bool _showIconAni, HitTextType _hitTextType)
    {
        base.ReceivePhysicalDamge(_damage, _showIconAni, _hitTextType);
        //是否在Icon顯示腳色被擊中效果
        if (_showIconAni)
            CharaDataUI.ShowDamageAni(Index);
    }
    /// <summary>
    /// 對角色造成治癒，傳入[造成的治癒][是否在ICON顯示效果動畫]
    /// </summary>
    public override void ReceiveCure(int _cure, bool _showIconAni, HitTextType _hitTextType)
    {
        base.ReceiveCure(_cure, _showIconAni, _hitTextType);
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
}
