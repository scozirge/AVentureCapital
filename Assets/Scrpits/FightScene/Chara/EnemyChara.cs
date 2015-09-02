using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyChara : Chara
{
    /// <summary>
    /// 起始設定
    /// </summary>
    public override void IniChara(Dictionary<string, string> _attrDic, List<Sell> _actionList)
    {
        base.IniChara(_attrDic, _actionList);
        TheCharaType = CharaType.Enemy;
    }
}
