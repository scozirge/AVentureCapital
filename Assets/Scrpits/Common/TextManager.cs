using UnityEngine;
using System.Collections;

public class TextManager
{
    /// <summary>
    /// 字串以字元分割轉int陣列
    /// </summary>
    public static int[] StringSplitToIntArray(string _str, char _char)
    {
        int[] result;
        string[] resultStr = _str.Split(_char);
        result = new int[resultStr.Length];
        for (int i = 0; i < resultStr.Length; i++)
        {
            result[i] = int.Parse(resultStr[i]);
        }
        return result;
    }
    /// <summary>
    /// 字串以字元分割轉字串陣列
    /// </summary>
    public static string[] StringSplitToStringArray(string _str, char _char)
    {
        string[] result = _str.Split(_char);
        return result;
    }
    /// <summary>
    /// int陣列轉字串並以字元分割
    /// </summary>
    /// <returns></returns>
    public static string IntArrayToStringSplitByChar(int[] _ints, char _char)
    {
        string result = "";
        for (int i = 0; i < _ints.Length; i++)
        {
            if (i != 0)
                result += _char;
            result += _ints[i].ToString();
        }
        return result;
    }
}
