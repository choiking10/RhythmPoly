using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Title_PlayButton : MonoBehaviour {
    public GameObject loading;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Push(){
        loading.SetActive(true);
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("InGameScene");

        while (!async.isDone)
        {
            yield return true;
        }
    }
}
