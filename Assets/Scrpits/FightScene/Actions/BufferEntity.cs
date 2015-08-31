using UnityEngine;
using System.Collections;

public class BufferEntity : MonoBehaviour
{//BufferEntity為腳色物件的子物件，代表此腳色身上中的效果
    //此狀態實體所對應到的狀態效果
    public Buffer RelyBuffer { get; private set; }
    //狀態結束的時間
    public float EndTime { get; private set; }
    //已經過時間
    public float PassTime { get; private set; }
    /// <summary>
    /// 設定Buffer實體
    /// </summary>
    void SetBuffer(Buffer _buffer)
    {
        RelyBuffer = _buffer;
    }
}
