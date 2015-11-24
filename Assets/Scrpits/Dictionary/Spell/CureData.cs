using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class CureData
{
    public int ID { get; private set; }
    public float Probability { get; private set; }
    //延遲顯示扣血
    public float ShowDelay { get; private set; }
    public int BaseCure { get; private set; }
    public int AbsoluteCure { get; private set; }
    /// <summary>
    /// 將字典傳入，依json表設定資料
    /// </summary>
    public static void SetData(Dictionary<int, CureData> _dic)
    {
        string jsonStr = Resources.Load<TextAsset>("Json/Cure").ToString();
        JsonData jd = JsonMapper.ToObject(jsonStr);
        JsonData CureItems = jd["Cure"];
        for (int i = 0; i < CureItems.Count; i++)
        {
            CureData CureData = new CureData(CureItems[i]);
            int id = int.Parse(CureItems[i]["ID"].ToString());
            _dic.Add(id, CureData);
        }
    }
    CureData(JsonData _item)
    {
        try
        {
            JsonData item = _item;
            ID = int.Parse(item["ID"].ToString());
            Probability = float.Parse(item["Probability"].ToString());
            ShowDelay = float.Parse(item["ShowDelay"].ToString());
            BaseCure = int.Parse(item["BaseCure"].ToString());
            AbsoluteCure = int.Parse(item["AbsoluteCure"].ToString());
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
