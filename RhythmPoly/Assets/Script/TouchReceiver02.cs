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
	public static float finalScore;
	public UILabel scorelabel;
	public UILabel combolabel;
	public UISprite combosprite;
	int combo;
	public float[] scoreboard;
	bool isCorrectPoly = true;

    void Start()
    {
        AllFalse();
		scoreboard = new float[10];
		scoreboard [0] = 1.1f;
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
        if (front != null && front.transform.localPosition.z >= 0.06)
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
						combo = 0;
						AllFalse ();
						scoreList [0].SetActive (true);
						finalScore += 0;
                    }
                    else if (front.transform.localPosition.z < -1.5f)
                    {
						combo++;
						AllFalse ();
						scoreList [1].SetActive (true);
						finalScore += 50*Mathf.Pow(scoreboard [0],combo);
                    }
                    else if (front.transform.localPosition.z < -0.5f)
                    {
						combo++;
						AllFalse ();
						scoreList [2].SetActive (true);
						finalScore += 100*Mathf.Pow(scoreboard [0],combo);
                    }
                    else if (front.transform.localPosition.z < 0.05f)
                    {
						combo++;
						AllFalse ();
						scoreList [3].SetActive (true);
						finalScore += 200*Mathf.Pow(scoreboard [0],combo);
                    }
				}
                ps.RemoveFrontObject();
			}
		}
        IsAttached = false;
        IsDetached = false;
		scorelabel.text = finalScore.ToString ();
		combolabel.text = combo.ToString ();
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
