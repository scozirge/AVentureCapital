using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class PlayerChara : Chara
{
    /*
    /// <summary>
    /// 初始化玩家施法
    /// </summary>
    protected override void InitSpell()
    {
        base.InitSpell();
        //初始化主動施法
        InitActivitySpell();
    }
    */
    /// <summary>
    /// 初始化主動施法
    /// </summary>
    void InitActivitySpell()
    {
        ActivitySpells = new ActivitySpell[2];
        string activitySpellListStr = AttrsDic["ActivitySpellList"];
        string[] spellIDStr = activitySpellListStr.Split(',');
        for (int i = 0; i < spellIDStr.Length; i++)
        {
            if (i > 2)
            {
                Debug.LogWarning("腳色有超過2招主動技能");
                break;
            }
            int spellID = int.Parse(spellIDStr[i]);
            ActivitySpell spell = new ActivitySpell(spellID, this);
            ActivitySpells[i] = spell;
            ASpellNum++;
        }
    }
    /// <summary>
    /// 主動施法時間流逝，回傳true代表
    /// </summary>
    public void ActivitySpellTimePass()
    {
        //如果腳色死亡返回true，代表腳色沒有多次施法
        if (!IsAlive)
            return;
        //計算要施法的次數
        for (int i = 0; i < ActivitySpells.Length; i++)
        {
            if (ActivitySpells[i] != null)
                ActivitySpells[i].TimePass();
        }
    }
}
