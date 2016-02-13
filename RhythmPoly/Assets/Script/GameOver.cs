using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Invoke ("gameover",120f);
	}

	void gameover() {
		Application.LoadLevel("rank");
	}
}
