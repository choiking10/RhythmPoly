using UnityEngine;
using System.Collections;

public enum ANGLE_DIRECTION
{
    CLOCK_WISE, COUNTER_CLOCK_WISE
};
public class PolygonMovement : MonoBehaviour {
   
    public const float UNIT = 10;
    public float speed;             //  After 'speed' seconds reaches
    public float angspeed;          //  'angspeed' time rotation per falling
    public ANGLE_DIRECTION angdir;  //  Direction of rotation

    public float bounce;            //  bounce ratio
    public float pathz;             // Descending path variable ratio

    public bool initflag = false;
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
            /* falling */
            if (gameObject.transform.localPosition.z < 0)
                fallingRoutine();

            /* Destroy */
            if (gameObject.transform.localPosition.z > 0)
                DestroyRoutine();
        }
    }


    void fallingRoutine()
    {
        gameObject.transform.localPosition += new Vector3(0, 0, SpeedFunction());
        gameObject.transform.localEulerAngles += new Vector3(0, 0, AngleSpeedFunction());

        /* Debug code */
        tnu += Time.fixedDeltaTime;
    }
    void DestroyRoutine()
    {
        Vector3 vec = gameObject.transform.localPosition;
        vec.z = 0;
        gameObject.transform.localPosition = vec;
        gameObject.transform.localEulerAngles = Vector3.zero;

        /* Debug code */
        Debug.Log(tnu);

        /* Destroy gameObject  => can be change*/
        GameObject.Destroy(gameObject);
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
}
