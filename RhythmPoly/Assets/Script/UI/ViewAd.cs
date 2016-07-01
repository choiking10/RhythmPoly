using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class ViewAd : MonoBehaviour 
{
    public bool flag = true;
    public Text score;
    void Start()
    {
        Advertisement.Initialize("1089505", true);
    }
    public void init(int Score)
    {
        PolySoundManager.PauseAudio();
        if (!flag)
        {
            Debug.Log("flag die");
            GoGameEnd();
            return;
        }
        Time.timeScale = 0f;
        score.text = Score + " POLY";
        StartCoroutine("WaitingUser");
        Debug.Log("nono");
    }
    IEnumerator WaitingUser()
    {
        while (true)
        {
            Color col = GetComponent<Image>().color;
            col.a += 1f/200f;
            GetComponent<Image>().color = col;
            if (col.a >= 0.99f)
            {
                Debug.Log("cor die");
                GoGameEnd();
                yield break;
            }
            yield return null;
        }
    }
    public void GoGameEnd()
    {
        StopCoroutine("WaitingUser");
        flag = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("endScene");
    }
    public void View()
    {
       
        if (Advertisement.IsReady())
        {
            StopCoroutine("WaitingUser");

            Debug.Log("view die");
            ShowOptions options = new ShowOptions();
            options.resultCallback = ViewEnd;
            Advertisement.Show(null, options);
        }
        flag = false;
    }
    public void ViewEnd(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Debug.Log("view end die");
            PolySoundManager.UnPauseAudio();
            Time.timeScale = 1f;
            transform.parent.GetComponent<ActivateUI>().DisabledAll();
            
        }
    }
    public void TouchBack()
    {
        Debug.Log("TouchBack die");
        flag = false;
        GoGameEnd();
    }

 
}