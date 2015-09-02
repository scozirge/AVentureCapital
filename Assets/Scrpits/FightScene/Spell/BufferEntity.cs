using UnityEngine;
using System.Collections;

public class BufferEntity : MonoBehaviour
{//BufferEntity為腳色物件的子物件，代表此腳色身上中的效果

    //此狀態實體所對應到的狀態效果
    public Buffer RelyBuffer { get; private set; }
    //戰鬥每輪經過的單位時間，同FightTimeRoundUnits的值
    const float TimeUnit = 0.1f;
    //狀態結束剩餘的時間
    float RemainTime;
    //是否有觸發效果
    bool IsTriggerBuffer;
    //效果觸發剩餘時間
    float RemainTriggerTime;
    /// <summary>
    /// 設定Buffer實體
    /// </summary>
    public void IniBuffer(Buffer _buffer)
    {
        RelyBuffer = _buffer;
        RemainTime = RelyBuffer.Duration;
        //如果剩餘的觸發時間等於0，才執行重置剩餘時間，避免此狀態快觸發效果時因為又被賦予此狀態而又重置觸發效果時間
        if (RemainTriggerTime==0)
            RemainTriggerTime = RelyBuffer.Circle;
        //判斷此狀態是否擁有觸發效果
        if (_buffer.Circle >= 0.1f && (_buffer.TriggerDamage != null || _buffer.TriggerCure != null))
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
        if (RemainTime > 0)
        {
            //如果此狀態是觸發效果才執行觸發判斷
            if (IsTriggerBuffer)
            {
                RemainTriggerTime -= TimeUnit;
                if (RemainTriggerTime <= 0)
                    Trigger();
            }
            RemainTime -= TimeUnit;
        }
        else
        {
            Destroy(gameObject);
            RelyBuffer.Target.RemoveBuffer(RelyBuffer.ID);
            Debug.LogError("此狀態被移除");
        }
    }
    //觸發效果
    public void Trigger()
    {
        Debug.Log("觸發狀態引發的效果(傷害/治癒)");
        //觸發傷害
        if (RelyBuffer.TriggerDamage != null)
            RelyBuffer.TriggerDamage.Execute();
        //觸發治癒
        if (RelyBuffer.TriggerCure != null)
            RelyBuffer.TriggerCure.Execute();
        //重設觸發剩餘時間
        RemainTriggerTime += RelyBuffer.Circle;
        if (RemainTriggerTime <= 0)
        {
            Debug.LogWarning("效果觸發週期小於最小單位時間");
            RemainTriggerTime = RelyBuffer.Circle;
        }

    }
}
