using UnityEngine;
using System.Collections;

public class FightTitleController : MonoBehaviour
{
    static bool IsInit { get; set; }
    static Animator Ani;
    public void Init()
    {
        if (IsInit)
            return;
        Ani = transform.GetComponent<Animator>();
        IsInit = true;
    }
    /// <summary>
    /// 消滅敵方標題
    /// </summary>
    public static void ShowClearTitle()
    {
        Ani.SetTrigger("Clear");
    }
    /// <summary>
    /// 結束消滅敵方標題
    /// </summary>
    public void EndShowClearTilte()
    {
        //繼續冒險
        FightScene.KeepAdventure();
    }
}
