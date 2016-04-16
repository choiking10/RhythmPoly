using UnityEngine;
using System.Collections;

public class EndSceneButtonListener : MonoBehaviour 
{
    public void Retry()
    {
        Application.LoadLevel("InGameScene");
        Debug.Log("hello");
    }
    public void GoogleRanking()
    {

    }
    
}
