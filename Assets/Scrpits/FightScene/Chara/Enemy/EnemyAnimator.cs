using UnityEngine;
using System.Collections;

public class EnemyAnimator : MonoBehaviour
{
    static Animator Ani;
    void Awake()
    {
        Ani = transform.GetComponent<Animator>();
    }
    /// <summary>
    /// 戰鬥
    /// </summary>
    public void GoFIght()
    {
        Ani.SetTrigger("Stay");
        FightScene.StartFight();
    }
    /// <summary>
    /// 進場
    /// </summary>
    public static void GoIn()
    {
        Ani.SetTrigger("In");
    }
    /// <summary>
    /// 出場
    /// </summary>
    public static void GoOut()
    {
        Ani.SetTrigger("StayOut");
        //Ani.SetTrigger("Out");
    }
}
