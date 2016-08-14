using UnityEngine;
using System.Collections;
using GooglePlayGames;
public class TestRank : MonoBehaviour {

	// Use this for initialization
	void Start () {
        HighScoreManager.GetInstance().UpdateHighScore((int)TouchReceiver02.finalScore);
    }
    
    public void LeaderBoard()
    {

        HighScoreManager.GetInstance().ShowLeaderBoard();
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
