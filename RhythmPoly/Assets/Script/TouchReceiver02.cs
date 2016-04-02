using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchReceiver02 : MonoBehaviour
{
	public int count = 0;
	public int score = 0;
	public static bool IsAttached;
	public static bool IsDetached;
	public PolygonSpawn ps;
    public Polygon userPoly;
	public static float finalScore;
	public static int endScore;
	public UILabel scorelabel;

	//맞힌 개수
	public static int match_number;
	//맞다는 기준
	public float cutline = -0.2f;
	//맞을때마다 점수
	public int scorevalue = 10;
	//stage올리는 기준
	public int[] stageUp = new int[10];

	bool isCorrectPoly = true;

    void Start()
    {
		stageUp [0] = 20;
    }
    // Add Point
    public void TouchAttachPoint()
    {
		count++;
		IsAttached = true;
		IsDetached = false;
        userPoly.AttachRoutine();
    }
    // Sub Point
    public void TouchDetachPoint()
    {
		count++;
		IsAttached = false;
		IsDetached = true;
        userPoly.DetachRoutine();
    }

	void Update() 
	{
        GameObject front = ps.GetFrontObject();
        if (front != null && front.transform.localPosition.z >= 0.3f)
		{
            ps.RemoveFrontObject();
			Application.LoadLevel("rank");
        }
        else if (front != null && !IsAttached && !IsDetached)
        {
			if (Input.anyKeyDown) {
				if (front.GetComponent<PolygonProperty> ().kind == userPoly.lastPoly && front.transform.localPosition.z > cutline) {
					finalScore += scorevalue;
					front.GetComponent<PolygonMovement> ().perfactflag = true;
					match_number++;
					if (match_number > stageUp [0]) {
						Debug.Log ("stage up!!");
					}
				}
				else {
					ps.RemoveFrontObject ();
					Application.LoadLevel ("rank");
				}
			} 
		}
        IsAttached = false;
        IsDetached = false;
		endScore = (int)finalScore;
		scorelabel.text = endScore.ToString ();
	}

    public void TouchPause()
    {
        Debug.Log("touch Pause");
    }
}
