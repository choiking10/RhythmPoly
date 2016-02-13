using UnityEngine;
using System.Collections;
using RhythmPoly.Common;
public class MainCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //ZPlayerPrefs.Initialize("UnitoneGames", "unitonepwpw75");
        //ZPlayerPrefs.SetString("score", "5");

        //Debug.Log(ZPlayerPrefs.GetString("score
        UserInfo.Instance.Score = 10;
        Debug.Log(UserInfo.Instance.Score); 
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
