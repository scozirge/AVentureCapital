using UnityEngine;
using System.Collections;

public abstract partial class Chara : MonoBehaviour
{
    /// <summary>
    /// 設定腳色Model
    /// </summary>
    void IniMotion()
    {
        //腳色動畫
        Ani_Chara = MyTransform.FindChild("Model").GetComponent<Animator>();
        //腳色圖像
        SR_Chara = MyTransform.FindChild("Model").FindChild("sprite").GetComponent<SpriteRenderer>();
        //初始化施法位置與縮放
        IniSpellPosAndScale();
    }
    /// <summary>
    /// 初始化施法位置與縮放
    /// </summary>
    void IniSpellPosAndScale()
    {
        //腳色初始位置
        DefaultPos = new Vector2[6];
        DefaultPos[0] = new Vector2(-2.5f, 3.2f);
        DefaultPos[1] = new Vector2(-1.5f, 3f);
        DefaultPos[2] = new Vector2(-0.7f, 2.5f);
        DefaultPos[3] = new Vector2(2.5f, 3.2f);
        DefaultPos[4] = new Vector2(1.5f, 3f);
        DefaultPos[5] = new Vector2(0.7f, 2.5f);
        //腳色初始縮放
        DefaultScale = new Vector2[6];
        DefaultScale[0] = new Vector2(0.8f, 0.8f);
        DefaultScale[1] = new Vector2(0.6f, 0.6f);
        DefaultScale[2] = new Vector2(0.4f, 0.4f);
        DefaultScale[3] = new Vector2(-0.8f, 0.8f);
        DefaultScale[4] = new Vector2(-0.6f, 0.6f);
        DefaultScale[5] = new Vector2(-0.4f, 0.4f);
        //所在位置的縮放
        PosScale = new Vector2[6];
        PosScale[0] = new Vector2(-0.8f, 0.8f);
        PosScale[1] = new Vector2(-0.6f, 0.6f);
        PosScale[2] = new Vector2(-0.4f, 0.4f);
        PosScale[3] = new Vector2(0.8f, 0.8f);
        PosScale[4] = new Vector2(0.6f, 0.6f);
        PosScale[5] = new Vector2(0.4f, 0.4f);
        //施法位置
        SpellPos = new Vector2[6];
        SpellPos[0] = new Vector2(0, 3.2f);
        SpellPos[1] = new Vector2(0, 3f);
        SpellPos[2] = new Vector2(0, 2.5f);
        SpellPos[3] = new Vector2(0, 3.2f);
        SpellPos[4] = new Vector2(0, 3f);
        SpellPos[5] = new Vector2(0, 2.5f);
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
                Ani_Chara.SetBool("InFighting", FightScene.Fight);
                FightScene.SetAction(true);//設定有人在執行動作
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
                FightScene.SetAction(true);//設定有人在執行動作
                Ani_Chara.SetBool("InFighting", FightScene.Fight);
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
    /// <summary>
    /// 設定腳色預設位置與縮放
    /// </summary>
    public void SetDefaultTransfrom()
    {
        //設定腳色預設位置
        SetDefaultPos();
        //設定腳色預設縮放
        SetDefaultScale();
        //設定腳色預設圖像層級
        SetDefaultSpriteSort();
    }
    /// <summary>
    /// 設定腳色預設位置
    /// </summary>
    void SetDefaultPos()
    {
        MyTransform.localPosition = DefaultPos[AbsIndex];
    }
    /// <summary>
    /// 設定腳色預設縮放
    /// </summary>
    void SetDefaultScale()
    {
        MyTransform.localScale = DefaultScale[AbsIndex];
    }
    /// <summary>
    /// 設定腳色預設圖像層級
    /// </summary>
    void SetDefaultSpriteSort()
    {
        SR_Chara.sortingOrder = 40 - Index * 10;
    }
    /// <summary>
    /// 設定施法位置與縮放改變，傳入目標絕對索引與相對索引
    /// </summary>
    public void SetSpellTransfrom(byte _targetAbsIndex,byte _targetIndex)
    {
        //如果目標是自己就不需要改變位置與縮放
        if (AbsIndex == _targetAbsIndex)
            return;
        SetSpellPos(_targetAbsIndex);
        SetSpellScale(_targetAbsIndex);
        SetDefaultSpriteSort(_targetIndex);
    }
    /// <summary>
    /// 根據目標設定腳色位置
    /// </summary>
    void SetSpellPos(byte _targetAbsIndex)
    {
        MyTransform.localPosition = SpellPos[_targetAbsIndex];
    }
    /// <summary>
    /// 根據目標設定腳色縮放
    /// </summary>
    void SetSpellScale(byte _targetAbsIndex)
    {
        MyTransform.localScale = PosScale[_targetAbsIndex];
    }
    /// <summary>
    /// 根據目標設定腳色圖像層級
    /// </summary>
    void SetDefaultSpriteSort(byte _targetIndex)
    {
        SR_Chara.sortingOrder = 40 - _targetIndex * 10 + 1;
    }
}
