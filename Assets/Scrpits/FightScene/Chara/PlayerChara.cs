using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerChara : Chara
{
    /// <summary>
    /// 起始設定
    /// </summary>
    public override void IniChara(int _index, Dictionary<string, string> _attrDic, List<Spell> _actionList)
    {
        base.IniChara(_index, _attrDic, _actionList);
        TheCharaType = CharaType.Player;
    }
    /// <summary>
    /// 對角色造成傷害，傳入[造成的傷害][是否在ICON顯示被擊中效果]
    /// </summary>
    public override void ReceiveDamge(int _damage, bool _iconHit)
    {
        base.ReceiveDamge(_damage, _iconHit);
        //是否在Icon顯示腳色被擊中效果
        if (_iconHit)
            CharaDataUI.Hit(Index);
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
