using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreCheck : MonoBehaviour {
	public GameObject poly;
	public List<GameObject> score;
	public int finalScore;
	bool isCorrectPoly = true;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 4 ; i++)
			score[0].SetActive (false);
	}

	void AllFalse() {
		for (int i = 0; i < 4 ; i++)
			score[0].SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			if (isCorrectPoly) {
				if (poly.transform.localPosition.z < -5) {
					AllFalse ();
					score [0].SetActive (true);
					finalScore += 0;
				}
				else if (poly.transform.localPosition.z < -3) {
					AllFalse ();
					score [1].SetActive (true);
					finalScore += 1;
				}
				else if (poly.transform.localPosition.z < -1) {
					AllFalse ();
					score [2].SetActive (true);
					finalScore += 2;
				}
				else if (poly.transform.localPosition.z < 0.005) {
					AllFalse ();
					score [3].SetActive (true);
					finalScore += 3;
				}
				else if (poly.transform.localPosition.z < 1) {
					AllFalse ();
					score [2].SetActive (true);
					finalScore += 2;
				}
			}
		}
	}
}
