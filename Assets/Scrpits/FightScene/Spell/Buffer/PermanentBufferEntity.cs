using UnityEngine;
using System.Collections;

public class PermanentBufferEntity : MonoBehaviour
{//BufferEntity為腳色物件的子物件，代表此腳色身上中的效果
    public Chara Self;
    //此狀態實體所對應到的狀態效果
    public Buffer RelyBuffer { get; private set; }
    //戰鬥每輪經過的單位時間，同FightTimeRoundUnits的值
    const float TimeUnit = 0.1f;
    //是否有觸發效果
    bool IsTriggerBuffer;
    //效果觸發剩餘時間
    public float RemainTriggerTime;
    /// <summary>
    /// 設定Buffer實體
    /// </summary>
    public void IniBuffer(Buffer _buffer, Chara _self)
    {
        gameObject.name = string.Format("PBufferID({0})", _buffer.ID);
        Self = _self;
        RelyBuffer = _buffer;
        //不執行重置剩餘時間，避免此狀態快觸發效果時因為又被賦予此狀態而又重置觸發效果時間
        //RemainTriggerTime = RelyBuffer.Circle;            
        //判斷此狀態是否擁有觸發效果
        if (_buffer.Circle >= 0.1f && (_buffer.TriggerExecuteList != null && _buffer.TriggerExecuteList.Count != 0))
            IsTriggerBuffer = true;
        //如果可以擁有觸發效果
        if (IsTriggerBuffer)
        {
            //如果此狀態會初始觸發效果，則在初始化狀態後立刻執行觸發效果
            if (RelyBuffer.IniTrigger)
                Trigger();
        }
    }
    /// <summary>
    /// 執行檢查，計算經過時間並檢查是否觸發效果或結束狀態
    /// </summary>
    public void ExecuteCheck()
    {
        //如果此狀態是觸發效果才執行觸發判斷
        if (IsTriggerBuffer)
        {
            RemainTriggerTime -= TimeUnit;
            if (RemainTriggerTime <= 0)//剩餘觸發時間小於等於0則觸發
                Trigger();
        }
    }

    /// <summary>
    /// 觸發效果
    /// </summary>
    public void Trigger()
    {
        //執行觸發效果
        for (int i = 0; i < RelyBuffer.TriggerExecuteList.Count; i++)
        {
            RelyBuffer.TriggerExecuteList[i].Execute(Self);
        }
        //重設觸發剩餘時間
        RemainTriggerTime = RelyBuffer.Circle;
    }
}
