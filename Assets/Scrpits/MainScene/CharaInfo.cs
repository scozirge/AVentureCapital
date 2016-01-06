using UnityEngine;
using System.Collections;

public class CharaInfo : MonoBehaviour
{
    static int CharaIndex { get; set; }
    static MainChara MyChara;
    static GameObject MyGameobject;
    static GameObject Go_Summary;
    static Summary MySummary;
    static GameObject Go_Detail;
    static bool IsShowSummary { get; set; }
    public void Init()
    {
        CharaIndex = 0;
        MyChara = Player.MyCharas[CharaIndex];
        MyGameobject = gameObject;
        Go_Summary = transform.FindChild("Summary").gameObject;
        MySummary = Go_Summary.GetComponent<Summary>();
        MySummary.Init();
        Go_Detail = transform.FindChild("Detail").gameObject;
        UpdateInfo();
        MyGameobject.SetActive(false);
    }
    /// <summary>
    /// 顯示腳色介面
    /// </summary>
    public void ShowInfo(int _index)
    {
        CharaIndex = _index;
        IsShowSummary = true;
        UpdateInfo();
        MyGameobject.SetActive(true);
    }
    /// <summary>
    /// 隱藏腳色介面
    /// </summary>
    public void HideInfo()
    {
        MyGameobject.SetActive(false);
    }
    /// <summary>
    /// 切換腳色資訊
    /// </summary>
    public void InfoSwitch(bool _bool)
    {
        if (IsShowSummary == _bool)
            return;
        IsShowSummary = _bool;
        UpdateInfo();
    }
    /// <summary>
    /// 更新腳色資訊
    /// </summary>
    void UpdateInfo()
    {
        MyChara = Player.MyCharas[CharaIndex];
        MySummary.Show(IsShowSummary, MyChara);
        Go_Detail.SetActive(!IsShowSummary);
    }
}
