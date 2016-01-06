using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour
{
    static GameObject Prefab_MainSceneUI;
    static GameObject Go_MainSceneUI;
    static MainSceneUI MyMainSceneUI;
    // Use this for initialization
    void Start()
    {
        SetData();
        SpawnObj();
    }
    void SpawnObj()
    {
        Prefab_MainSceneUI = Resources.Load<GameObject>("Gameobjects/MainScene/MainSceneUI");
        Go_MainSceneUI = Instantiate(Prefab_MainSceneUI, Vector2.zero, Quaternion.identity) as GameObject;
        MyMainSceneUI = Go_MainSceneUI.GetComponent<MainSceneUI>();
        MyMainSceneUI.Init();
    }
    void SetData()
    {
        GameDictionary.InitDic();
        Player.Init();
    }
}
