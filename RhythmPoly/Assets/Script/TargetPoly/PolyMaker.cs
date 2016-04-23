using UnityEngine;
using System.Collections;
using System.IO;
public class PolyMaker : MonoBehaviour {
    public bool startFlag = false;
    public StreamWriter sw;
    public AudioSource au;
    public int deltime;
    void Start()
    {
        //sw = File.CreateText(Application.dataPath + "/test");
        //Debug.Log(Application.dataPath);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            if(Input.GetKey(KeyCode.Z)){
                //timeline	speed	angspeed	angdir	camera_shake	camera_shake_dir	limit_change
                sw.WriteLine(""+deltime + ",2,1,0,0,0,2");
                
            }
            if(Input.GetKey(KeyCode.S)){
                au.Play();
                deltime = 0;
            }
            if(Input.GetKey(KeyCode.E)){
                sw.Flush();
                sw.Close();
            }
        }
	}
    void FixedUpdate()
    {
        deltime += (int)(Time.fixedDeltaTime * 1000f);
    }
}
