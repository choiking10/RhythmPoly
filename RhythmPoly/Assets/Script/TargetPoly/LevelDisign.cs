using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelDisign : MonoBehaviour
{
    public float[] spawnSpeed;
    public float[] fallingSpeed;
    public int[] limitAngLevel;
    public int[] matchLeveling;
    public Vector3[] cameraLimit;
    public int plevel;
    public int match_number;

    public PolygonSpawn spawner;
    public CameraMovement cameraMV;

    void Start(){

        matchLeveling = new int[20];
        limitAngLevel = new int[20];
        spawnSpeed = new float[20];
        fallingSpeed = new float[20];
        cameraLimit = new Vector3[20];

        for (int i = 0; i < matchLeveling.Length; i++)
            matchLeveling[i] = 5 + i * 5;
         for (int i = 0; i < limitAngLevel.Length; i++)
            limitAngLevel[i] = 2 +  i/6;
        matchLeveling[0] = 1;
        for (int i = 0; i < spawnSpeed.Length; i++)
        {
            spawnSpeed[i] = 3 - (i / 2 * 0.25f);
            fallingSpeed[i] = 3 - (i / 2 * 0.25f);
        }
        cameraLimit[0] = new Vector3(10, 10, 10);
        cameraLimit[1] = new Vector3(10, 10, 10);

        for (int i = 2; i < cameraLimit.Length; i++)
            cameraLimit[i] = new Vector3(20 + 10 * ((i - 2) / 3),20 + 10 * ((i - 2) / 3),20 + 10 * ((i - 2) / 3));
        
        plevel = 0;

        commit();
    }
    public int getLevel()
    {
        return plevel;
    }
    public void commit()
    {
        if (plevel >= spawnSpeed.Length) return;
        Debug.Log("commit level");
        spawner.SetLevel(limitAngLevel[plevel], spawnSpeed[plevel], fallingSpeed[plevel]);
        cameraMV.limit = cameraLimit[plevel];
    }
    public void matchPoly(){
        match_number++;
        if (plevel >= spawnSpeed.Length) return;
        if (match_number > matchLeveling[plevel])
        {
            plevel++;
            commit();
        }
    }
   
}
