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
    public static List<PlayerChara> PAliveCharaList;
    //EnemyChara
    static Transform Trans_EnemyCharas;
    public static Dictionary<string, EnemyChara> ECharaDic;
    public static List<EnemyChara> ECharaList;
    public static List<EnemyChara> EAliveCharaList;
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
        PAliveCharaList = new List<PlayerChara>();
        ECharaDic = new Dictionary<string, EnemyChara>();
        ECharaList = new List<EnemyChara>();
        EAliveCharaList = new List<EnemyChara>();
        Trans_PlayerCharas = MyTransform.FindChild("Charas").FindChild("PlayerCharas");
        Trans_EnemyCharas = MyTransform.FindChild("Charas").FindChild("EnemyCharas");
        for (int i = 0; i < 3; i++)
        {
            //Player
            PCharaDic.Add(i.ToString(), Trans_PlayerCharas.FindChild(string.Format("Chara{0}", i)).GetComponent<PlayerChara>());
            PCharaList.Add(PCharaDic[i.ToString()]);
            PAliveCharaList.Add(PCharaDic[i.ToString()]);
            //Enemy
            ECharaDic.Add(i.ToString(), Trans_EnemyCharas.FindChild(string.Format("Chara{0}", i)).GetComponent<EnemyChara>());
            ECharaList.Add(ECharaDic[i.ToString()]);
            EAliveCharaList.Add(ECharaDic[i.ToString()]);
        }
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
        //字典
        GameDictionary.SetDic();
        //Player
        PCharaList[0].IniChara(0, GameDictionary.TmpChara1Dic, GameDictionary.Chara1ActionList);
        PCharaList[1].IniChara(1, GameDictionary.TmpChara2Dic, GameDictionary.Chara2ActionList);
        PCharaList[2].IniChara(2, GameDictionary.TmpChara3Dic, GameDictionary.Chara3ActionList);
        //Enemy
        ECharaList[0].IniChara(0, GameDictionary.TmpChara1Dic, GameDictionary.Chara1ActionList);
        ECharaList[1].IniChara(1, GameDictionary.TmpChara2Dic, GameDictionary.Chara2ActionList);
        ECharaList[2].IniChara(2, GameDictionary.TmpChara3Dic, GameDictionary.Chara3ActionList);
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
            if (CheckFightTimeUnit())
            {
                //Debug.LogWarning("////////////玩家動作///////////");
                for (int i = 0; i < PCharaList.Count; i++)
                {
                    PCharaList[i].TimePass();
                }
                //Debug.LogWarning("////////////敵方動作///////////");
                for (int i = 0; i < ECharaList.Count; i++)
                {
                    ECharaList[i].TimePass();
                }
            }
        }
        //StartAdventrue=true時才啟動冒險計時器
        if (Adventure)
            CheckAdventureTimeUnit();
    }
    /// <summary>
    /// 玩家腳色播放動作，傳入動作類型與是否錯開播放
    /// </summary>
    static void SetPlayerCharaMotion(Motion _motion, bool _stagger)
    {
        for (int i = 0; i < PCharaList.Count; i++)
        {
            PCharaList[i].PlayMotion(_motion, ((float)i * 2f) / 10f);
        }
    }
}
