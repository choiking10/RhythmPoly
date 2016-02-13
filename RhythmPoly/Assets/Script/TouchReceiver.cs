using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchReceiver : MonoBehaviour {
    public int count = 0;
    public UILabel la;
    public int score = 0;
    public static bool IsAttached;
    public static bool IsDetached;
	public PolygonSpawn ps;

	public List<GameObject> scoreList;
	public int finalScore;
	bool isCorrectPoly = true;

    // Add Point
    public void TouchAttachPoint()
    {
        count++;
        DoubleTouchPoint();
        IsAttached = true;
        IsDetached = false;
		for (int i = 0; i < 4 ; i++)
			scoreList[i].SetActive (false);
    }
    // Sub Point
    public void TouchDetachPoint()
    {
        count++;
        DoubleTouchPoint();
        IsAttached = false;
        IsDetached = true;
		for (int i = 0; i < 4 ; i++)
			scoreList[i].SetActive (false);
    }

    public void InitCount() 
    {
        count = 0;
    }
    public void DoubleTouchPoint() 
    {
        if (count == 2)
        {
			if (Input.anyKeyDown) {
				if (isCorrectPoly) {
					if (ps.GetFrontObject().transform.localPosition.z < -5) {
						AllFalse ();
						scoreList [0].SetActive (true);
						finalScore += 0;
					}
					else if (ps.GetFrontObject().transform.localPosition.z < -3) {
						AllFalse ();
						scoreList [1].SetActive (true);
						finalScore += 1;
					}
					else if (ps.GetFrontObject().transform.localPosition.z < -1) {
						AllFalse ();
						scoreList [2].SetActive (true);
						finalScore += 2;
					}
					else if (ps.GetFrontObject().transform.localPosition.z < - 0.005) {
						AllFalse ();
						scoreList [3].SetActive (true);
						finalScore += 3;
					}
					else if (ps.GetFrontObject().transform.localPosition.z < 1) {
						AllFalse ();
						scoreList [2].SetActive (true);
						finalScore += 2;
					}
				}
			}
            count = 0;
            return;
        }
    }

	void AllFalse() {
		for (int i = 0; i < 4 ; i++)
			scoreList[i].SetActive (false);
	}

    public void TouchPause()
    {
        Debug.Log("touch Pause");
    }
}
