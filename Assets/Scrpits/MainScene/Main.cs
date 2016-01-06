using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
    /// <summary>
    /// 進入冒險場景
    /// </summary>
    public void Adventure()
    {
        SceneController.ChangeScene(SceneName.FightScene);
    }
}
