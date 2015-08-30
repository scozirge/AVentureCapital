using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyChara : Chara
{
    /// <summary>
    /// 起始設定
    /// </summary>
    public override void StartSet(Dictionary<string, string> _attrDic, List<Action> _actionList)
    {
        base.StartSet(_attrDic, _actionList);
        TheCharaType = CharaType.Enemy;
    }
}
