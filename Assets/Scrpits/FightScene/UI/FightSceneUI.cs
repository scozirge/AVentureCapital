using UnityEngine;
using System.Collections;

public class FightSceneUI : MonoBehaviour
{
    static bool IsInit;
    public static RectTransform Canvas;
    CharaDataUI MyCharaDataUI;
    HitTextController MyHitTextController;
    FightTitleController TitleController;
    Progress MyProgress;
    EventUI MyEventUI;
    public void Init()
    {
        if (IsInit)
            return;
        Canvas = transform.GetComponent<RectTransform>();
        //腳色介面
        MyCharaDataUI = Canvas.FindChild("CharaData").GetComponent<CharaDataUI>();
        MyCharaDataUI.Init();//初始化
        //跳血文字控制器
        MyHitTextController = Canvas.FindChild("HitTextController").GetComponent<HitTextController>();
        MyHitTextController.Init();
        //標題控制器
        TitleController = Canvas.FindChild("FightTitle").GetComponent<FightTitleController>();
        TitleController.Init();
        //冒險進度
        MyProgress = Canvas.FindChild("Progress").GetComponent<Progress>();
        MyProgress.Init();
        //事件
        MyEventUI = Canvas.FindChild("Event").GetComponent<EventUI>();
        MyEventUI.Init();
        IsInit = true;
    }
}
