using UnityEngine;
using System.Collections;

public class HitTextMotion : MonoBehaviour
{
    HitText MyHitText;
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init(HitText _hitText)
    {
        MyHitText = _hitText;
    }
    /// <summary>
    /// 跳血文字結束
    /// </summary>
    public void OnEndShowHitText()
    {
        MyHitText.EndShow();
    }
}
