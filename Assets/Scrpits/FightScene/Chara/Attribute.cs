using UnityEngine;
using System.Collections;

public abstract partial class Chara : MonoBehaviour
{
    //名稱
    public string Name { get; protected set; }
    //最大血量
    public int MaxHP { get; protected set; }
    //目前血量
    public int CurHP { get; protected set; }
    //最大精神
    public int MaxMind { get; protected set; }
    //目前精神
    public int CurMind { get; protected set; }
    //基本防禦值
    public int BaseDefense { get; protected set; }
    //裝備防禦值
    public int EquipDefense { get; protected set; }
    //裝備抵抗強度
    public float EquipDefeseOdds { get; protected set; }
    //基本攻擊值
    public int BaseAttack { get; protected set; }
    //裝備攻擊值
    public int EquipAttack { get; protected set; }
    //是否存活
    public bool IsAlive { get; protected set; }
}
