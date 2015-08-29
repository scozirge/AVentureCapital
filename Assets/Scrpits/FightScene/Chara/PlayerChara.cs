using UnityEngine;
using System.Collections;

public class PlayerChara : Chara
{
    //腳色索引，代表第幾隻腳色，玩家腳色=0~2，敵方腳色=0
    public int Index { get; protected set; }
    /// <summary>
    /// 起始設定
    /// </summary>
    public override void StartSet()
    {
        base.StartSet();
        Name = "玩家腳色";
        Target = FightScene.EChara;
    }
    /// <summary>
    /// 設定索引(0~2)給此腳色，代表第幾隻腳色
    /// </summary>
    public void SetIndex(byte _index)
    {
        Index = _index;
    }
}
