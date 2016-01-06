using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Progress : MonoBehaviour
{
    static MilestoneController MC;
    static Text Miles;
    public void Init()
    {
        //初始化冒險
        Adventure adventure = new Adventure(1);
        MC = transform.FindChild("MilestoneController").GetComponent<MilestoneController>();
        MC.Init(adventure.Data, adventure.GetEventTypes(), adventure.GetEventMiles(), adventure.GetUnknownEvent());
        //設定里程
        Miles = transform.FindChild("Miles").FindChild("miles").GetComponent<Text>();
    }
    /// <summary>
    /// 前進下一個里程碑
    /// </summary>
    public static void GoForward()
    {
        MC.GoForward();
        UpdateMiles();
    }
    /// <summary>
    /// 更新里程數
    /// </summary>
    public static void UpdateMiles()
    {
        Miles.text = string.Format("里程數:{0}/{1}", MilestoneController.Mile, MilestoneController.MaxMIle);
    }
}
