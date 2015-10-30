using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharaUI : MonoBehaviour
{
    //腳色排序索引
    public int Index { get; private set; }
    //圖像&物件
    Animator Ani_Icon;
    Image Image_Icon;
    Animator Ani_IconCover;
    Animator Ani_Hit;
    Image[] Image_Skills;
    Scrollbar SB_Health;
    Scrollbar SB_Mind;
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init(int _index)
    {
        Index = _index;
        //抓取圖像&物件
        Ani_Icon = transform.FindChild("IconMask").FindChild("icon").GetComponent<Animator>();
        Image_Icon = Ani_Icon.transform.GetComponent<Image>();
        Ani_Hit = transform.FindChild("hit").GetComponent<Animator>();
        Ani_IconCover = transform.FindChild("iconCover").GetComponent<Animator>();
        Image_Skills = new Image[2];
        SB_Health = transform.FindChild("Health").GetComponent<Scrollbar>();
        SB_Mind = transform.FindChild("Mind").GetComponent<Scrollbar>();
    }
    /// <summary>
    /// 擊中
    /// </summary>
    public void Hit()
    {
        //播放被打動畫
        if (Animator.StringToHash(string.Format("Base Layer.{0}", "Hit")) != Ani_Icon.GetCurrentAnimatorStateInfo(0).fullPathHash)
            Ani_Icon.SetTrigger("Hit");
        if (Animator.StringToHash(string.Format("Base Layer.{0}", "Hit")) != Ani_Hit.GetCurrentAnimatorStateInfo(0).fullPathHash)
            Ani_Hit.SetTrigger("Hit");
        if (Animator.StringToHash(string.Format("Base Layer.{0}", "Hit")) != Ani_IconCover.GetCurrentAnimatorStateInfo(0).fullPathHash)
            Ani_IconCover.SetTrigger("Hit");
    }
    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {
        //播放死亡動畫
        if (Animator.StringToHash(string.Format("Base Layer.{0}", "Dead")) != Ani_Icon.GetCurrentAnimatorStateInfo(0).fullPathHash)
            Ani_Icon.SetTrigger("Dead");
        if (Animator.StringToHash(string.Format("Base Layer.{0}", "Dead")) != Ani_IconCover.GetCurrentAnimatorStateInfo(0).fullPathHash)
            Ani_IconCover.SetTrigger("Dead");
    }
    /// <summary>
    /// 更新腳色血量與心智
    /// </summary>
    public void UpdateData()
    {
        SB_Health.size = FightScene.PCharaList[Index].HealthRatio;
        SB_Mind.size = FightScene.PCharaList[Index].MindRatio;
    }
}
