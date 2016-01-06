using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HitTextController : MonoBehaviour
{
    static Transform MyTransform;
    static bool Isinit;
    static List<HitText> HitTextList;
    static GameObject Prefab_HitText;
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        if (Isinit)
            return;
        MyTransform = transform;
        HitTextList = new List<HitText>();
        Prefab_HitText = Resources.Load<GameObject>("GameObjects/FightScene/UI/HitText");
        //初始化時先產生10個擊中文字物件
        for (int i = 0; i < 20;i++ )
        {
            SpawnHitText();
        }
        Isinit = true;
    }
    /// <summary>
    /// 顯示擊中文字，傳入[數字][擊中類型]
    /// </summary>
    public static void ShowHitText(Chara _cahra, int _value, HitTextType _type, float _showDelay)
    {
        if (!Isinit)
            return;
        if (HitTextList.Count == 0)
        {
            SpawnHitText().Show(_cahra, _value, _type, _showDelay);
        }
        else
        {
            bool isShowed = false;
            for (int i = 0; i < HitTextList.Count; i++)//用迴圈找可以播放的文字物件
            {
                if (!HitTextList[i].IsShowing)
                {
                    HitTextList[i].Show(_cahra, _value, _type, _showDelay);
                    isShowed = true;
                    break;
                }
            }
            if (!isShowed)//isShowed為false代表目前的文字物件都在播放，創造新的文字物件並播放
            {
                SpawnHitText().Show(_cahra, _value, _type, _showDelay);
            }
        }
    }
    /// <summary>
    /// 創造擊中文字物件
    /// </summary>
    static HitText SpawnHitText()
    {
        //創造物件並初始化
        GameObject go_hitText = GameObject.Instantiate(Prefab_HitText, Vector2.zero, Quaternion.identity) as GameObject;
        go_hitText.transform.SetParent(MyTransform);
        HitText hitText = go_hitText.GetComponent<HitText>();
        hitText.Init();
        //加入清單
        HitTextList.Add(hitText);
        return hitText;
    }
}
