using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class EnemyChara : Chara
{
    /// <summary>
    /// 初始化施法
    /// </summary>
    protected void SetPassiveSpell()
    {
        string spellListStr = AttrsDic["SpellList"];
        string[] spellIDStr = spellListStr.Split(',');
        for (int i = 0; i < spellIDStr.Length; i++)
        {
            int spellID = int.Parse(spellIDStr[i]);
            if (spellID == 0)
                continue;
            PassiveSpell spell = new PassiveSpell(spellID, this);
            PassiveSpellList.Add(spell);
        }
    }
    /*
    /// <summary>
    /// 初始化施法
    /// </summary>
    protected override void InitSpell()
    {
        base.InitSpell();
        PassiveSpellList = new List<PassiveSpell>();
        string spellListStr = AttrsDic["SpellList"];
        string[] spellIDStr = spellListStr.Split(',');
        for (int i = 0; i < spellIDStr.Length; i++)
        {
            int spellID = int.Parse(spellIDStr[i]);
            if (spellID == 0)
                continue;
            PassiveSpell spell = new PassiveSpell(spellID, this);
            PassiveSpellList.Add(spell);
        }
    }
    */
}
