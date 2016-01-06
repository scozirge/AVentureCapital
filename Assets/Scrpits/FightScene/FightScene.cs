using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class FightScene : MonoBehaviour
{
    static bool IsInit { get; set; }
    //物件
    static Transform MyTransform;
    ////////////////////冒險/////////////////////
    //是否開始冒險
    static bool Adventure;
    //PlayerChara
    static Transform Trans_PlayerCharas;
    public static Transform[] PlayerTrans;
    public static Dictionary<string, PlayerChara> PCharaDic;
    public static List<PlayerChara> PCharaList;
    public static List<PlayerChara> PAliveCharaList;
    //EnemyChara
    static Transform Trans_EnemyCharas;
    public static Transform[] EnemyTrans;
    public static Dictionary<string, EnemyChara> ECharaDic;
    public static List<EnemyChara> ECharaList;
    public static List<EnemyChara> EAliveCharaList;
    //音效音樂
    static AudioPlayer FAudio;
    //FPS控制器
    static FPSController MyFPSController;
    void Start()
    {
        if (IsInit)
            return;
        LoadObj();
        SetData();
        LoadUI();
        SetAudio();
        CharaDataUI.UpdateData();
        //開始冒險
        StartAdventure();
        IsInit = true;
    }
    /// <summary>
    /// 起始設定
    /// </summary>
    void LoadObj()
    {
        MyTransform = transform;
        //Player
        PlayerTrans = new Transform[3];
        PCharaDic = new Dictionary<string, PlayerChara>();
        PCharaList = new List<PlayerChara>();
        PAliveCharaList = new List<PlayerChara>();
        Trans_PlayerCharas = MyTransform.FindChild("Charas").FindChild("PlayerCharas");
        for (int i = 0; i < PlayerTrans.Length; i++)
        {
            PlayerTrans[i] = Trans_PlayerCharas.FindChild(string.Format("Chara{0}", i));
        }
        //Enemy
        EnemyTrans = new Transform[3];
        ECharaDic = new Dictionary<string, EnemyChara>();
        ECharaList = new List<EnemyChara>();
        EAliveCharaList = new List<EnemyChara>();
        Trans_EnemyCharas = MyTransform.FindChild("Charas").FindChild("EnemyCharas");
        for (int i = 0; i < EnemyTrans.Length; i++)
        {
            EnemyTrans[i] = Trans_EnemyCharas.FindChild(string.Format("Chara{0}", i));
        }
        //Audio
        FAudio = MyTransform.FindChild("Audios").GetComponent<AudioPlayer>();
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
        GameDictionary.InitDic();
        //Player
        PlayerTrans[0].GetComponent<PlayerChara>().IniChara(0, GameDictionary.TmpChara1Dic);
        PlayerTrans[1].GetComponent<PlayerChara>().IniChara(1, GameDictionary.TmpChara2Dic);
        PlayerTrans[2].GetComponent<PlayerChara>().IniChara(2, GameDictionary.TmpChara3Dic);
        //Timer
        IniTimer();
        //場景
        IniScene();
    }
    /// <summary>
    /// 設定敵人
    /// </summary>
    static void SetEnemy(Dictionary<string, string>[] _enemysDic)
    {
        int enemyNum = _enemysDic.Length;
        if (_enemysDic == null || enemyNum < 1 || enemyNum > 3)
        {
            Debug.LogWarning("敵人數量異常");
            return;
        }
        //傳入敵人字典
        for (byte i = 0; i < 3; i++)
        {
            if (i < enemyNum)
            {
                EnemyTrans[i].gameObject.SetActive(true);
                EnemyTrans[i].GetComponent<EnemyChara>().IniChara(i, _enemysDic[i]);
            }
            else
            {
                EnemyTrans[i].gameObject.SetActive(false);
            }
        }
    }
    /// <summary>
    /// 重置敵人
    /// </summary>
    static void ResetEnemy()
    {
        //清除敵方腳色字典
        ECharaDic.Clear();
        ECharaList.Clear();
        EAliveCharaList.Clear();
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
