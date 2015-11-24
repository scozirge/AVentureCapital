using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharaUI : MonoBehaviour
{
    bool IsInit;
    PlayerChara MyChara;
    //腳色排序索引
    public int Index { get; private set; }
    //圖像&物件
    Animator Ani_Icon;
    Image Image_Icon;
    Animator Ani_IconCover;
    Animator Ani_Hit;
    Scrollbar SB_Health;
    Scrollbar SB_Vitality;
    public SpellUI[] SpellUIs;
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init(int _index)
    {
        Index = _index;
        MyChara = FightScene.PCharaList[Index];
        //抓取圖像&物件
        Ani_Icon = transform.FindChild("IconMask").FindChild("icon").GetComponent<Animator>();
        Image_Icon = Ani_Icon.transform.GetComponent<Image>();
        Ani_Hit = transform.FindChild("hit").GetComponent<Animator>();
        Ani_IconCover = transform.FindChild("iconCover").GetComponent<Animator>();
        SB_Health = transform.FindChild("Health").GetComponent<Scrollbar>();
        SB_Vitality = transform.FindChild("Vitality").GetComponent<Scrollbar>();
        //抓取SpellUI
        SpellUIs = new SpellUI[2];
        for (int i = 0; i < SpellUIs.Length; i++)
        {
            SpellUIs[i] = transform.FindChild(string.Format("Spell{0}", i)).GetComponent<SpellUI>();
            SpellUIs[i].Init(MyChara.ActivitySpells[i]);
        }
        IsInit = true;
    }
    /// <summary>
    /// 播放受到傷害動畫
    /// </summary>
    public void ShowDamageAni()
    {
        if (!IsInit)
        {
            Debug.LogWarning("CharaUI尚未初始化就被呼叫");
            return;
        }
        //播放被打動畫
        if (Animator.StringToHash(string.Format("Base Layer.{0}", "Hit")) != Ani_Icon.GetCurrentAnimatorStateInfo(0).fullPathHash)
            Ani_Icon.SetTrigger("Hit");
        if (Animator.StringToHash(string.Format("Base Layer.{0}", "Hit")) != Ani_Hit.GetCurrentAnimatorStateInfo(0).fullPathHash)
            Ani_Hit.SetTrigger("Hit");
        if (Animator.StringToHash(string.Format("Base Layer.{0}", "Hit")) != Ani_IconCover.GetCurrentAnimatorStateInfo(0).fullPathHash)
            Ani_IconCover.SetTrigger("Hit");
    }
    /// <summary>
    /// 播放受到治癒動畫
    /// </summary>
    public void ShowHealingHealthAni()
    {
        if (!IsInit)
        {
            Debug.LogWarning("CharaUI尚未初始化就被呼叫");
            return;
        }
        //播放被打動畫
        if (Animator.StringToHash(string.Format("Base Layer.{0}", "Healing_Health")) != Ani_IconCover.GetCurrentAnimatorStateInfo(0).fullPathHash)
            Ani_IconCover.SetTrigger("Healing_Health");
    }
    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {
        if (!IsInit)
        {
            Debug.LogWarning("CharaUI尚未初始化就被呼叫");
            return;
        }
        //播放死亡動畫
        if (Animator.StringToHash(string.Format("Base Layer.{0}", "Dead")) != Ani_Icon.GetCurrentAnimatorStateInfo(0).fullPathHash)
            Ani_Icon.SetTrigger("Dead");
        if (Animator.StringToHash(string.Format("Base Layer.{0}", "Dead")) != Ani_IconCover.GetCurrentAnimatorStateInfo(0).fullPathHash)
            Ani_IconCover.SetTrigger("Dead");
    }
    /// <summary>
    /// 更新腳色血量
    /// </summary>
    public void UpdateHealth()
    {
        if (!IsInit)
        {
            Debug.LogWarning("CharaUI尚未初始化就被呼叫");
            return;
        }
        SB_Health.size = MyChara.HealthRatio;
    }
    /// <summary>
    /// 更新腳色精神
    /// </summary>
    public void UpdateVitality()
    {
        if (!IsInit)
        {
            Debug.LogWarning("CharaUI尚未初始化就被呼叫");
            return;
        }
        SB_Vitality.size = MyChara.VitalityRatio;
    }
    /// <summary>
    /// 更新腳色技能CD
    /// </summary>
    public void UpdateSpellCD()
    {
        for (int i = 0; i < SpellUIs.Length; i++)
        {
            SpellUIs[i].UpdateCDCover();
        }
    }
}
