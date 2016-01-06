using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    static EventResultData Data;
    static ResultUI MyResult;
    static GameObject MyGameobject;
    static IEnumerator Coroutine;
    //情境
    static GameObject Go_Scenario;
    static Text Text_Scenario;
    static GameObject Go_Feedback;
    static Text Text_Feedback;
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        MyGameobject = gameObject;
        MyResult = this;

        //情境
        Go_Scenario = transform.FindChild("Scenario").gameObject;
        Text_Scenario = Go_Scenario.transform.FindChild("description").GetComponent<Text>();
        //回饋
        Go_Feedback = transform.FindChild("Feedback").gameObject;
        Text_Feedback = Go_Feedback.transform.FindChild("description").GetComponent<Text>();
        ShowResultUI(false);
    }
    /// <summary>
    /// 顯示結果事件UI
    /// </summary>
    public static void ShowResultUI(bool _show)
    {
        MyGameobject.SetActive(_show);
    }
    /// <summary>
    /// 重置結果事件
    /// </summary>
    public static void Reset()
    {
        Go_Scenario.SetActive(false);
        Go_Feedback.SetActive(false);
    }
    /// <summary>
    /// 呼叫結果事件
    /// </summary>
    public static void CallResult(int _resultID)
    {
        Data = GameDictionary.EventResultDic[_resultID];
        Reset();//重置事件
        //設定事件內容
        Text_Scenario.text = Data.Description;
        Text_Feedback.text = Data.GetFeedbackDescription();
        ShowResultUI(true);
        Coroutine = EventCoroutine();
        MyResult.StartCoroutine(Coroutine);
    }
    //事件協程
    static IEnumerator EventCoroutine()
    {
        Go_Scenario.SetActive(true);
        yield return new WaitForSeconds(1f);
        Go_Feedback.SetActive(true);
        yield return new WaitForSeconds(2f);
        ShowResultUI(false);//隱藏結果UI
        CharaDataUI.ShowCharas(true);//顯示腳色資料介面
        //如果有戰鬥就進入戰鬥沒有則繼續冒險
        if (Data.CheckFight())
            FightScene.AmbushEvent(MonsterGetter.GetMonsterDicsFromEvent(Data.MonsterEvent));//埋伏事件
        else
            FightScene.KeepAdventure();//繼續冒險
    }
}
