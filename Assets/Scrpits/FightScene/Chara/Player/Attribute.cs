using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class PlayerChara : Chara
{
    //最大精神
    public int MaxVP { get; protected set; }
    //目前精神
    public int CurVP { get; protected set; }
    //精神健康率 CurVP/MaxVP
    public float VitalityRatio { get; private set; }
    //主動施法列表
    public List<ActivitySpell> ActivitySpellList { get; private set; }
}
