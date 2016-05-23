using UnityEngine;
using System.Collections;

public class ColorPicker
{
    static Color[] Selector = null;
    static int[] RawColor = new int[]{
        0x556789, 0xFFC0B1, 0x7BBDEF, 0xFF9966, 0x9DEDBF,
        0xF4ACDA, 0xABAAEC, 0x62CC86, 0x567C89, 0xFCEA9F
    };

    private static void initColor()
    {
        Selector = new Color[RawColor.Length];
        for (int i = 0; i < RawColor.Length; i++)
            Selector[i] = MakeColor(RawColor[i]);
    }
    private static Color MakeColor(int raw)
    {
        Color ret = new Color();
        float[] tmpval = new float[3];
        for (int j = 0; j < 3; j++)
        {
            tmpval[j] = (raw & (0xff0000 >> (8 * j))) >> 8 * (2 - j); // Color 검출 코드
            ret = new Color(tmpval[0] / 0xff, tmpval[1] / 0xff, tmpval[2] / 0xff);
        }
        return ret;
    }
    static public Color GetColor(int idx){
        if (Selector == null) initColor();
        if (idx < 0) idx *= -1;
        idx %= Selector.Length;
        return Selector[idx];
    }
    
}
