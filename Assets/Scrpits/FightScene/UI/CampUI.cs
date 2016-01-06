using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CampUI : MonoBehaviour
{
    static CampEventData Data;
    static CampUI MyCamp;
    static GameObject MyGameobject;
    static IEnumerator Coroutine;
    //情境
    static GameObject Go_Scenario;
    static Text Text_Scenario;
    //對話
    static GameObject Go_Talk;
    static Image Image_Talk;
    static Text Text_Talk;
    //選擇
    static GameObject Go_Choice;
    static Image Image_ChoiceIcon;
    static Text Text_Confirm;
    static Text Text_Cancel;
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        MyGameobject = gameObject;
        MyCamp = this;

        //情境
        Go_Scenario = transform.FindChild("Scenario").gameObject;
        Text_Scenario = Go_Scenario.transform.FindChild("description").GetComponent<Text>();
        //對話
        Go_Talk = transform.FindChild("Talk").gameObject;
        Image_Talk = Go_Talk.transform.FindChild("PlayerToken").FindChild("IconMask").FindChild("icon").GetComponent<Image>();
        Text_Talk = Go_Talk.transform.FindChild("description").GetComponent<Text>();
        //選擇
        Go_Choice = transform.FindChild("Choice").gameObject;
        Image_ChoiceIcon = Go_Choice.transform.FindChild("PlayerToken").FindChild("IconMask").FindChild("icon").GetComponent<Image>();
        Text_Confirm = Go_Choice.transform.FindChild("Confirm").FindChild("Text").GetComponent<Text>();
        Text_Cancel = Go_Choice.transform.FindChild("Cancel").FindChild("Text").GetComponent<Text>();
        ShowCampUI(false);
    }
    /// <summary>
    /// 顯示調查事件UI
    /// </summary>
    public static void ShowCampUI(bool _show)
    {
        MyGameobject.SetActive(_show);
    }
    /// <summary>
    /// 重置紮營事件
    /// </summary>
    public static void ResetEvent()
    {
        Go_Scenario.SetActive(false);
        Go_Choice.SetActive(false);
        Go_Talk.SetActive(false);
    }
    /// <summary>
    /// 呼叫調查事件
    /// </summary>
    public static void CallCamp(CampEventData _data)
    {
        Data = _data;
        ResetEvent();//重置事件
        //設定事件內容
        Text_Scenario.text = Data.Description;
        Text_Talk.text = Data.Talk1;
        Text_Confirm.text = Data.ConfirmTalk;
        Text_Cancel.text = Data.CancelTalk;
        ShowCampUI(true);
        Coroutine = EventCoroutine();
        MyCamp.StartCoroutine(Coroutine);
    }
    //事件協程
    static IEnumerator EventCoroutine()
    {
        Go_Talk.SetActive(true);
        yield return new WaitForSeconds(1f);
        Go_Scenario.SetActive(true);
        yield return new WaitForSeconds(1f);
        Go_Choice.SetActive(true);
    }
    /// <summary>
    /// 確認按鈕被按下
    /// </summary>
    public void Click_Confirm()
    {
        CharaDataUI.ShowCharas(true);//顯示腳色資料介面
        ShowCampUI(false);//隱藏紮營介面
        FightScene.KeepAdventure();//繼續冒險
    }
    /// <summary>
    /// 取消按鈕被按下
    /// </summary>
    public void Click_Cancel()
    {
        Debug.Log("離開冒險");
    }
}
