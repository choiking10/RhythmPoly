﻿using UnityEngine;
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

	public void Update() {
		//Application.LoadLevel("InGameScene");
		if (Input.anyKeyDown) {
			Application.LoadLevel("InGameScene");
		}
	}
}
