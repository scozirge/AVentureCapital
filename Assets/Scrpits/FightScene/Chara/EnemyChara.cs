using UnityEngine;
using System.Collections;

public class EnemyChara : Chara
{
    /// <summary>
    /// 起始設定
    /// </summary>
    public override void StartSet()
    {
        base.StartSet();
        Name = "敵方腳色";
        int rand = Random.Range(0, FightScene.PCharaList.Count);
        Target = FightScene.PCharaList[rand];
    }
}
