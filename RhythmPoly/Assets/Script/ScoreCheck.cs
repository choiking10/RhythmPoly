using UnityEngine;
using System.Collections;

public class ScoreCheck : MonoBehaviour {
	public GameObject poly;
	public GameObject score;
	bool isCorrectPoly = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			if (isCorrectPoly) {
				if (poly.transform.localPosition.z < -5)
					score.SetActive (true);
				else if (poly.transform.localPosition.z < -3)
					Debug.Log ("good");
				else if (poly.transform.localPosition.z < -1)
					Debug.Log ("great");
				else if (poly.transform.localPosition.z < 0.005)
					Debug.Log ("perfect");
				else if (poly.transform.localPosition.z < 1)
					Debug.Log ("great");
			}
		}
	}
}
