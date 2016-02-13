using UnityEngine;
using System.Collections;

public class PolygonMovement : MonoBehaviour {
    public enum ANGLE_DIRECTION{
        CLOCK_WISE, COUNTER_CLOCK_WISE
    };
    public const float UNIT = 15;
    public float speed;             //  하강 속도 1초만에 이동 2초만에 이동...
    public float angspeed;          //  회전 속도  1번회전 2번 회전 ...
    public float bounds;            //  바운스 비율
    public float pathz;             // 하강 경로 변동 비율
    public ANGLE_DIRECTION angdir;
    public float nu;
    public float tnu;
	// Use this for initialization
	void Start () {
        nu = 0;
        tnu = 0;
	}
    void FixedUpdate()
    {
        float rspeed = SpeedFunction();
        if (gameObject.transform.localPosition.z < 0)
        {
            gameObject.transform.localPosition += new Vector3(0, 0, rspeed);
            gameObject.transform.localEulerAngles += new Vector3(0, 0, AngleSpeedFunction());
            
            /* Debug code */
            nu += rspeed;
            tnu += Time.fixedDeltaTime;
        }
        if (gameObject.transform.localPosition.z > 0)
        {
            Vector3 vec = gameObject.transform.localPosition;
            vec.z = 0;
            gameObject.transform.localPosition = vec;
            gameObject.transform.localEulerAngles = Vector3.zero;

            /* Debug code */
            Debug.Log(nu);
            nu = 0;
            Debug.Log(tnu);
            tnu = 0;
        }
    }
    float SpeedFunction()
    {
        return UNIT / speed * Time.fixedDeltaTime; // 타이밍이 ㅠ 
    }
    float AngleSpeedFunction()
    {
        float ret = (360 * angspeed) / speed * Time.fixedDeltaTime;

        switch (angdir)
        {
            case ANGLE_DIRECTION.CLOCK_WISE :
                ret = ret * -1;
                break;
            case ANGLE_DIRECTION.COUNTER_CLOCK_WISE :
                break;
        }
        return ret;
    }
}
