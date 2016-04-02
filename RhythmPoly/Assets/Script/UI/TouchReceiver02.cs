using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TouchReceiver02 : MonoBehaviour
{
    public int count = 0;
    public int score = 0;
    public PolygonSpawn ps;
    public Polygon userPoly;
    public LevelDisign level;
    public static float finalScore;
    public static int endScore;
    public Text scorelabel;
    public Text levelNumberLabel;

    //맞힌 개수
    public static int match_number;
    //맞다는 기준
    public float cutline = -0.2f;
    //맞을때마다 점수
    public int scorevalue = 10;
    //stage올리는 기준
    public int[] stageUp;

    bool isCorrectPoly = true;

    void Start()
    {
        stageUp = new int[10];
        stageUp[0] = 20;
    }
    // Add Point
    public void TouchAttachPoint()
    {
        count++;
        userPoly.AttachRoutine();
    }
    // Sub Point
    public void TouchDetachPoint()
    {
        count++;
        userPoly.DetachRoutine();
    }
    public void TouchDefault()
    {
        GameObject front = ps.GetFrontObject();
        //아무곳이나 터치했을 시
        if (front != null)
        {
            if (front.GetComponent<PolygonProperty>().kind == userPoly.lastPoly && front.transform.localPosition.z > cutline)
            {
                Debug.Log("hello");
                finalScore += scorevalue;
                front.GetComponent<PolygonMovement>().perfactflag = true;
                match_number++;
                level.matchPoly();
                ps.RemoveFrontObject();
                Debug.Log("Yeah!");
                if (match_number > stageUp[0])
                {
                    Debug.Log("stage up!!");
                }
            }
            else
            {
                ps.RemoveFrontObject();
                Application.LoadLevel("rank");
            }
        }

    }
    void FixedUpdate()
    {
        GameObject front = ps.GetFrontObject();
        if (front != null && front.transform.localPosition.z >= 0.3f)       //
        {
            ps.RemoveFrontObject();
            Application.LoadLevel("rank");
        }

        endScore = (int)finalScore;
        scorelabel.text = endScore.ToString();
        levelNumberLabel.text = ""+(level.getLevel() + 1);
    }


    public void TouchPause()
    {
        Time.timeScale = 0;
        Debug.Log("touch Pause");
    }
    public void TouchResume()
    {
        Time.timeScale = 1;
        Debug.Log("TouchResume");
    }
}
