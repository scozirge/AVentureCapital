using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SpellUI : MonoBehaviour
{
    bool IsInit;
    ActivitySpell MySpell;
    //物件
    Image Image_Icon;
    Image Image_Bottom;
    Image Image_Cover;
    public void Init(ActivitySpell _spell)
    {
        MySpell = _spell;
        Image_Icon = transform.FindChild("icon").GetComponent<Image>();
        Image_Bottom = transform.FindChild("bottom").GetComponent<Image>();
        Image_Cover = transform.FindChild("cover").GetComponent<Image>();
        //設定Icon圖
        SetIcon();
        //設定底圖顏色
        SetBottomColor(MySpell.Type);
        //初始設定無CD
        Image_Cover.fillAmount = 0;
        IsInit = true;
    }
    /// <summary>
    /// 設定Icon底圖顏色
    /// </summary>
    void SetBottomColor(SpellType _type)
    {
        if (!IsInit)
            return;
        Image_Bottom.color = GameDictionary.SpellColorDic[_type];
    }
    /// <summary>
    /// 設定Icon圖
    /// </summary>
    void SetIcon()
    {
        if (!IsInit)
            return;
        Image_Icon = Resources.Load<Image>(string.Format("Sprites/SpellIcon/{0}", MySpell.IconName));
    }
    /// <summary>
    /// 更新CD圖
    /// </summary>
    public void UpdateCDCover()
    {
        if (!IsInit)
            return;
        Image_Cover.fillAmount = MySpell.CDRaito;
    }
    /// <summary>
    /// 執行施法
    /// </summary>
    public void Execute()
    {
        MySpell.Execute();
    }
}
