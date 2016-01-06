using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AccidentUI : MonoBehaviour
{
    static AccidentEventData Data;
    static AccidentUI MyAccident;
    static GameObject MyGameobject;
    static IEnumerator Coroutine;
    //情境
    static GameObject Go_Scenario;
    static Text Text_Scenario;
    static GameObject Go_Process;
    static Text Text_Process;
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        MyGameobject = gameObject;
        MyAccident = this;

        //情境
        Go_Scenario = transform.FindChild("Scenario").gameObject;
        Text_Scenario = Go_Scenario.transform.FindChild("description").GetComponent<Text>();
        //回饋
        Go_Process = transform.FindChild("Process").gameObject;
        Text_Process = Go_Process.transform.FindChild("description").GetComponent<Text>();
        ShowAccidentUI(false);
    }
    /// <summary>
    /// 顯示結果事件UI
    /// </summary>
    public static void ShowAccidentUI(bool _show)
    {
        MyGameobject.SetActive(_show);
    }
    /// <summary>
    /// 重置結果事件
    /// </summary>
    public static void Reset()
    {
        Go_Scenario.SetActive(false);
        Go_Process.SetActive(false);
    }
    /// <summary>
    /// 呼叫結果事件
    /// </summary>
    public static void CallAccident(AccidentEventData _data)
    {
        Data = _data;
        Reset();//重置事件
        //設定事件內容
        Text_Scenario.text = Data.Description;
        Text_Process.text = Data.Process;
        ShowAccidentUI(true);
        Coroutine = EventCoroutine();
        MyAccident.StartCoroutine(Coroutine);
    }
    //事件協程
    static IEnumerator EventCoroutine()
    {
        Go_Scenario.SetActive(true);
        yield return new WaitForSeconds(1f);
        Go_Process.SetActive(true);
        yield return new WaitForSeconds(2f);
        ShowAccidentUI(false);//隱藏結果UI
        if(Data.CheckPassEvent(FightScene.PCharaList))
            ResultUI.CallResult(Data.PassResult);
        else
            ResultUI.CallResult(Data.FailResult);
    }
}
