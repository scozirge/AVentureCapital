using UnityEngine;
using System.Collections;

public class ExecuteComFactory : MonoBehaviour
{
    public static ExecuteCom GetCom(ExecuteType _type)
    {
        switch (_type)
        {
            case ExecuteType.Damage:
            case ExecuteType.Cure:
            case ExecuteType.Buffer:
                break;
        }
        return null;
    }
}
