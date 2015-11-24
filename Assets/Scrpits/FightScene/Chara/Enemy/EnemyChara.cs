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
        /*
        SpellList = new List<Spell>();
        Damage dmg = new Damage("砍殺", ExecuteType.Damage, this, 3f);
        List<ExecuteCom> executeList = new List<ExecuteCom>();
        executeList.Add(dmg);
        float rnd = (float)Random.Range(30f, 50f)/10;
        Spell ac = new Spell("砍殺", rnd, executeList, this, true);
        SpellList.Add(ac);     
        */
        AbsIndex = (byte)(_index + 3);
        TheCharaType = CharaType.Enemy;
        SetPassiveSpell();//設定敵人被動施法
    }
}
