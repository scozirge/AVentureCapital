using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerChara : Chara
{
    //腳色索引，代表第幾隻腳色，玩家腳色=0~2，敵方腳色=0
    public int Index { get; protected set; }
    /// <summary>
    /// 起始設定
    /// </summary>
    public void StartSet(int _index, Dictionary<string, string> _attrDic, List<Sell> _actionList)
    {
        base.IniChara(_attrDic, _actionList);
        Index = _index;
        TheCharaType = CharaType.Player;
    }
}
