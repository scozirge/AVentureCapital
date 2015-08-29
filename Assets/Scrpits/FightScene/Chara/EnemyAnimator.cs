using UnityEngine;
using System.Collections;

public class EnemyAnimator : MonoBehaviour
{
    static Animator Ani;
    void Awake()
    {
        Ani = transform.GetComponent<Animator>();
    }
    public void GoFIght()
    {
        Ani.SetTrigger("Stay");
        FightScene.StartFight();
    }
    public static void GoIn()
    {
        Ani.SetTrigger("In");
    }
    public static void GoOut()
    {
        Ani.SetTrigger("Out");
    }
}
