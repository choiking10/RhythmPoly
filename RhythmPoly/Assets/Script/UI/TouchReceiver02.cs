using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TouchReceiver02 : MonoBehaviour
{
    public GameObject gameOverUI;

    public int count = 0;
    public int score = 0;
    public PolygonSpawn ps;
    public Polygon userPoly;
    public LevelDisign level;
    public static float finalScore;
    public static int endScore;
    public Text scorelabel;

    //맞힌 개수
    public static int match_number;
    //맞다는 기준
    public float cutline = 0f;
    //맞을때마다 점수
    public int scorevalue = 1;
    //stage올리는 기준
    public int[] stageUp;

    bool isCorrectPoly = true;

    void Start()
    {
    	finalScore = 0;
    	endScore = 0;
        scorelabel.text = "0";
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
            if (front.GetComponent<PolygonProperty>().kind == userPoly.lastPoly )
            {
                Debug.Log("hello");
                finalScore += scorevalue;
                match_number++;
                level.matchPoly();
                front.AddComponent<PolygonAccpet>();
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
                gameOverUI.GetComponent<ActivateUI>().EnabledAll();
                gameOverUI.GetComponentInChildren<ViewAd>().init(endScore);
            }
        }

    }
    void FixedUpdate()
    {
        GameObject front = ps.GetFrontObject();
        endScore = (int)finalScore;
        if (front != null && front.transform.localPosition.z >= userPoly.transform.localPosition.z)       //
        {
            ps.RemoveFrontObject();
            //SceneManager.LoadScene("endScene");
            gameOverUI.GetComponent<ActivateUI>().EnabledAll();
            gameOverUI.GetComponentInChildren<ViewAd>().init(endScore);
        }

        scorelabel.text = endScore.ToString();
    }


    public void TouchPause()
    {
        Time.timeScale = 0;
        PolySoundManager.PauseAudio();
        Debug.Log("touch Pause");
    }
    public void TouchResume()
    {
        PolySoundManager.UnPauseAudio();
        Time.timeScale = 1;
        Debug.Log("TouchResume");
    }
}
