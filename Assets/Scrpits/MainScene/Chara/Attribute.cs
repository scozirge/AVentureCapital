using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class MainChara
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
    //腳色
    RoleData Role;
    //稱號
    public string Title
    {
        get { return Role.Title; }
        private set { return; }
    }
    //名稱
    private string name;
    public string Name
    {
        get { return Role.Name; }
        private set { return; }
    }
    //腳色索引，代表第幾隻腳色，玩家腳色=0~2
    public byte Index { get; protected set; }
    //最大血量
    public int MaxHealth
    {
        get
        {
            return
              Role.Health + EquipHealth + BufferHP +
              Constitution * GameDictionary.MainAttributeDic[MainAttribute.Constitution].Health;
        }
        private set { return; }
    }
    public int EquipHealth { get; private set; }
    public int BufferHP { get; private set; }
    //目前血量
    public int CurHealth { get; protected set; }
    //血量百分比
    public float HealthRatio
    {
        get { return (float)((float)CurHealth / (float)MaxHealth); }
        private set { return; }
    }
    //目前精神
    public int CurVitality { get; protected set; }
    //最大精神
    public int MaxVitality
    {
        get
        {
            return
              Role.Health + EquipVitality + BufferVitality +
              Mind * GameDictionary.MainAttributeDic[MainAttribute.Mind].Vitality;
        }
        set { return; }
    }
    public int EquipVitality { get; private set; }
    public int BufferVitality { get; private set; }
    //精神百分比
    public float VitalityRatio
    {
        get { return (float)((float)CurVitality / (float)MaxVitality); }
        private set { return; }
    }
    //等級
    public int Level { get; protected set; }
    //需求經驗值
    public int NeedExp { get { return GameDictionary.LevelDic[Level].NeedExp; } set { return; } }
    //經驗值
    public int CurExp { get; protected set; }
    ///////////////////////主屬性////////////////////////
    //體質
    public int Constitution
    {
        get { return Role.Constitution + GrowConstitution + EquipConstitution + BufferConstitution; }
        private set { return; }
    }
    public int GrowConstitution { get; protected set; }
    public int EquipConstitution { get; protected set; }
    public int BufferConstitution { get; protected set; }
    //心智
    public int Mind
    {
        get { return Role.Mind + GrowMind + EquipMind + BufferMind; }
        private set { return; }
    }
    public int GrowMind { get; private set; }
    public int EquipMind { get; protected set; }
    public int BufferMind { get; protected set; }
    //力量
    public int Strength
    {
        get { return Role.Strength + GrowStrength + BufferStrength; }
        private set { return; }
    }
    public int GrowStrength { get; private set; }
    public int EquipStrength { get; protected set; }
    public int BufferStrength { get; protected set; }
    //信仰
    public int Faith
    {
        get { return Role.Faith + GrowFaith + BufferFaith; }
        private set { return; }
    }
    public int GrowFaith { get; protected set; }
    public int EquipFaith { get; protected set; }
    public int BufferFaith { get; protected set; }
    //警戒
    public int Alert
    {
        get { return Role.Alert + GrowAlert + EquipAlert + BufferAlert; }
        private set { return; }
    }
    public int GrowAlert { get; private set; }
    public int EquipAlert { get; protected set; }
    public int BufferAlert { get; protected set; }
    //意志
    public int Will
    {
        get { return Role.Will + GrowWill + EquipAlert + BufferAlert; }
        private set { return; }
    }
    public int GrowWill { get; private set; }
    public int EquipWill { get; protected set; }
    public int BufferWill { get; protected set; }
    //技巧
    public int Skill
    {
        get { return Role.Skill + GrowSkill + EquipSkill + BufferSkill; }
        private set { return; }
    }
    public int GrowSkill { get; private set; }
    public int EquipSkill { get; protected set; }
    public int BufferSkill { get; protected set; }
    //反應
    public int Agility
    {
        get { return Role.Agility + GrowAgility + EquipAgility + BufferAgility; }
        private set { return; }
    }
    public int GrowAgility { get; private set; }
    public int EquipAgility { get; protected set; }
    public int BufferAgility { get; protected set; }
    public int Point { get; protected set; }
    ////////////////////////防禦//////////////////////////
    //物防值
    public int PDefense
    {
        get
        {
            return Role.PDefense + EquipPDefense + BufferPDefense +
                Alert * GameDictionary.MainAttributeDic[MainAttribute.Alert].PDefense +
                Agility * GameDictionary.MainAttributeDic[MainAttribute.Agility].PDefense;
        }
        private set { return; }
    }
    //裝備物防值
    public int EquipPDefense { get; protected set; }
    //狀態影響物防值
    public int BufferPDefense { get; protected set; }
    //魔防值
    public int MDefense
    {
        get
        {
            return Role.MDefense + EquipMDefense + BufferMDefense +
                Alert * GameDictionary.MainAttributeDic[MainAttribute.Alert].MDefense +
                Agility * GameDictionary.MainAttributeDic[MainAttribute.Agility].MDefense;
        }
        private set { return; }
    }
    //裝備魔防值
    public int EquipMDefense { get; protected set; }
    //狀態影響魔防值
    public int BufferMDefense { get; protected set; }
    ////////////////////////攻擊//////////////////////////
    //物攻值
    public int PAttack
    {
        get
        {
            return Role.PAttack + EquipPAttack + BufferPAttack +
                Strength * GameDictionary.MainAttributeDic[MainAttribute.Strength].PAttack +
                Skill * GameDictionary.MainAttributeDic[MainAttribute.Skill].PAttack;
        }
        private set { return; }
    }
    //裝備物攻值
    public int EquipPAttack { get; protected set; }
    //狀態影響物攻值
    public int BufferPAttack { get; protected set; }
    //魔攻值
    public int MAttack
    {
        get
        {
            return Role.MAttack + EquipMAttack + BufferMAttack +
                Strength * GameDictionary.MainAttributeDic[MainAttribute.Strength].MAttack +
                Skill * GameDictionary.MainAttributeDic[MainAttribute.Skill].MAttack;
        }
        private set { return; }
    }
    //裝備魔攻值
    public int EquipMAttack { get; protected set; }
    //狀態影響魔攻值
    public int BufferMAttack { get; protected set; }
    //////////////////////負重//////////////////////////
    //可負擔的重量
    public int LiftPower
    {
        get { return Role.LiftPower + EquipLiftPower + BufferLiftPower; }
        private set { return; }
    }
    public int EquipLiftPower { get; private set; }
    public int BufferLiftPower { get; private set; }
    //負重
    public int Weight
    {
        get { return EquipWeight + BufferWeight; }
        private set { return; }
    }
    //裝備負重
    public int EquipWeight { get; protected set; }
    //狀態負重
    public int BufferWeight { get; protected set; }
    //負重百分比
    public float WeightRatio
    {
        get { return (float)((float)Weight / (float)LiftPower); }
        private set { return; }
    }
    //////////////////////天賦//////////////////////////
    public TalentData MyTalent;
    //////////////////////武器//////////////////////////
    public WeaponData[] MyWeapons;
    //////////////////////主防具////////////////////////
    public ArmorData MyArmor;
    ///////////////////////副防具////////////////////////
    public ProtectorData[] MyProtectors;
}
