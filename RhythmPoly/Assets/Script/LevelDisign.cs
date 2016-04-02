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
        
        matchLeveling    = new int[]{5  ,10 ,15 ,20 ,25 ,30 ,35 ,40 ,45 ,50};
        limitAngLevel    = new int[]{1  ,2  ,3  ,3 , 3  ,4  ,4  ,4  ,4  ,4};

        spawnSpeed      = new float[] { 3f, 3f, 2.75f, 2.75f, 2.5f, 2.5f, 2f, 1.5f, 1f, 1f };
        fallingSpeed    = new float[] { 3f, 3f, 2.75f, 2.75f, 2.5f, 2.5f, 2f, 1.5f, 1f, 1f };


        cameraLimit = new Vector3[]{
            new Vector3(0,0,0),
            new Vector3(0,0,0),
            new Vector3(10,10,10),
            new Vector3(10,10,10),
            new Vector3(20,20,20),
            new Vector3(20,20,20),
            new Vector3(30,30,30),
            new Vector3(30,30,30),
            new Vector3(40,40,40),
            new Vector3(40,40,40)
        };
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
