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

	public List<GameObject> scoreList;
	public int finalScore;
	bool isCorrectPoly = true;

    // Add Point
    public void TouchAttachPoint()
    {
		count++;
		IsAttached = true;
		IsDetached = false;
		for (int i = 0; i < 4 ; i++)
			scoreList[i].SetActive (false);
    }
    // Sub Point
    public void TouchDetachPoint()
    {
		count++;
		IsAttached = false;
		IsDetached = true;
		for (int i = 0; i < 4 ; i++)
			scoreList[i].SetActive (false);
    }

	void Update() 
	{
		AllFalse ();
		if (ps.GetFrontObject () != null) {
			if (ps.GetFrontObject ().transform.localPosition.z > 1.0f)
				ps.RemoveFrontObject ();
			
			if (Input.anyKeyDown && IsAttached == true) {
				TouchAttachPoint ();
			}
			else if (Input.anyKeyDown && IsDetached == true) {
				TouchDetachPoint ();
			}
			else if (Input.anyKeyDown) {
				if (isCorrectPoly) {
					if (ps.GetFrontObject ().transform.localPosition.z < -5.0f) {
						AllFalse ();
						scoreList [0].SetActive (true);
						finalScore += 0;
					} else if (ps.GetFrontObject ().transform.localPosition.z < -3.0f) {
						AllFalse ();
						scoreList [1].SetActive (true);
						finalScore += 1;
					} else if (ps.GetFrontObject ().transform.localPosition.z < -1.0f) {
						AllFalse ();
						scoreList [2].SetActive (true);
						finalScore += 2;
					} else if (ps.GetFrontObject ().transform.localPosition.z < 0.005f) {
						AllFalse ();
						scoreList [3].SetActive (true);
						finalScore += 3;
					} else if (ps.GetFrontObject ().transform.localPosition.z < 1.0f) {
						AllFalse ();
						scoreList [2].SetActive (true);
						finalScore += 2;
					}
				}
				ps.RemoveFrontObject ();
			}
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
