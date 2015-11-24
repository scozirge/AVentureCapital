using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class PlayerChara : Chara
{
    ////////////////////////狀態//////////////////////////
    //最大精神
    public int MaxVP { get; protected set; }
    //目前精神
    public int CurVP { get; protected set; }
    //精神健康率 CurVP/MaxVP
    public float VitalityRatio { get; private set; }
    ////////////////////////攻擊//////////////////////////
    ///////////////////////施法/////////////////////////
    //主動施法列表
    public byte ASpellNum { get; private set; }
    public ActivitySpell[] ActivitySpells { get; private set; }
    ////////////////////////防禦//////////////////////////
    //////////////////////////////////其他//////////////////////
}
