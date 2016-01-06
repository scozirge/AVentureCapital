using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class AccidentEventData
{
    public int ID { get; private set; }
    public int GroupID { get; private set; }
    public string Description { get; private set; }
    public string Process { get; private set; }
    public EventCheckTarget Target { get; private set; }
    public MainAttribute RequireAttribute { get; private set; }
    public Operator OperatorType { get; private set; }
    public int Value { get; private set; }
    public int PassResult { get; private set; }
    public int FailResult { get; private set; }

    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, List<AccidentEventData>> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/AccidentEvent").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData items = jd["AccidentEvent"];
        for (int i = 0; i < items.Count; i++)
        {
            AccidentEventData armorData = new AccidentEventData(items[i]);
            int id = int.Parse(items[i]["ID"].ToString());
            int groupID = int.Parse(items[i]["GroupID"].ToString());
            if (_dic.ContainsKey(groupID))
                _dic[groupID].Add(armorData);
            else
            {
                List<AccidentEventData> eventDataList = new List<AccidentEventData>();
                eventDataList.Add(armorData);
                _dic.Add(groupID, eventDataList);
            }
        }
    }
    AccidentEventData(JsonData _item)
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
                    case "GroupID":
                        GroupID = int.Parse(item[key].ToString());
                        break;
                    case "Description":
                        Description = item[key].ToString();
                        break;
                    case "Target":
                        Target = (EventCheckTarget)Enum.Parse(typeof(EventCheckTarget), item[key].ToString());
                        break;
                    case "Attribute":
                        RequireAttribute = (MainAttribute)Enum.Parse(typeof(MainAttribute), item[key].ToString());
                        break;
                    case "Operator":
                        OperatorType = (Operator)Enum.Parse(typeof(Operator), item[key].ToString());
                        break;
                    case "Value":
                        Value = int.Parse(item[key].ToString());
                        break;
                    case "Process":
                        Process = item[key].ToString();
                        SetProcessText();
                        break;
                    case "PassResult":
                        PassResult = int.Parse(item[key].ToString());
                        break;
                    case "FailResult":
                        FailResult = int.Parse(item[key].ToString());
                        break;
                    default:
                        Debug.LogWarning(string.Format("AccidentEventData表有不明屬性:{0}", key));
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
    /// <summary>
    /// 取得過程文字
    /// </summary>
    public void SetProcessText()
    {
        //設定目標文字
        string targetStr = "";
        switch (Target)
        {
            case EventCheckTarget.All:
                targetStr = "全隊";
                break;
            case EventCheckTarget.Single:
                targetStr = "有隊員";
                break;
            default:
                Debug.LogWarning("讀意外事件表時有錯誤的目標類型");
                break;
        }
        Process = Process.Replace("@@", targetStr);
        //設定屬性文字
        string AttrStr = "";
        AttrStr = GameDictionary.String_AttributeDic[RequireAttribute.ToString()].ZH_TW;
        Process = Process.Replace("##", AttrStr);
        //設定運算元文字
        string operatorStr = "";
        switch (OperatorType)
        {
            case Operator.GreaterThanOrEqualTo:
                operatorStr = "大於";
                break;
            case Operator.LessThanOrEqualTo:
                operatorStr = "小於";
                break;
            default:
                Debug.LogWarning("讀意外事件表時有錯誤的運算元類型");
                break;
        }
        Process = Process.Replace("%%", operatorStr);
        //設定數值文字
        Process = Process.Replace("&&", Value.ToString());
    }
    /// <summary>
    /// 檢查有無通過屬性檢定
    /// </summary>
    public bool CheckPassEvent(List<PlayerChara> _charas)
    {
        switch (Target)
        {
            case EventCheckTarget.All:
                for (int i = 0; i < _charas.Count; i++)
                {
                    switch (RequireAttribute)
                    {
                        case MainAttribute.Agility:
                            if (_charas[i].FinalAgile() < Value)
                                return false;
                            break;
                        case MainAttribute.Alert:
                            if (_charas[i].FinalAlert() < Value)
                                return false;
                            break;
                        case MainAttribute.Constitution:
                            if (_charas[i].FinalConstitution() < Value)
                                return false;
                            break;
                        case MainAttribute.Faith:
                            if (_charas[i].FinalFaith() < Value)
                                return false;
                            break;
                        case MainAttribute.Mind:
                            if (_charas[i].FinalMind() < Value)
                                return false;
                            break;
                        case MainAttribute.Strength:
                            if (_charas[i].FinalStrength() < Value)
                                return false;
                            break;
                        case MainAttribute.Skill:
                            if (_charas[i].FinalSkill() < Value)
                                return false;
                            break;
                        case MainAttribute.Will:
                            if (_charas[i].FinalWill() < Value)
                                return false;
                            break;
                    }
                }
                break;
            case EventCheckTarget.Single:
                for (int i = 0; i < _charas.Count; i++)
                {
                    switch (RequireAttribute)
                    {
                        case MainAttribute.Agility:
                            if (_charas[i].FinalAgile() >= Value)
                                return true;
                            break;
                        case MainAttribute.Alert:
                            if (_charas[i].FinalAlert() >= Value)
                                return true;
                            break;
                        case MainAttribute.Constitution:
                            if (_charas[i].FinalConstitution() > Value)
                                return true;
                            break;
                        case MainAttribute.Faith:
                            if (_charas[i].FinalFaith() > Value)
                                return true;
                            break;
                        case MainAttribute.Mind:
                            if (_charas[i].FinalMind() > Value)
                                return true;
                            break;
                        case MainAttribute.Strength:
                            if (_charas[i].FinalStrength() > Value)
                                return true;
                            break;
                        case MainAttribute.Skill:
                            if (_charas[i].FinalSkill() > Value)
                                return true;
                            break;
                        case MainAttribute.Will:
                            if (_charas[i].FinalWill() > Value)
                                return true;
                            break;
                    }
                }
                break;
        }
        return true;
    }
}
