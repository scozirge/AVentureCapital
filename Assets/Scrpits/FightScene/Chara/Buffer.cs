using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract partial class Chara : MonoBehaviour
{
    static GameObject Prefab_BufferEntity = Resources.Load<GameObject>("GameObjects/FightScene/Chara/BufferDumy");
    GameObject Go_BufferEntity;
    Transform Trans_BufferList;
    BufferEntity Com_BufferEntity;
    //腳色擁有的Buffer字典
    Dictionary<int, List<BufferEntity>> BufferDic;
    /// <summary>
    /// 初始化Buffer
    /// </summary>
    void IniBuffer()
    {
        Trans_BufferList = MyTransform.FindChild("BufferList");
        BufferDic = new Dictionary<int, List<BufferEntity>>();
    }
    /// <summary>
    /// 腳色取得Buffer狀態，傳入Buffer狀態
    /// </summary>
    public virtual void GetBuffer(Buffer _buffer)
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
            Com_BufferEntity.IniBuffer(_buffer);
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
                Com_BufferEntity.IniBuffer(_buffer);
                BufferDic[_buffer.ID].Add(Com_BufferEntity);
            }
            else//如果此狀態不可疊加
            {
                BufferDic[_buffer.ID][0].IniBuffer(_buffer);
            }
        }
    }
    public void RemoveBuffer(int _bufferID)
    {
        if (!BufferDic.ContainsKey(_bufferID))
        {
            Debug.LogWarning(string.Format("嘗試移除腳色沒擁有的BufferID({0})", _bufferID));
            return;
        }
        if(BufferDic[_bufferID].Count==0)
        {
            Debug.LogWarning(string.Format("移除Buffer(0)時，發生腳色身上的BufferID清單長度為0)", _bufferID));
            return;
        }
        //將Buffer字典裡此ID的buffer清單最早加入的Buffer清掉;
        BufferDic[_bufferID].RemoveAt(0);
        //如果清單長度為0，代表已經沒有此BufferID的狀態，將此BufferID從字典中移除
        if (BufferDic[_bufferID].Count == 0)
            BufferDic.Remove(_bufferID);
    }
}
