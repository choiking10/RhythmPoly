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
	public List<GameObject> scoreList;
	public int finalScore;
	bool isCorrectPoly = true;

    void Start()
    {
        AllFalse();
    }
    // Add Point
    public void TouchAttachPoint()
    {
		count++;
		IsAttached = true;
		IsDetached = false;
		for (int i = 0; i < 4 ; i++)
			scoreList[i].SetActive (false);
        userPoly.AttachRoutine();
        
    }
    // Sub Point
    public void TouchDetachPoint()
    {
		count++;
		IsAttached = false;
		IsDetached = true;
		for (int i = 0; i < 4 ; i++)
			scoreList[i].SetActive (false);
        userPoly.DetachRoutine();
    }

	void Update() 
	{
        GameObject front = ps.GetFrontObject();
        if (front != null && front.transform.localPosition.z >= 1)
        {
            ps.RemoveFrontObject();
            AllFalse();
            scoreList[0].SetActive(true);
            finalScore += 0;
        }

        if (front != null && !IsAttached && !IsDetached)
        {
			if (Input.anyKeyDown) {
				if (isCorrectPoly) {

                    if (front.GetComponent<PolygonProperty>().kind != userPoly.lastPoly || front.transform.localPosition.z < -5.0f)
                    {
						AllFalse ();
						scoreList [0].SetActive (true);
						finalScore += 0;
                    }
                    else if (front.transform.localPosition.z < -2.0f)
                    {
						AllFalse ();
						scoreList [1].SetActive (true);
						finalScore += 1;
                    }
                    else if (front.transform.localPosition.z < -1.0f)
                    {
						AllFalse ();
						scoreList [2].SetActive (true);
						finalScore += 2;
                    }
                    else if (front.transform.localPosition.z < 0.05f)
                    {
						AllFalse ();
						scoreList [3].SetActive (true);
						finalScore += 3;
                    }
                    else if (front.transform.localPosition.z < 1.0f)
                    {
						AllFalse ();
						scoreList [2].SetActive (true);
						finalScore += 2;
					}
				}
                ps.RemoveFrontObject();
			}
		}
        IsAttached = false;
        IsDetached = false;

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
