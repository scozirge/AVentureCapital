using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InvestigateUI : MonoBehaviour
{
    static InvestigateEventData Data;
    static InvestigateUI MyInvestigate;
    static GameObject MyGameobject;
    static IEnumerator Coroutine;
    //情境
    static GameObject Go_Scenario;
    static Text Text_Scenario;
    //對話
    static GameObject[] Go_Talks;
    static Image[] Image_Talks;
    static Text[] Text_Talks;
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
        MyInvestigate = this;

        //情境
        Go_Scenario = transform.FindChild("Scenario").gameObject;
        Text_Scenario = Go_Scenario.transform.FindChild("description").GetComponent<Text>();
        //對話
        Go_Talks = new GameObject[2];
        Image_Talks = new Image[2];
        Text_Talks = new Text[2];
        for (int i = 0; i < Go_Talks.Length; i++)
        {
            Go_Talks[i] = transform.FindChild(string.Format("Talk{0}", i)).gameObject;
            Image_Talks[i] = Go_Talks[i].transform.FindChild("PlayerToken").FindChild("IconMask").FindChild("icon").GetComponent<Image>();
            Text_Talks[i] = Go_Talks[i].transform.FindChild("description").GetComponent<Text>();
        }
        //選擇
        Go_Choice = transform.FindChild("Choice").gameObject;
        Image_ChoiceIcon = Go_Choice.transform.FindChild("PlayerToken").FindChild("IconMask").FindChild("icon").GetComponent<Image>();
        Text_Confirm = Go_Choice.transform.FindChild("Confirm").FindChild("Text").GetComponent<Text>();
        Text_Cancel = Go_Choice.transform.FindChild("Cancel").FindChild("Text").GetComponent<Text>();
        ShowInvestigateUI(false);
    }
    /// <summary>
    /// 顯示調查事件UI
    /// </summary>
    public static void ShowInvestigateUI(bool _show)
    {
        MyGameobject.SetActive(_show);
    }
    /// <summary>
    /// 重置調查事件
    /// </summary>
    public static void Reset()
    {
        Go_Scenario.SetActive(false);
        Go_Choice.SetActive(false);
        for (int i = 0; i < Go_Talks.Length; i++)
        {
            Go_Talks[i].SetActive(false);
        }
    }
    /// <summary>
    /// 呼叫調查事件
    /// </summary>
    public static void CallInvestigate(InvestigateEventData _data)
    {
        Data = _data;
        Reset();//重置事件
        //設定事件內容
        Text_Scenario.text = Data.Description;
        Text_Talks[0].text = Data.Talk1;
        Text_Talks[1].text = Data.Talk2;
        Text_Confirm.text = Data.ConfirmTalk;
        Text_Cancel.text = Data.CancelTalk;
        ShowInvestigateUI(true);
        Coroutine = EventCoroutine();
        MyInvestigate.StartCoroutine(Coroutine);
    }
    //事件協程
    static IEnumerator EventCoroutine()
    {
        Go_Scenario.SetActive(true);
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < Go_Talks.Length; i++)
        {
            Go_Talks[i].SetActive(true);
            yield return new WaitForSeconds(1f);
        }
        Go_Choice.SetActive(true);
    }
    /// <summary>
    /// 確認按鈕被按下
    /// </summary>
    public void Click_Confirm()
    {
        ShowInvestigateUI(false);
        ResultUI.CallResult(Data.Result[Calculator.WeightIndexGetter(Data.Result, Data.ResultWeight)]);
    }
    /// <summary>
    /// 取消按鈕被按下
    /// </summary>
    public void Click_Cancel()
    {
        CharaDataUI.ShowCharas(true);//顯示腳色資料介面
        ShowInvestigateUI(false);//隱藏調查介面
        FightScene.KeepAdventure();//繼續冒險
    }
}
