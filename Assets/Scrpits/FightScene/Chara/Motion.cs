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
        Ani_Chara = MyTransform.FindChild("Model").GetComponent<Animator>();
    }
    /// <summary>
    /// 播放腳色施法
    /// </summary>
    public void PlayMotion(Motion _motion, float _normalizedTime)
    {
        switch (_motion)
        {
            case Motion.Stay:
                if (Animator.StringToHash(string.Format("Base Layer.{0}", Motion.Stay.ToString())) != Ani_Chara.GetCurrentAnimatorStateInfo(0).fullPathHash)
                    Ani_Chara.SetTrigger(Motion.Stay.ToString());
                break;
            case Motion.GoForward:
                if (Animator.StringToHash(string.Format("Base Layer.{0}", Motion.GoForward.ToString())) != Ani_Chara.GetCurrentAnimatorStateInfo(0).fullPathHash)
                    Ani_Chara.Play(Motion.GoForward.ToString(), 0, _normalizedTime);
                break;
            case Motion.Attack:
                if (Animator.StringToHash(string.Format("Base Layer.{0}", Motion.Attack.ToString())) != Ani_Chara.GetCurrentAnimatorStateInfo(0).fullPathHash)
                {
                    Ani_Chara.Play(Motion.Attack.ToString(), 0, _normalizedTime);
                }
                else
                {
                    //重播
                    Ani_Chara.StopPlayback();
                }
                break;
            case Motion.Beaten:
                if (Animator.StringToHash(string.Format("Base Layer.{0}", Motion.Beaten.ToString())) != Ani_Chara.GetCurrentAnimatorStateInfo(0).fullPathHash)
                    Ani_Chara.Play(Motion.Beaten.ToString(), 0, _normalizedTime);
                else
                {
                    //重播
                    Ani_Chara.StopPlayback();
                }
                break;
            case Motion.Support:
                if (Animator.StringToHash(string.Format("Base Layer.{0}", Motion.Support.ToString())) != Ani_Chara.GetCurrentAnimatorStateInfo(0).fullPathHash)
                    Ani_Chara.Play(Motion.Support.ToString(), 0, _normalizedTime);
                else
                {
                    //重播
                    Ani_Chara.StopPlayback();
                }
                break;
            case Motion.Die:
                if (Animator.StringToHash(string.Format("Base Layer.{0}", Motion.Die.ToString())) != Ani_Chara.GetCurrentAnimatorStateInfo(0).fullPathHash)
                    Ani_Chara.Play(Motion.Die.ToString(), 0, _normalizedTime);
                break;
        }
    }
}
