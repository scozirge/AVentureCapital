using UnityEngine;
using System.Collections;

public class FightSceneUI : MonoBehaviour
{
    static Transform MyTransfrom;
    //玩家物件
    static Transform PlayerPannel;
    static Transform[] TransArray_PlayerChara;
    static UILabel[] Lab_PlayerCurHP;
    //敵人物件
    static Transform EnemyPannel;
    static Transform[] TransArray_EnemyChara;
    static UILabel[] Lab_EnemyCurHP;
    public void StartSet()
    {
        MyTransfrom = transform;
        //取得物件
        PlayerPannel = MyTransfrom.FindChild("UICamera").FindChild("Bottom").FindChild("PlayerPanel");
        EnemyPannel = MyTransfrom.FindChild("UICamera").FindChild("TopRight").FindChild("EnemyPanel");
        TransArray_PlayerChara = new Transform[3];
        TransArray_EnemyChara = new Transform[3];
        Lab_PlayerCurHP = new UILabel[3];
        Lab_EnemyCurHP = new UILabel[3];
        for (int i = 0; i < 3; i++)
        {
            //player
            TransArray_PlayerChara[i] = PlayerPannel.FindChild(string.Format("Chara{0}", i));
            Lab_PlayerCurHP[i] = TransArray_PlayerChara[i].FindChild("Health").FindChild("hp").GetComponent<UILabel>();
            //enemy
            //TransArray_EnemyChara[i] = EnemyPannel.FindChild(string.Format("Chara{0}", i));
            //Lab_EnemyCurHP[i] = TransArray_EnemyChara[i].FindChild("Health").FindChild("hp").GetComponent<UILabel>();
        }
        RefreshHPUI();
    }
    /// <summary>
    /// 刷新場上腳色血量
    /// </summary>
    public static void RefreshHPUI()
    {
        for(int i=0;i<3;i++)
        {
            //Player
            Lab_PlayerCurHP[i].text = FightScene.PCharaList[i].CurHP.ToString();
            //Enemy
            //Lab_EnemyCurHP[i].text = FightScene.ECharaList[i].CurHP.ToString();
        }
    }
}
