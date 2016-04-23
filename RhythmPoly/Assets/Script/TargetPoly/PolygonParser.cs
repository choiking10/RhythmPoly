using UnityEngine;
using System.Collections;
using System.IO;
public class PolygonParser : MonoBehaviour {
    PolygonData[] datas;
	// Use this for initialization
	void Start () {
        TextAsset mesh = (TextAsset)Resources.Load("test_1");
        string s = mesh.text;
        foreach(string  str in s.Split('\n')){
            //timeline	speed	angspeed	angdir	camera_shake	camera_shake_dir	limit_change
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
