using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour {

	public UILabel perfect;
	public UILabel great;
	public UILabel good;
	public UILabel miss;
	public UILabel score;

	// Use this for initialization
	void Start () {
		float f = TouchReceiver02.endScore;
		int num = (int)f;
		perfect.text = TouchReceiver02.perfect.ToString ();
		great.text = TouchReceiver02.great.ToString ();
		good.text = TouchReceiver02.good.ToString ();
		miss.text = TouchReceiver02.miss.ToString ();
		score.text = num.ToString ();
	}

	public void Update() {
		//Application.LoadLevel("InGameScene");
		if (Input.anyKeyDown) {
			TouchReceiver02.finalScore = 0;
			TouchReceiver02.endScore = 0;
			TouchReceiver02.miss = 0;
			TouchReceiver02.good = 0;
			TouchReceiver02.great = 0;
			TouchReceiver02.perfect = 0;
			Application.LoadLevel("InGameScene");
		}
	}
}
