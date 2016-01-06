using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Protector : Equipment
{
    public ProtectorType ProType;
    /// <summary>
    /// 初始化武器，傳入武器ID
    /// </summary>
    public Protector(int _protectorID)
        : base(_protectorID)
    {
        Type = EquipmentTYpe.Protector;
        if (!GameDictionary.ProtectorDic.ContainsKey(ID))
        {
            Debug.LogWarning("不存在的護具ID:" + ID);
            return;
        }
        ProtectorData protectorData = GameDictionary.ProtectorDic[ID];
        InitEquipment(protectorData);
        ProType = protectorData.Type;
    }
}
