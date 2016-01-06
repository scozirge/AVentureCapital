using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class EnemyChara : Chara
{
    /// <summary>
    /// 起始設定
    /// </summary>
    public override void IniChara(byte _index, Dictionary<string, string> _attrDic)
    {
        base.IniChara(_index, _attrDic);
        AbsIndex = (byte)(_index + 3);
        TheCharaType = CharaType.Enemy;
        PlayMotion(Motion.Attack, 0);//設定為預設動作
        SetPassiveSpell();//設定敵人被動施法
        //將此敵方腳色加入字典
        FightScene.ECharaDic.Add(Index.ToString(), this);
        FightScene.ECharaList.Add(this);
        FightScene.EAliveCharaList.Add(this);
    }
}
