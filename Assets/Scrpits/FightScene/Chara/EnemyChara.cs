using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyChara : Chara
{
    /// <summary>
    /// 起始設定
    /// </summary>
    public override void IniChara(int _index, Dictionary<string, string> _attrDic, List<Spell> _actionList)
    {
        base.IniChara(_index, _attrDic, _actionList);
        ActionList = new List<Spell>();
        Damage dmg = new Damage("砍殺", ExecuteType.Damage, this, 3f);
        List<ExecuteCom> executeList = new List<ExecuteCom>();
        executeList.Add(dmg);
        float rnd = (float)Random.Range(30f, 50f)/10;
        Spell ac = new Spell("砍殺", rnd, executeList, this, true);
        ActionList.Add(ac);        
        TheCharaType = CharaType.Enemy;
    }
}
