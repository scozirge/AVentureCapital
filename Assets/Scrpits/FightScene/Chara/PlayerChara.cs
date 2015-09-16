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
}
