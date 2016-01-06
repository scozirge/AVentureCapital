using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{
    static MainChara MyChara;
    static Transform MyTransform;
    static GameObject MyGameobject;
    static Text Text_Name;
    static Scrollbar SB_Health;
    static Scrollbar SB_Vitality;
    static Text Text_Lv;
    static Text Text_Exp;
    static Text Text_Constitution;
    static Text Text_Mind;
    static Text Text_Strength;
    static Text Text_Faith;
    static Text Text_Will;
    static Text Text_Alert;
    static Text Text_Skill;
    static Text Text_Agile;
    static Text Text_Point;
    static Text Text_Talent;
    static Image Image_Talent;
    public void Init()
    {
        MyTransform = transform;
        MyGameobject = gameObject;
        Text_Name = MyTransform.FindChild("Name").FindChild("name").GetComponent<Text>();
        SB_Health = MyTransform.FindChild("Health").GetComponent<Scrollbar>();
        SB_Vitality = MyTransform.FindChild("Vitality").GetComponent<Scrollbar>();
        Text_Lv = MyTransform.FindChild("Level").FindChild("Title").GetComponent<Text>();
        Text_Exp = MyTransform.FindChild("Level").FindChild("Text").GetComponent<Text>();
        Text_Constitution = MyTransform.FindChild("Constitution").FindChild("Text").GetComponent<Text>();
        Text_Mind = MyTransform.FindChild("Mind").FindChild("Text").GetComponent<Text>();
        Text_Strength = MyTransform.FindChild("Strength").FindChild("Text").GetComponent<Text>();
        Text_Faith = MyTransform.FindChild("Faith").FindChild("Text").GetComponent<Text>();
        Text_Will = MyTransform.FindChild("Will").FindChild("Text").GetComponent<Text>();
        Text_Alert = MyTransform.FindChild("Alert").FindChild("Text").GetComponent<Text>();
        Text_Skill = MyTransform.FindChild("Skill").FindChild("Text").GetComponent<Text>();
        Text_Agile = MyTransform.FindChild("Agile").FindChild("Text").GetComponent<Text>();
        Text_Point = MyTransform.FindChild("Point").FindChild("Text").GetComponent<Text>();
        Text_Talent = MyTransform.FindChild("Talent").FindChild("Text").GetComponent<Text>();
        Image_Talent = MyTransform.FindChild("Talent").FindChild("Icon").GetComponent<Image>();
    }
    public void Show(bool _show, MainChara _chara)
    {
        if (_show)
        {
            MyChara = _chara;
            UpdateData();
        }
        MyGameobject.SetActive(_show);
    }
    public void UpdateData()
    {
        Text_Name.text = string.Format("{0}。{1}", MyChara.Title, MyChara.Name);
        SB_Health.size = MyChara.HealthRatio;
        SB_Vitality.size = MyChara.VitalityRatio;
        Text_Lv.text = string.Format("等級:{0}", MyChara.Level);
        Text_Exp.text = string.Format("({0}/{1})", MyChara.CurExp, MyChara.NeedExp);
        Text_Constitution.text = MyChara.Constitution.ToString();
        Text_Mind.text = MyChara.Mind.ToString();
        Text_Strength.text = MyChara.Strength.ToString();
        Text_Faith.text = MyChara.Faith.ToString();
        Text_Will.text = MyChara.Will.ToString();
        Text_Alert.text = MyChara.Alert.ToString();
        Text_Skill.text = MyChara.Skill.ToString();
        Text_Agile.text = MyChara.Skill.ToString();
        Text_Point.text = MyChara.Point.ToString();
        Text_Talent.text = MyChara.MyTalent.Name;
        Image_Talent.sprite = MyChara.MyTalent.IconSprite;
    }
}
