using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CharaDataUI : MonoBehaviour
{
    Transform MyTransform;
    static bool IsInit;
    //腳色物件
    static GameObject[] Go_Charas;
    static Transform[] Trans_Charas;
    static CharaUI[] CharaUIs;
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        MyTransform = transform;
        Trans_Charas = new Transform[3];
        Go_Charas = new GameObject[3];
        CharaUIs = new CharaUI[3];
        for (int i = 0; i < 3; i++)
        {
            Trans_Charas[i] = MyTransform.FindChild(string.Format("Chara{0}", i));
            Go_Charas[i] = Trans_Charas[i].gameObject;
            CharaUIs[i] = Trans_Charas[i].GetComponent<CharaUI>();
            CharaUIs[i].Init(i);
        }
        IsInit = true;
        ShowCharas(true);
    }
    /// <summary>
    /// 更新所有腳色介面
    /// </summary>
    public static void UpdateData()
    {
        if (!IsInit)
            return;
        for (int i = 0; i < 3; i++)
        {
            CharaUIs[i].UpdateHealth();
            CharaUIs[i].UpdateVitality();
        }
    }
    /// <summary>
    /// 更新腳色施法CD，傳入腳色排序索引編號
    /// </summary>
    public static void UpdateSpellCD(int _index)
    {
        if (!IsInit)
            return;
        for (int i = 0; i < CharaUIs[_index].SpellUIs.Length; i++)
        {
            CharaUIs[_index].SpellUIs[i].UpdateCDCover();
        }
    }
    /// <summary>
    /// 更新腳色血量，傳入腳色排序索引編號
    /// </summary>
    public static void UpdateHealth(int _index)
    {
        if (!IsInit)
            return;
        CharaUIs[_index].UpdateHealth();
    }
    /// <summary>
    /// 更新腳色精神，傳入腳色排序索引編號
    /// </summary>
    public static void UpdateVitality(int _index)
    {
        if (!IsInit)
            return;
        CharaUIs[_index].UpdateVitality();
    }
    /// <summary>
    /// 腳色被攻擊，傳入腳色排序索引編號
    /// </summary>
    public static void ShowDamageAni(int _index)
    {
        if (!IsInit)
            return;
        CharaUIs[_index].ShowDamageAni();
    }
    /// <summary>
    /// 顯示腳色被治癒血量動畫，傳入腳色排序索引編號
    /// </summary>
    public static void ShowHealingHealthAni(int _index)
    {
        if (!IsInit)
            return;
        CharaUIs[_index].ShowHealingHealthAni();
    }
    /// <summary>
    /// 腳色死亡，傳入腳色排序索引編號
    /// </summary>
    public static void Dead(int _index)
    {
        if (!IsInit)
            return;
        CharaUIs[_index].Dead();
    }
    /// <summary>
    /// 顯示所有腳色
    /// </summary>
    public static void ShowCharas(bool _show)
    {
        for (int i = 0; i < Trans_Charas.Length; i++)
        {
            Go_Charas[i].SetActive(_show);
        }
    }
}
