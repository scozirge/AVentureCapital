using UnityEngine;
using System.Collections;

public class MilestoneController : MonoBehaviour
{
    //冒險
    AdventureData MyAdventure;
    //物件
    static RectTransform RTransfrom;
    static GameObject Prefab_Milestone;
    static GameObject[] Go_Milestones;
    static Milestone[] MileStones;
    //里程碑參數
    static Vector2 Vol = new Vector2(10, 0);//行進速度
    static Vector2 StartPos = new Vector2(-400, -200);//起始位置
    static Vector2 NextPos;//移動後下一個座標
    static Vector2 MileDist_Vec = new Vector2(10, 0);//一個里程的距離為10
    public const byte MileDist = 10;//一個里程的距離為10
    const byte MinMileDist = 20;//里程碑之間的最小距離為20個里程
    public static int Mile;//移動了多少個里程
    public static int MaxMIle;//終點里程

    static MilestoneEvent[] Events;//事件陣列
    static int[] EventMiles;//有事件的里程
    static bool[] UnknownEvents;//事件會顯示為未知的陣列
    static byte EventCount;//有幾個事件
    static byte NextEvent;//下一個事件索引

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init(AdventureData _adventure, MilestoneEvent[] _events, int[] _eventMiles, bool[] _unknownEvents)
    {
        MyAdventure = _adventure;
        RTransfrom = transform.GetComponent<RectTransform>();
        RTransfrom.anchoredPosition = StartPos;
        NextEvent = 1;
        Events = _events;
        EventMiles = _eventMiles;
        UnknownEvents = _unknownEvents;
        EventCount = (byte)_events.Length;
        if (EventMiles.Length != EventCount || UnknownEvents.Length != EventCount || _unknownEvents.Length == 0)
        {
            Debug.LogWarning("傳入的事件數量錯誤");
            return;
        }
        SpawnMilestone();
        //里程設定
        Mile = 0;
        MaxMIle = EventMiles[EventCount - 1];
    }
    /// <summary>
    /// 產生里程碑物件
    /// </summary>
    void SpawnMilestone()
    {
        Prefab_Milestone = Resources.Load<GameObject>("GameObjects/FightScene/UI/Milestone");
        //產生的物件數為EventCount+1，因為要多加出發的城鎮
        Go_Milestones = new GameObject[EventCount];
        MileStones = new Milestone[EventCount];
        for (byte i = 0; i < Go_Milestones.Length; i++)
        {
            Go_Milestones[i] = Instantiate(Prefab_Milestone, Vector2.zero, Quaternion.identity) as GameObject;
            Go_Milestones[i].transform.SetParent(RTransfrom);
            MileStones[i] = Go_Milestones[i].GetComponent<Milestone>();
            MileStones[i].Init(Events[i], EventMiles[i], UnknownEvents[i]);
        }
    }
    /// <summary>
    /// 前進
    /// </summary>
    public void GoForward()
    {
        NextPos = RTransfrom.anchoredPosition - Vol;
        if (NextPos.x <= (StartPos.x - EventMiles[NextEvent] * MileDist))
        {
            Mile = EventMiles[NextEvent];
            RTransfrom.anchoredPosition = StartPos - Mile * MileDist_Vec;
            FightScene.SetMile(Mile);
            TriggerEvent();//觸發事件
        }
        else
        {
            RTransfrom.anchoredPosition -= Vol;
            SetMile();
            FightScene.SetMile(Mile);
        }
    }
    /// <summary>
    /// 設定里程數
    /// </summary>
    public void SetMile()
    {
        Mile = (int)(Mathf.Abs((RTransfrom.anchoredPosition.x - StartPos.x) / MileDist));
    }
    /// <summary>
    /// 觸發事件
    /// </summary>
    void TriggerEvent()
    {
        switch (Events[NextEvent])
        {
            case MilestoneEvent.Monster:
                FightScene.MeetEnemy(MonsterGetter.GetMonsterDicsFromEvent(MyAdventure.MonsterEvent));//遭遇敵人
                break;
            case MilestoneEvent.Accident:
                CharaDataUI.ShowCharas(false);//隱藏腳色資料介面
                AccidentUI.CallAccident(EventGetter.GetAccidentInGroup(MyAdventure.AccidentGroup));//呼叫意外事件
                FightScene.AccidentEvent();//遭遇意外事件
                break;
            case MilestoneEvent.Investigate:
                CharaDataUI.ShowCharas(false);//隱藏腳色資料介面
                InvestigateUI.CallInvestigate(EventGetter.GetInvestigateInGroup(MyAdventure.InvestigateGroup));//呼叫調查事件
                FightScene.InvestigateEvent();//遭遇調查事件
                break;
            case MilestoneEvent.Camp:
                CharaDataUI.ShowCharas(false);//隱藏腳色資料介面
                CampUI.CallCamp(EventGetter.GetCampInGroup(MyAdventure.CampGroup));//呼叫紮營事件
                FightScene.InvestigateEvent();//遭遇調查事件
                break;
        }
        NextEvent++;
    }
}
