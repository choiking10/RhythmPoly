using UnityEngine;
using System.Collections;

public class Down : MonoBehaviour {
    public enum ANGLE_DIRECTION{
        CLOCK_WISE, COUNTER_CLOCK_WISE
    };
    public float speed;             //  하강 속도
    public float angspeed;          //  회전 속도
    public ANGLE_DIRECTION angdir;
    private Vector3 startVertex;
    private Vector3 mousePos;
	// Use this for initialization
	void Start () {
        startVertex = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pvec = gameObject.transform.position;
        if (gameObject.transform.localPosition.z < 0)
        {
            gameObject.transform.localPosition += new Vector3(0, 0, speed);
         //   gameObject.transform.localScale -= new Vector3(speed, speed, 0);
            gameObject.transform.localEulerAngles += new Vector3(0, 0, angspeed);
        }
	}
}
