using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Milestone : MonoBehaviour
{
    MilestoneEvent Type { get; set; }
    bool IsUnknown { get; set; }
    int Mile { get; set; }
    Image Image_Icon;
    static RectTransform RTransfrom;
    //圖像陣列，prefab的圖像陣列要符合enum順序對應的圖像
    public Sprite[] MilestoneSprites = new Sprite[6];
    public void Init(MilestoneEvent _type, int _mile, bool _isUnknown)
    {
        RTransfrom = transform.GetComponent<RectTransform>();
        RTransfrom.localScale = Vector2.one;
        RTransfrom.anchoredPosition = Vector2.zero;
        Image_Icon = transform.FindChild("icon").GetComponent<Image>();
        SetType(_type, _isUnknown);
        SetPos(_mile);
    }
    /// <summary>
    /// 設定里程碑種類
    /// </summary>
    void SetType(MilestoneEvent _type, bool _isUnknown)
    {
        Type = _type;
        IsUnknown = _isUnknown;
        SetImage();
    }
    /// <summary>
    /// 設定圖像
    /// </summary>
    void SetImage()
    {
        if ((byte)Type >= MilestoneSprites.Length)
        {
            Debug.LogWarning("要設定的里程碑圖像超出索引範圍");
            return;
        }
        if (MilestoneSprites[(byte)Type] == null)
        {
            Debug.LogWarning("要設定的里程碑圖像為空");
            return;
        }
        if (!IsUnknown)
            Image_Icon.sprite = MilestoneSprites[(byte)Type];
        else
            Image_Icon.sprite = MilestoneSprites[(byte)MilestoneEvent.Unknown];
    }
    /// <summary>
    /// 設定位置
    /// </summary>
    void SetPos(int _mile)
    {
        Mile = _mile;
        RTransfrom.anchoredPosition = new Vector2(Mile * MilestoneController.MileDist, 0);
    }
}
