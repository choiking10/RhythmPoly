﻿using UnityEngine;
using System.Collections;

public enum ANGLE_DIRECTION
{
    CLOCK_WISE, COUNTER_CLOCK_WISE
};
public class PolygonMovement : MonoBehaviour {
   
    public const float UNIT = 10;
    public const float EFFECT_SPEED = 1f;
    public float speed;             //  After 'speed' seconds reaches
    public float angspeed;          //  'angspeed' time rotation per falling    
    public ANGLE_DIRECTION angdir;  //  Direction of rotation

    public float bounce;            //  bounce ratio
    public float pathz;             // Descending path variable ratio

    public bool initflag = false;
    public bool destroyflag = false;
    public bool perfactflag = false;
    /* Debug */
    public float nu;
    public float tnu;
	// Use this for initialization
	void Start () {
        nu = 0;
        tnu = 0;
	}
    public void init(float speed, float angspeed, ANGLE_DIRECTION dir, float bounce,float pathz)
    {
        this.speed = speed;
        this.angspeed = angspeed;
        this.angdir = dir;
        this.bounce = bounce;
        this.pathz = pathz;

        initflag = true;
    }
    void FixedUpdate()
    {
        if (initflag)
        {
            fallingRoutine();
        }
        if (destroyflag)
        {
            initflag = false;
            DestroyRoutine();
        }
        if (perfactflag)
        {
            if (initflag) Invoke("DestroyRoutine", 3f);
            initflag = false;
            PerfactRoutine();
        }
    }
    void fallingRoutine()
    {
        gameObject.transform.localPosition += new Vector3(0, 0, SpeedFunction());
        gameObject.transform.localEulerAngles += new Vector3(0, 0, AngleSpeedFunction());
        //gameObject.transform.localScale = new Vector3(1 + ScaleSpeedFunction(), 1 + ScaleSpeedFunction(), 1);
        /* Debug code */
        tnu += Time.fixedDeltaTime;
    }
    void PerfactRoutine()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(51f / 255f, 102f / 255f, 213f / 255f, 1f);
        gameObject.transform.localScale += new Vector3(EFFECT_SPEED, EFFECT_SPEED, 0);
    }
    void DestroyRoutine()
    {
        //gameObject.transform.localScale += new Vector3(EFFECT_SPEED, EFFECT_SPEED, 0);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(51f / 255f, 102f / 255f, 213f / 255f, 1f);
        Invoke("DestroySelf", 0.5f);
        destroyflag = false;
       // gameObject.transform.
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
    float SpeedFunction()
    {
        return UNIT / speed * Time.fixedDeltaTime; // 
    }
    float AngleSpeedFunction()
    {
        float ret = (360 * angspeed) / speed * Time.fixedDeltaTime;

        switch (angdir)
        {
            case ANGLE_DIRECTION.CLOCK_WISE:
                ret = ret * -1;
                break;
            case ANGLE_DIRECTION.COUNTER_CLOCK_WISE:
                break;
        }
        return ret;
    }
    float ScaleSpeedFunction()
    {
        return - gameObject.transform.localPosition.z / 10 * 1.5f;
    }
    
}
