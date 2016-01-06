using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class RoleData
{
    public int ID { get; private set; }
    public string Title { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Constitution { get; protected set; }
    public int Mind { get; protected set; }
    public int Strength { get; protected set; }
    public int Faith { get; protected set; }
    public int Alert { get; protected set; }
    public int Will { get; protected set; }
    public int Skill { get; protected set; }
    public int Agility { get; protected set; }
    public int Health { get; protected set; }
    public int HealthRecover { get; protected set; }
    public int Vitality { get; protected set; }
    public int VitalityRecover { get; protected set; }
    public int PAttack { get; protected set; }
    public int MAttack { get; protected set; }
    public int PDefense { get; protected set; }
    public int MDefense { get; protected set; }
    public int Accuracy { get; protected set; }
    public int Dodge { get; protected set; }
    public int LiftPower { get; protected set; }
    public float Tenacity { get; protected set; }
    public int Talent { get; protected set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, RoleData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Role").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["Role"];
        for (int i = 0; i < items.Count; i++)
        {
            RoleData data = new RoleData(items[i]);
            int id = int.Parse(items[i]["ID"].ToString());
            _dic.Add(id, data);
        }
    }
    RoleData(JsonData _item)
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
                    case "Title":
                        Title = item[key].ToString();
                        break;
                    case "Name":
                        Name = item[key].ToString();
                        break;
                    case "Description":
                        Description = item[key].ToString();
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
                    case "Agility":
                        Agility = int.Parse(item[key].ToString());
                        break;
                    case "Health":
                        Health = int.Parse(item[key].ToString());
                        break;
                    case "HealthRecover":
                        HealthRecover = int.Parse(item[key].ToString());
                        break;
                    case "Vitality":
                        Vitality = int.Parse(item[key].ToString());
                        break;
                    case "VitalityRecover":
                        VitalityRecover = int.Parse(item[key].ToString());
                        break;
                    case "PAttack":
                        PAttack = int.Parse(item[key].ToString());
                        break;
                    case "MAttack":
                        MAttack = int.Parse(item[key].ToString());
                        break;
                    case "PDefense":
                        PDefense = int.Parse(item[key].ToString());
                        break;
                    case "MDefense":
                        MDefense = int.Parse(item[key].ToString());
                        break;
                    case "Accuracy":
                        Accuracy = int.Parse(item[key].ToString());
                        break;
                    case "Dodge":
                        Dodge = int.Parse(item[key].ToString());
                        break;
                    case "LiftPower":
                        LiftPower = int.Parse(item[key].ToString());
                        break;
                    case "Tencity":
                        Tenacity = float.Parse(item[key].ToString());
                        break;
                    case "Talent":
                        Talent = int.Parse(item[key].ToString());
                        break;
                    default:
                        Debug.LogWarning(string.Format("Role表有不明屬性:{0}", key));
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

