using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndSceneButtonListener : MonoBehaviour 
{
    public GameObject loading;
    IEnumerator Load()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("InGameScene");
       
        while (!async.isDone)
        {
            yield return true;
        }
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("InGameScene");
        loading.SetActive(true);
        Load();
    }

    public void GoogleRanking()
    {

    }
    
}
