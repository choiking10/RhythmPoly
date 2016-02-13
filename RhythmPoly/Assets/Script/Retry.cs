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
		float f = TouchReceiver02.finalScore;
		int num = (int)f;
		perfect.text = TouchReceiver02.perfect.ToString ();
		great.text = TouchReceiver02.great.ToString ();
		good.text = TouchReceiver02.good.ToString ();
		miss.text = TouchReceiver02.miss.ToString ();
		score.text = num.ToString ();
	}
	
	// Update is called once per frame
	public void OnClick () {
		Application.LoadLevel("InGameScene");
	}
}
