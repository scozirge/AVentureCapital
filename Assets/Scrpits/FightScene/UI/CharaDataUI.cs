using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CharaDataUI : MonoBehaviour
{
    Transform MyTransform;
    static bool IsInit;
    //腳色物件
    static Transform[] Trans_Chara;
    static CharaUI[] CharaUIs;
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        MyTransform = transform;
        Trans_Chara = new Transform[3];
        CharaUIs = new CharaUI[3];
        for (int i = 0; i < 3; i++)
        {
            Trans_Chara[i] = MyTransform.FindChild(string.Format("Chara{0}", i));
            CharaUIs[i] = Trans_Chara[i].GetComponent<CharaUI>();
            CharaUIs[i].Init(i);
        }
        IsInit = true;
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
        }
    }
    /// <summary>
    /// 更新腳色介面，傳入腳色排序索引編號
    /// </summary>
    public static void UpdateData(int _index)
    {
        if (!IsInit)
            return;
        CharaUIs[_index].UpdateHealth();
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
}
