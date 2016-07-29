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
        string s = "InGameScene";
        s = "tuto_develop";
        StartCoroutine(Load(s));
    }
    IEnumerator Load(string scene)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

        while (!async.isDone)
        {
            yield return true;
        }
    }
}
