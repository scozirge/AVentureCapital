using UnityEngine;
using System.Collections;

public class MainSceneUI : MonoBehaviour
{
    static CharaInfo MyCharaInfo;
    public void Init()
    {
        MyCharaInfo = transform.FindChild("CharaInfo").GetComponent<CharaInfo>();
        MyCharaInfo.Init();
    }
}
