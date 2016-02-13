using UnityEngine;
using System.Collections;

public class PolygonData {
    public int timeline;
    public float speed;
    public int angspeed;
    public ANGLE_DIRECTION angdir;
    public int camera_shake;
    public int camera_shake_dir;
    public int limit_change;

    public PolygonData(string s)
    {
        string[] result = s.Split(',');

        timeline = int.Parse(result[0]);
        speed = float.Parse(result[1]);
        angspeed = int.Parse(result[2]);
        angdir = int.Parse(result[3]) == 0 ? ANGLE_DIRECTION.CLOCK_WISE : ANGLE_DIRECTION.COUNTER_CLOCK_WISE;
        camera_shake = int.Parse(result[4]);
        camera_shake_dir = int.Parse(result[5]);
        limit_change = int.Parse(result[6]);
    }

    public static PolygonData[] GetDataFromFile(string path)
    {
        PolygonData[] ret;
        TextAsset mesh = (TextAsset)Resources.Load(path);
        string[] s = mesh.text.Split('\n');
        ret = new PolygonData[s.Length];
        int idx = 0;
        foreach (string str in s)
        {
            if (str.Length < 10) continue;
            ret[idx] = new PolygonData(str);
            Debug.Log(idx);
            idx++;
        }
        return ret;
    }
}
