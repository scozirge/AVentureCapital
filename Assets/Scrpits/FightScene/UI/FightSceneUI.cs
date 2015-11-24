using UnityEngine;
using System.Collections;

public class FightSceneUI : MonoBehaviour
{
    static bool IsInit;
    public static RectTransform Canvas;
    CharaDataUI MyCharaDataUI;
    HitTextController MyHitTextController;
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
        IsInit = true;
    }
}
