using UnityEngine;
using System.Collections;

public class MotionAction : MonoBehaviour
{
    Chara MyChara;
    void Start()
    {
        MyChara = transform.parent.GetComponent<Chara>();
    }
    /// <summary>
    /// 結束動作
    /// </summary>
    public void EndAction()
    {
        MyChara.EndSpell();
    }
}
