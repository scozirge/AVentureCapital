using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class FightScene : MonoBehaviour
{
    static FightScene FS;
    static Transform MyTransform;
    ////////////////////冒險/////////////////////
    //是否開始戰鬥
    static bool Fight;
    //是否開始冒險
    static bool Adventure;
    //PlayerChara
    static Transform Trans_PlayerCharas;
    public static Dictionary<string, PlayerChara> PCharaDic;
    public static List<PlayerChara> PCharaList;
    //EnemyChara
    static Transform Trans_EnemyCharas;
    public static EnemyChara EChara;
    //UI
    static GameObject Prefab_FightSceneUI;
    static GameObject Go_FightSceneUI;
    static Vector2 V2_FightScene;

    void Start()
    {
        FS = this;
        LoadObj();
        SetData();
        LoadUI();
        //開始冒險
        StartAdventure();
    }
    /// <summary>
    /// 起始設定
    /// </summary>
    void LoadObj()
    {
        MyTransform = transform;
        //Player
        PCharaDic = new Dictionary<string, PlayerChara>();
        PCharaList = new List<PlayerChara>();
        Trans_PlayerCharas = MyTransform.FindChild("Charas").FindChild("PlayerCharas");
        for (int i = 0; i < 3; i++)
        {
            PCharaDic.Add(i.ToString(), Trans_PlayerCharas.FindChild(string.Format("Chara{0}", i)).GetComponent<PlayerChara>());
            PCharaList.Add(PCharaDic[i.ToString()]);
        }
        //Enemy
        Trans_EnemyCharas = MyTransform.FindChild("Charas").FindChild("EnemyCharas");
        EChara = Trans_EnemyCharas.FindChild("Chara").GetComponent<EnemyChara>();
    }
    /// <summary>
    /// 取得UI物件
    /// </summary>
    void LoadUI()
    {
        //FightSceneUI
        V2_FightScene = new Vector2(15, 0);
        Prefab_FightSceneUI = Resources.Load<GameObject>("GameObjects/FightScene/FightSceneUI");
        Go_FightSceneUI = Instantiate(Prefab_FightSceneUI, V2_FightScene, Quaternion.identity) as GameObject;
        Go_FightSceneUI.GetComponent<FightSceneUI>().StartSet();
    }
    /// <summary>
    /// 起始設定
    /// </summary>
    void SetData()
    {
        //Player
        for(byte i=0;i<PCharaList.Count;i++)
        {
            PCharaList[i].StartSet();
            PCharaList[i].SetIndex(i);
        }
        //Enemy
        EChara.StartSet();
        //Timer
        SetTimer();
        //場景
        SetScene();
    }
    void Update()
    {
        //StartFight=true時才啟動戰鬥計時器
        if (Fight)
        {
            //檢查一單位時間是否到了，時間到就呼叫所有腳色的TimePass
            if (CheckTimeUnit())
            {
                for (int i = 0; i < PCharaList.Count; i++)
                {
                    PCharaList[i].TimePass();
                }
                EChara.TimePass();
            }
        }
        //StartAdventrue=true時才啟動冒險計時器
        if(Adventure)
            CheckAdventureTime();
    }
}
