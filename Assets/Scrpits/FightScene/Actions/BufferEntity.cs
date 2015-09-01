using UnityEngine;
using System.Collections;

public class BufferEntity : MonoBehaviour
{//BufferEntity為腳色物件的子物件，代表此腳色身上中的效果

    //此狀態實體所對應到的狀態效果
    public Buffer RelyBuffer { get; private set; }
    //戰鬥每個影格單位時間
    const float TimeUnit = 1;
    //狀態結束剩餘的時間
    public float RemainTime { get; set; }
    //效果觸發剩餘時間
    public float RemainTriggerTime { get; set; }
    /// <summary>
    /// 設定Buffer實體
    /// </summary>
    void SetBuffer(Buffer _buffer)
    {
        RelyBuffer = _buffer;
        RemainTime = RelyBuffer.Duration;
        //如果此狀態觸發效果會初始觸發，則設定觸發效果剩餘時間為0
        if (RelyBuffer.IniTrigger)
            RemainTriggerTime = 0;
        else
            RemainTriggerTime = RelyBuffer.Circle;
    }
    /// <summary>
    /// 執行檢查，計算經過時間並檢查是否觸發效果或結束狀態
    /// </summary>
    public void ExecuteCheck()
    {
        if (RemainTime > 0)
        {
            if (RemainTriggerTime>0)
            {
                RemainTriggerTime -= TimeUnit;
            }
            else
            {
                //RelyBuffer.TriggerDamage.Execute();
                RemainTriggerTime = RelyBuffer.Circle;
            }
            RemainTime -= TimeUnit;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
