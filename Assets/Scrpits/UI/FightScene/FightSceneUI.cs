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
    static Transform Trans_EnemyChara;
    static UILabel Lab_EnemyCurHP;
    public void StartSet()
    {
        MyTransfrom = transform;
        //取得玩家物件
        PlayerPannel = MyTransfrom.FindChild("UICamera").FindChild("Bottom").FindChild("PlayerPanel");
        TransArray_PlayerChara = new Transform[3];
        Lab_PlayerCurHP = new UILabel[3];
        for (int i = 0; i < 3; i++)
        {
            TransArray_PlayerChara[i] = PlayerPannel.FindChild(string.Format("Chara{0}", i));
            Lab_PlayerCurHP[i] = TransArray_PlayerChara[i].FindChild("Health").FindChild("hp").GetComponent<UILabel>();
        }
        //取得敵人物件
        EnemyPannel = MyTransfrom.FindChild("UICamera").FindChild("TopRight").FindChild("EnemyPanel");
        Trans_EnemyChara = EnemyPannel.FindChild("Chara");
        Lab_EnemyCurHP = Trans_EnemyChara.FindChild("Health").FindChild("hp").GetComponent<UILabel>();
        RefreshHPUI();
    }
    /// <summary>
    /// 刷新場上腳色血量
    /// </summary>
    public static void RefreshHPUI()
    {
        //Player
        for(int i=0;i<3;i++)
        {
            Lab_PlayerCurHP[i].text = FightScene.PCharaList[i].CurHP.ToString();
        }
        //Enemy
        Lab_EnemyCurHP.text = FightScene.EChara.CurHP.ToString();
    }
}
