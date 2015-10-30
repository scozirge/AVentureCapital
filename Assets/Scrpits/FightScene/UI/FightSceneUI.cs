using UnityEngine;
using System.Collections;

public class FightSceneUI : MonoBehaviour
{
    bool IsInit;
    Transform MyTransform;
    CharaDataUI MyCharaDataUI;
    public void Init()
    {
        MyTransform = transform;
        //腳色介面
        MyCharaDataUI = MyTransform.FindChild("CharaData").GetComponent<CharaDataUI>();
        MyCharaDataUI.Init();//初始化
        IsInit = true;
    }
}
