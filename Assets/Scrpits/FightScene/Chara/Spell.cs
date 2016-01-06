using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract partial class Chara : MonoBehaviour
{
    /*
/// <summary>
/// 初始化施法
/// </summary>
protected virtual void InitSpell()
{
PassiveSpellList = new List<PassiveSpell>();
string spellListStr = AttrsDic["SpellList"];
string[] spellIDStr = spellListStr.Split(',');
for (int i = 0; i < spellIDStr.Length; i++)
{
    int spellID = int.Parse(spellIDStr[i]);
    if (spellID == 0)
        continue;
    PassiveSpell spell = new PassiveSpell(spellID, this);
    PassiveSpellList.Add(spell);
}
}
     */
    /// <summary>
    /// 腳色狀態時間流逝，代表此腳色有時間元素的屬性都要計算經過時間，例如狀態效果的時間
    /// </summary>
    public virtual void BufferTimePass()
    {
        //如果腳色死亡，時間則不再流逝(不會觸發狀態)
        if (!IsAlive)
            return;
        //常駐狀態觸發
        for(int i=0;i<PermanentBufferList.Count;i++)
        {
            PermanentBufferList[i].ExecuteCheck();
        }
        //時效性觸發狀態
        List<int> bufferKeys = new List<int>(BufferDic.Keys);
        for (int i = 0; i < bufferKeys.Count; i++)
        {
            for (int j = 0; j < BufferDic[bufferKeys[i]].Count; j++)
            {
                BufferDic[bufferKeys[i]][j].ExecuteCheck();
                //如果在執行ExecuteCheck後發現BufferDic已經不存在ID，代表此狀態在ExecuteCheck中判定時效已過而遭刪除，所以跳出迴圈
                if (!BufferDic.ContainsKey(bufferKeys[i]))
                    break;
            }
        }
    }
    /// <summary>
    /// 施法判定
    /// </summary>
    public virtual bool SpellCheck()
    {
        //如果腳色死亡返回false，時間則不再流逝(不會執行施法)
        if (!IsAlive)
            return false;
        //施法
        for (int i = 0; i < PassiveSpellList.Count; i++)
        {
            if (PassiveSpellList[i].ExecuteCheck())//如果有要施法的清單就返回true
                return true;
        }
        return false;//如果沒要施法的清單就返回false
    }
    /// <summary>
    /// 施法時間流逝，回傳true代表此刻有多次施法
    /// </summary>
    public virtual bool SpellTimePass()
    {
        //是否有多次施法
        bool mutiSpell = false;
        //施法次數
        byte readySpellCount = 0;
        //如果腳色死亡返回true，代表腳色沒有多次施法
        if (!IsAlive)
            return mutiSpell;
        //計算要施法的次數
        for (int i = 0; i < PassiveSpellList.Count; i++)
        {
            if (!PassiveSpellList[i].ExecuteCheck())
            {
                PassiveSpellList[i].TimePass();
            }
            else
            {
                //只執行一次施法，如果有一次以上的施法要執行就先保留，等待下一次再執行
                if (readySpellCount == 0)
                    PassiveSpellList[i].TimePass();
                readySpellCount++;
            }
        }
        //如果需要施法的次數大於1代表為多次施法
        if (readySpellCount > 1)
            mutiSpell = true;
        return mutiSpell;
    }
    /// <summary>
    /// 結束腳色施法動作後呼叫
    /// </summary>
    public void EndSpell()
    {
        SetDefaultTransfrom();
        FightScene.SetAction(false);//設定結束動作
    }
}
