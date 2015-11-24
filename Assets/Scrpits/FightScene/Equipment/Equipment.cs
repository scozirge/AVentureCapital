using UnityEngine;
using System.Collections;

public abstract class Equipment
{
    public int ID { get; protected set; }
    public int Level { get; protected set; }
    public string Name { get; protected set; }
    public int Weight { get; protected set; }
    public int PAttack { get; protected set; }
    public int MAttack { get; protected set; }
    public float PLethalityRate { get; protected set; }
    public float MLethalityRate { get; protected set; }
    public int PDefense { get; protected set; }
    public int MDefense { get; protected set; }
    public float PResistanceRate { get; protected set; }
    public float MResistanceRate { get; protected set; }
    public int Constitution { get; protected set; }
    public int Mind { get; protected set; }
    public int Strength { get; protected set; }
    public int Faith { get; protected set; }
    public int Alert { get; protected set; }
    public int Will { get; protected set; }
    public int Skill { get; protected set; }
    public int Agile { get; protected set; }
    public int Power { get; protected set; }
    public int Health { get; protected set; }
    public int HealthRecover { get; protected set; }
    public int Vitality { get; protected set; }
    public int VitalityRecover { get; protected set; }
    public int Accuracy { get; protected set; }
    public int Dodge { get; protected set; }
    public int Tenacity { get; protected set; }
    public EquipmentTYpe Type { get; protected set; }
    public bool IsEquip { get; protected set; }
    /// <summary>
    /// 初始化裝備，傳入裝備ID
    /// </summary>
    public Equipment(int _equipID)
    {
        ID = _equipID;
    }
    /// <summary>
    /// 初始化裝備屬性
    /// </summary>
    protected virtual void InitEquipment(EquipmentData _equipment)
    {
        Level = _equipment.Level;
        Name = _equipment.Name;
        Weight = _equipment.Weight;
        Constitution = _equipment.Constitution;
        Mind = _equipment.Mind;
        Strength = _equipment.Strength;
        Faith = _equipment.Faith;
        Alert = _equipment.Alert;
        Will = _equipment.Will;
        Skill = _equipment.Skill;
        Agile = _equipment.Agile;
        Power = _equipment.Power;
        PAttack = _equipment.PAttack;
        MAttack = _equipment.MAttack;
        PLethalityRate = _equipment.PLethalityRate;
        MLethalityRate = _equipment.MLethalityRate;
        PDefense = _equipment.PDefense;
        MDefense = _equipment.MDefense;
        PResistanceRate = _equipment.PResistanceRate;
        MResistanceRate = _equipment.MResistanceRate;
        Accuracy = _equipment.Accuracy;
        Dodge = _equipment.Dodge;
        Tenacity = _equipment.Tenacity;
    }
    /// <summary>
    /// 裝備此裝備
    /// </summary>
    public virtual bool Equip()
    {
        //不可重複裝備
        if (IsEquip)
        {
            Debug.LogWarning(string.Format("不可重複裝備({0})", Name));
            return false;
        }
        IsEquip = true;
        return true;
    }
    /// <summary>
    /// 脫下此裝備
    /// </summary>
    public virtual bool TakeOff()
    {
        //不可重複裝備
        if (!IsEquip)
        {
            Debug.LogWarning(string.Format("沒穿過此裝備({0})，無法脫下", Name));
            return false;
        }
        IsEquip = false;
        return true;
    }
}
