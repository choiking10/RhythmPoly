using UnityEngine;
using System.Collections;
using GooglePlayGames;
public class TestRank : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        LogIn();
	}
    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Log In");
            }
            else
            {
                Debug.Log("Login failed");
            }
        });
    }
    public void LeaderBoard()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CggIjvO18kcQAhAA");
    }
    public void ReportLeaderBoard()
    {
        Social.ReportScore(100, "CggIjvO18kcQAhAA", (bool success) =>
        {
            // handle success or failure
        });
    }
	// Update is called once per frame
	void Update () {
	
	}
}
