using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public abstract class EquipmentData
{
    public int ID { get; protected set; }
    public int Level { get; protected set; }
    public string Name { get; protected set; }
    public int Weight { get; protected set; }
    public int Constitution { get; protected set; }
    public int Mind { get; protected set; }
    public int Strength { get; protected set; }
    public int Faith { get; protected set; }
    public int Alert { get; protected set; }
    public int Will { get; protected set; }
    public int Skill { get; protected set; }
    public int Agile { get; protected set; }
    public int Power { get; protected set; }
    public int PAttack { get; protected set; }
    public int MAttack { get; protected set; }
    public float PLethalityRate { get; protected set; }
    public float MLethalityRate { get; protected set; }
    public int PDefense { get; protected set; }
    public int MDefense { get; protected set; }
    public float PResistanceRate { get; protected set; }
    public float MResistanceRate { get; protected set; }
    public int Accuracy { get; protected set; }
    public int Dodge { get; protected set; }
    public int Tenacity { get; protected set; }
    protected EquipmentData(JsonData _item)
    {
        try
        {
            JsonData item = _item;
            foreach (string key in item.Keys)
            {
                switch (key)
                {
                    case "ID":
                        ID = int.Parse(item[key].ToString());
                        break;
                    case "Level":
                        Level = int.Parse(item[key].ToString());
                        break;
                    case "Name":
                        Name = item[key].ToString();
                        break;
                    case "Weight":
                        Weight = int.Parse(item[key].ToString());
                        break;
                    case "Constitution":
                        Constitution = int.Parse(item[key].ToString());
                        break;
                    case "Mind":
                        Mind = int.Parse(item[key].ToString());
                        break;
                    case "Strength":
                        Strength = int.Parse(item[key].ToString());
                        break;
                    case "Faith":
                        Faith = int.Parse(item[key].ToString());
                        break;
                    case "Alert":
                        Alert = int.Parse(item[key].ToString());
                        break;
                    case "Will":
                        Will = int.Parse(item[key].ToString());
                        break;
                    case "Skill":
                        Skill = int.Parse(item[key].ToString());
                        break;
                    case "Agile":
                        Agile = int.Parse(item[key].ToString());
                        break;
                    case "Power":
                        Power = int.Parse(item[key].ToString());
                        break;
                    case "PAttack":
                        PAttack = int.Parse(item[key].ToString());
                        break;
                    case "MAttack":
                        PAttack = int.Parse(item[key].ToString());
                        break;
                    case "PLethalityRate":
                        PLethalityRate = float.Parse(item[key].ToString());
                        break;
                    case "MLethalityRate":
                        MLethalityRate = float.Parse(item[key].ToString());
                        break;
                    case "PDefense":
                        PDefense = int.Parse(item[key].ToString());
                        break;
                    case "MDefense":
                        PDefense = int.Parse(item[key].ToString());
                        break;
                    case "PResistanceRate":
                        PResistanceRate = float.Parse(item[key].ToString());
                        break;
                    case "MResistanceRate":
                        MResistanceRate = float.Parse(item[key].ToString());
                        break;
                    case "Accuracy":
                        Accuracy = int.Parse(item[key].ToString());
                        break;
                    case "Dodge":
                        Dodge = int.Parse(item[key].ToString());
                        break;
                    case "Tenacity":
                        Tenacity = int.Parse(item[key].ToString());
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
