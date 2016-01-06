using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player
{
    public static MainChara[] MyCharas;
    public static void Init()
    {
        MyCharas = new MainChara[3];
        MyCharas[0] = new MainChara(0, GameDictionary.TmpChara1Dic);
        MyCharas[1] = new MainChara(1, GameDictionary.TmpChara2Dic);
        MyCharas[2] = null;
    }
}
