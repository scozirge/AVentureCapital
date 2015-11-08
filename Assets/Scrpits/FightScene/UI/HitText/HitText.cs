using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HitText : MonoBehaviour
{

    //擊中類型
    public HitTextType Type { get; private set; }
    //目標
    Chara Target;
    //文字物件
    GameObject MyGameobject;
    RectTransform CanvasRect;
    RectTransform MyTransfrom;
    Text MyText;
    Image MyImage;
    RectTransform RT_Imabe;
    Animator Ani;
    //參數
    bool IsInit;
    public bool IsShowing { get; private set; }//正在播放文字
    int Value;
    Vector2 ImagePosUp;
    Vector2 ImagePosCenter;
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        IsInit = true;
        MyGameobject = gameObject;
        MyTransfrom = transform.GetComponent<RectTransform>();
        MyTransfrom.FindChild("Motion").GetComponent<HitTextMotion>().Init(this);
        CanvasRect = FightSceneUI.Canvas;
        MyText = MyTransfrom.FindChild("Motion").FindChild("text").GetComponent<Text>();
        MyImage = MyTransfrom.FindChild("Motion").FindChild("image").GetComponent<Image>();
        Ani = MyTransfrom.FindChild("Motion").GetComponent<Animator>();
        ImagePosUp = new Vector2(0, 40);
        ImagePosCenter = new Vector2(0, 0);
    }
    /// <summary>
    /// 依照類型設定擊中文字各項屬性
    /// </summary>
    void SetType()
    {
        switch (Type)
        {
            case HitTextType.CriticalHit:
                //文字
                MyText.enabled = true;
                MyText.text = Value.ToString();
                MyText.color = Color.red;
                //圖像
                MyImage.enabled = true;
                MyImage.sprite = Resources.Load<Sprite>(string.Format("Sprites/UI/{0}", Type.ToString()));
                MyImage.SetNativeSize();
                RT_Imabe.anchoredPosition = ImagePosUp;
                break;
            case HitTextType.Hit:
                //文字
                MyText.enabled = true;
                MyText.text = Value.ToString();
                MyText.color = Color.white;
                //圖像
                MyImage.enabled = false;
                break;
            case HitTextType.SlightHit:
                //文字
                MyText.enabled = true;
                MyText.text = Value.ToString();
                MyText.color = Color.white;
                //圖像
                MyImage.enabled = true;
                MyImage.sprite = Resources.Load<Sprite>(string.Format("Sprites/UI/{0}", Type.ToString()));
                MyImage.SetNativeSize();
                RT_Imabe.anchoredPosition = ImagePosUp;
                break;
            case HitTextType.Dodge:
                //文字
                MyText.enabled = false;
                //圖像
                MyImage.enabled = true;
                MyImage.sprite = Resources.Load<Sprite>(string.Format("Sprites/UI/{0}", Type.ToString()));
                MyImage.SetNativeSize();
                RT_Imabe.anchoredPosition = ImagePosCenter;
                break;
            case HitTextType.Cure:
                //文字
                MyText.enabled = true;
                MyText.text = Value.ToString();
                MyText.color = Color.green;
                //圖像
                MyImage.enabled = false;
                break;
            case HitTextType.DOT:
                //文字
                MyText.enabled = true;
                MyText.text = Value.ToString();
                MyText.color = Color.white;
                //圖像
                MyImage.enabled = false;
                break;
        }
        if (Animator.StringToHash(string.Format("Base Layer.{0}", Type.ToString())) != Ani.GetCurrentAnimatorStateInfo(0).fullPathHash)
            Ani.SetTrigger(Type.ToString());
    }
    /// <summary>
    /// 設定位置
    /// </summary>
    void SetPos()
    {
        //then you calculate the position of the UI element
        //0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5 to get the correct position.
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(Target.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

        //now you can set the position of the ui element
        MyTransfrom.anchoredPosition = WorldObject_ScreenPosition;
    }
    /// <summary>
    /// 設定大小
    /// </summary>
    void SetSize()
    {
        MyTransfrom.localScale = Vector3.one;
    }
    /// <summary>
    /// 顯示傷害擊中文字，傳入[傷害數值][擊中類型]
    /// </summary>
    public void Show(Chara _target, int _value, HitTextType _type)
    {
        MyGameobject.SetActive(true);
        IsShowing = true;
        Type = _type;
        Target = _target;
        Value = _value;
        SetType();
        SetPos();
        SetSize();
    }
    /// <summary>
    /// 結束顯示狀態
    /// </summary>
    public void EndShow()
    {
        IsShowing = false;
        MyGameobject.SetActive(false);
    }
}
