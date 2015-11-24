﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class FightScene : MonoBehaviour
{
    static FPSController MyFPSController;
    static Transform MyTransform;
    ////////////////////冒險/////////////////////
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
    //音效音樂
    static AudioPlayer FAudio;
    void Start()
    {
        LoadObj();
        SetData();
        LoadUI();
        SetAudio();
        CharaDataUI.UpdateData();
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
        FAudio = MyTransform.FindChild("Audios").GetComponent<AudioPlayer>();
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
    /// 初始化音樂音效
    /// </summary>
    void SetAudio()
    {
        FAudio.IniAudio();
    }
    /// <summary>
    /// 取得UI物件
    /// </summary>
    void LoadUI()
    {
        //產生FightSceneUI並初始化
        GameObject prefab_FightScene = Resources.Load<GameObject>("GameObjects/FightScene/UI/FightSceneUI");
        GameObject go_FightScene = Instantiate(prefab_FightScene, Vector2.zero, Quaternion.identity) as GameObject;
        go_FightScene.GetComponent<FightSceneUI>().Init();//初始化
        //產生FPSController並初始化
        GameObject prefab_FPSController = Resources.Load<GameObject>("GameObjects/Common/FPSController");
        GameObject go_FPS = Instantiate(prefab_FPSController, Vector2.zero, Quaternion.identity) as GameObject;
        go_FPS.GetComponent<FPSController>().Init();//初始化
    }
    /// <summary>
    /// 起始設定
    /// </summary>
    void SetData()
    {
        //字典
        GameDictionary.SetDic();
        //Player
        PCharaList[0].IniChara(0, GameDictionary.TmpChara1Dic);
        PCharaList[1].IniChara(1, GameDictionary.TmpChara2Dic);
        PCharaList[2].IniChara(2, GameDictionary.TmpChara3Dic);
        //Enemy
        ECharaList[0].IniChara(0, GameDictionary.TmpEnemy1Dic);
        ECharaList[1].IniChara(1, GameDictionary.TmpEnemy2Dic);
        ECharaList[2].IniChara(2, GameDictionary.TmpEnemy3Dic);
        //Timer
        SetTimer();
        //場景
        SetScene();
    }
    /// <summary>
    /// 玩家腳色播放動作，傳入動作類型與是否錯開播放
    /// </summary>
    public static void SetPlayerCharaMotion(Motion _motion, bool _stagger)
    {
        for (int i = 0; i < PCharaList.Count; i++)
        {
            if (_stagger)
                PCharaList[i].PlayMotion(_motion, ((float)i * 2f) / 10f);
            else
                PCharaList[i].PlayMotion(_motion, 0);
        }
    }
}
