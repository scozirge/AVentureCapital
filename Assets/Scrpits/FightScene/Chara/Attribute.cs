﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract partial class Chara : MonoBehaviour
{
    //名稱
    public string Name { get; protected set; }
    //腳色類型
    public CharaType TheCharaType { get; protected set; }
    ////////////////////////狀態//////////////////////////
    //最大血量
    public int MaxHP { get; protected set; }
    //目前血量
    public int CurHP { get; protected set; }
    //最大精神
    public int MaxMind { get; protected set; }
    //目前精神
    public int CurMind { get; protected set; }
    //是否存活
    public bool IsAlive { get; protected set; }
    ////////////////////////防禦//////////////////////////
    //基本防禦值
    public int BaseDefense { get; protected set; }
    //裝備防禦值
    public int EquipDefense { get; protected set; }
    //狀態影響防禦加值
    public float BufferDefenseValue { get; protected set; }
    //狀態影響防禦比例
    public float BufferDefenseRate { get; protected set; }
    //裝備抵抗強度
    public float EquipDefenseRate { get; protected set; }
    ////////////////////////攻擊//////////////////////////
    //基本攻擊值
    public int BaseAttack { get; protected set; }
    //裝備攻擊值
    public int EquipAttack { get; protected set; }
    //狀態影響攻擊加值
    public float BufferAttackVlue { get; protected set; }
    //狀態影響攻擊比例
    public float BufferAttackRate { get; protected set; }
    //中狀態的效果清單
    public List<BufferEntity> BufferList { get; protected set; }
}
