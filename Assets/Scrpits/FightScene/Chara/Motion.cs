using UnityEngine;
using System.Collections;

public abstract partial class Chara : MonoBehaviour
{
    Animator Ani_Chara;
    /// <summary>
    /// 設定腳色Model
    /// </summary>
    void IniMotion()
    {
        Ani_Chara = MyTransform.GetComponent<Animator>();
    }
    /// <summary>
    /// 播放腳色施法
    /// </summary>
    public void PlayMotion(Motion _motion)
    {
        switch (_motion)
        {
            case Motion.Stay:
                if (Animator.StringToHash(string.Format("Base Layer.{0}", Motion.Stay.ToString())) != Ani_Chara.GetCurrentAnimatorStateInfo(0).nameHash)
                    Ani_Chara.SetTrigger(Motion.Stay.ToString());
                break;
            case Motion.Action:
                if (Animator.StringToHash(string.Format("Base Layer.{0}", Motion.Action.ToString())) != Ani_Chara.GetCurrentAnimatorStateInfo(0).nameHash)
                {
                    Ani_Chara.SetTrigger(Motion.Action.ToString());
                }
                else
                {
                    //重播
                    Ani_Chara.StopPlayback();
                }
                break;
            case Motion.Beaten:
                if (Animator.StringToHash(string.Format("Base Layer.{0}", Motion.Beaten.ToString())) != Ani_Chara.GetCurrentAnimatorStateInfo(0).nameHash)
                    Ani_Chara.SetTrigger(Motion.Action.ToString());
                else
                {
                    //重播
                    Ani_Chara.StopPlayback();
                }
                break;
        }
    }
}
