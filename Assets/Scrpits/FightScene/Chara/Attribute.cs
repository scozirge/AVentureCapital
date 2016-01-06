using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract partial class Chara : MonoBehaviour
{
    //////////////////////////物件//////////////////
    protected Transform MyTransform;
    //動作
    Animator Ani_Chara;
    //圖像
    SpriteRenderer SR_Chara;
    //初始化屬性字典
    protected Dictionary<string, string> AttrsDic;
    ////////////////////////狀態//////////////////////////
    public int ID { get; private set; }
    //名稱
    public string Name { get; protected set; }
    //腳色索引，代表第幾隻腳色，玩家腳色=0~2，敵方腳色=0~2
    public byte Index { get; protected set; }
    //腳色絕對索引，代表哪一隻腳色0~5依序為玩家到敵方腳色1~腳色3
    public byte AbsIndex { get; protected set; }
    //腳色類型
    public CharaType TheCharaType { get; protected set; }
    //最大血量
    public int MaxHP { get; protected set; }
    //目前血量
    public int CurHP { get; protected set; }
    //血量健康率 CurHP/MaxHP
    public float HealthRatio { get; private set; }
    //是否存活
    public bool IsAlive { get; protected set; }
    //狀態效果清單
    public List<BufferEntity> BufferList { get; protected set; }
    ///////////////////////主屬性////////////////////////
    //體質
    public int Constitution { get; protected set; }
    public int EquipConstitution { get; protected set; }
    public int BufferConstitution { get; protected set; }
    public int FinalConstitution()
    {
        return Constitution + EquipConstitution + BufferConstitution;
    }
    //心智
    public int Mind { get; protected set; }
    public int EquipMind { get; protected set; }
    public int BufferMind { get; protected set; }
    public int FinalMind()
    {
        return Mind + EquipMind + BufferMind;
    }
    //力量
    public int Strength { get; protected set; }
    public int EquipStrength { get; protected set; }
    public int BufferStrength { get; protected set; }
    public int FinalStrength()
    {
        return Strength + EquipStrength + BufferStrength;
    }
    //信仰
    public int Faith { get; protected set; }
    public int EquipFaith { get; protected set; }
    public int BufferFaith { get; protected set; }
    public int FinalFaith()
    {
        return Faith + EquipFaith + BufferFaith;
    }
    //警戒
    public int Alert { get; protected set; }
    public int EquipAlert { get; protected set; }
    public int BufferAlert { get; protected set; }
    public int FinalAlert()
    {
        return Alert + EquipAlert + BufferAlert;
    }
    //意志
    public int Will { get; protected set; }
    public int EquipWill { get; protected set; }
    public int BufferWill { get; protected set; }
    public int FinalWill()
    {
        return Will + EquipWill + BufferWill;
    }
    //技巧
    public int Skill { get; protected set; }
    public int EquipSkill { get; protected set; }
    public int BufferSkill { get; protected set; }
    public int FinalSkill()
    {
        return Skill + EquipSkill + BufferSkill;
    }
    //反應
    public int Agile { get; protected set; }
    public int EquipAgile { get; protected set; }
    public int BufferAgile { get; protected set; }
    public int FinalAgile()
    {
        return Agile + EquipAgile + BufferAgile;
    }
    //爆發
    public int Power { get; protected set; }
    public int EquipPower { get; protected set; }
    public int BufferPower { get; protected set; }
    public int FinalPower()
    {
        return Power + EquipPower + BufferPower;
    }
    ////////////////////////防禦//////////////////////////
    //物防值
    public int PDefense { get; protected set; }
    //魔防值
    public int MDefense { get; protected set; }
    //裝備物防值
    public int EquipPDefense { get; protected set; }
    //裝備魔防值
    public int EquipMDefense { get; protected set; }
    //裝備物抗率
    public float EquipPResistanceRate { get; protected set; }
    //裝備魔抗率
    public float EquipMResistanceRate { get; protected set; }
    //狀態影響物防值
    public float BufferPDefense { get; protected set; }
    //狀態影響魔防值
    public float BufferMDefense { get; protected set; }
    //狀態影響物抗率
    public float BufferPResistanceRate { get; protected set; }
    //狀態影響魔抗率
    public float BufferMResistanceRate { get; protected set; }
    ////////////////////////攻擊//////////////////////////
    //物攻值
    public int PAttack { get; protected set; }
    //魔攻值
    public int MAttack { get; protected set; }
    //裝備物攻值
    public int EquipPAttack { get; protected set; }
    //裝備魔攻值
    public int EquipMAttack { get; protected set; }
    //裝備物傷率
    public float EquipPLethalityRate { get; protected set; }
    //裝備魔傷率
    public float EquipMLethalityRate { get; protected set; }
    //狀態影響物攻值
    public float BufferPAttack { get; protected set; }
    //狀態影響魔攻值
    public float BufferMAttack { get; protected set; }
    //狀態影響物傷率
    public float BufferPLethalityRate { get; protected set; }
    //狀態影響魔傷率
    public float BufferMLethalityRate { get; protected set; }
    //////////////////////其他//////////////////////////
    //可負擔的重量
    public int LiftPower { get; protected set; }
    //負重
    public int Weight { get; protected set; }
    //裝備負重
    public int EquipWeight { get; protected set; }
    //狀態負重
    public int BufferWeight { get; protected set; }
    //負重百分比
    public float WeightRatio { get; protected set; }
    //中狀態的效果清單
    ////////////////////////施法//////////////////////////
    //施法清單
    public List<PassiveSpell> PassiveSpellList { get; protected set; }
    //腳色初始位置
    protected Vector2[] DefaultPos { get; set; }
    //腳色初始縮放
    protected Vector2[] DefaultScale { get; set; }
    //所在位置的縮放
    protected Vector2[] PosScale { get; set; }
    //施法位置0~5依序為玩家腳色1~3~敵方腳色1~3
    protected Vector2[] SpellPos { get; set; }
}
