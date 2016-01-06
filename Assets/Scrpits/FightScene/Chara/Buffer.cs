using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract partial class Chara : MonoBehaviour
{
    GameObject Go_BufferEntity;
    Transform Trans_BufferList;
    //有效時間性Buffer
    Dictionary<int, List<BufferEntity>> BufferDic;//腳色擁有的Buffer字典
    static GameObject Prefab_BufferEntity;
    BufferEntity Com_BufferEntity;
    //常駐性Buffer
    List<PermanentBufferEntity> PermanentBufferList;//腳色擁有的常駐Buffer清單
    static GameObject Prefab_PermanentBufferEntity;
    PermanentBufferEntity Com_PermanentBufferEntity;

    /// <summary>
    /// 初始化Buffer
    /// </summary>
    void IniBuffer()
    {
        BufferDic = new Dictionary<int, List<BufferEntity>>();
        PermanentBufferList = new List<PermanentBufferEntity>();
        Trans_BufferList = MyTransform.FindChild("BufferList");
        Prefab_BufferEntity = Resources.Load<GameObject>("GameObjects/FightScene/Chara/BufferDumy");
        Prefab_PermanentBufferEntity = Resources.Load<GameObject>("GameObjects/FightScene/Chara/PermanentBufferDumy");
    }
    /////////////////////////////////////////////有效時間性Buffer////////////////////////////////////////////////////////
    /// <summary>
    /// 腳色取得Buffer，傳入Buffer
    /// </summary>
    public virtual void ReceiveBuffer(Buffer _buffer)
    {
        if (BufferDic == null)
        {
            Debug.LogWarning("BufferDic為null");
            return;
        }
        //尚未擁有此BufferID
        if (!BufferDic.ContainsKey(_buffer.ID))
        {
            Go_BufferEntity = Instantiate(Prefab_BufferEntity, Vector2.zero, Quaternion.identity) as GameObject;
            Go_BufferEntity.transform.parent = Trans_BufferList;
            Com_BufferEntity = Go_BufferEntity.GetComponent<BufferEntity>();
            Com_BufferEntity.IniBuffer(_buffer, this);
            List<BufferEntity> TmpBufferEntityList = new List<BufferEntity>();
            TmpBufferEntityList.Add(Com_BufferEntity);
            BufferDic.Add(_buffer.ID, TmpBufferEntityList);//加入BufferDIc字典
        }
        else//已經擁有此BufferID
        {
            //如果此狀態是可疊加的
            if (_buffer.Stackable)
            {
                Go_BufferEntity = Instantiate(Prefab_BufferEntity, Vector2.zero, Quaternion.identity) as GameObject;
                Go_BufferEntity.transform.parent = Trans_BufferList;
                Com_BufferEntity = Go_BufferEntity.GetComponent<BufferEntity>();
                Com_BufferEntity.IniBuffer(_buffer, this);
                BufferDic[_buffer.ID].Add(Com_BufferEntity);
            }
            else//如果此狀態不可疊加
            {
                BufferDic[_buffer.ID][0].IniBuffer(_buffer, this);
            }
        }
    }
    /// <summary>
    /// 移除Buffer，傳入ID
    /// </summary>
    public void RemoveBuffer(int _bufferID)
    {
        if (!BufferDic.ContainsKey(_bufferID))
        {
            Debug.LogWarning(string.Format("嘗試移除腳色沒擁有的BufferID({0})", _bufferID));
            return;
        }
        if (BufferDic[_bufferID].Count == 0)
        {
            Debug.LogWarning(string.Format("移除Buffer(0)時，發生腳色身上的BufferID清單長度為0)", _bufferID));
            return;
        }
        //將Buffer字典裡此ID的buffer清單中最早加入的Buffer清掉;
        BufferDic[_bufferID].RemoveAt(0);
        //如果清單長度為0，代表已經沒有此BufferID的狀態，將此BufferID從字典中移除
        if (BufferDic[_bufferID].Count == 0)
        {
            Debug.LogWarning("移除_bufferID=" + _bufferID);
            BufferDic.Remove(_bufferID);
        }
    }
    //////////////////////////////////////////////////常駐性Buffer//////////////////////////////////////////////////////
    /// <summary>
    /// 腳色取得常駐性Buffer，傳入Buffer
    /// </summary>
    public virtual void ReceivePermanentBuffer(Buffer _buffer)
    {
        if (PermanentBufferList == null)
        {
            Debug.LogWarning("PermanentBufferList為null");
            return;
        }
        Go_BufferEntity = Instantiate(Prefab_PermanentBufferEntity, Vector2.zero, Quaternion.identity) as GameObject;
        Go_BufferEntity.transform.parent = Trans_BufferList;
        Com_PermanentBufferEntity = Go_BufferEntity.GetComponent<PermanentBufferEntity>();
        Com_PermanentBufferEntity.IniBuffer(_buffer, this);
        PermanentBufferList.Add(Com_PermanentBufferEntity);
    }
    /// <summary>
    /// 移除PermanentBuffer，傳入ID
    /// </summary>
    public void RemovePermanentBuffer(int _bufferID)
    {
        bool result = false;
        for (int i = 0; i < PermanentBufferList.Count;i++ )
        {
            if(PermanentBufferList[i].RelyBuffer.ID==_bufferID)
            {
                PermanentBufferList.RemoveAt(i);
                result = true;
                break;
            }
        }
        if (!result)
            Debug.LogWarning(string.Format("找不到要清除的常駐性BufferID({0})", _bufferID));
    }
}
