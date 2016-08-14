using UnityEngine;
using System.Collections;

using GooglePlayGames;

public class HighScoreManager
{
    private static HighScoreManager inst;
    public long h_score;
    public const string leaderboard_id = "CggIjvO18kcQAhAA";
    public const string High_id = "HighScore";
    private bool m_login = false;
    private HighScoreManager()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        LogIn();
    }
    public static HighScoreManager GetInstance()
    {
        if (inst == null)
        {
            inst = new HighScoreManager();
        }
        return inst;
    }
    public void UpdateHighScore(long score)
    {
        if (h_score < score)
        {
            Debug.Log("test : " + h_score + " hi : " + score);
            if (m_login) Social.ReportScore(score, leaderboard_id, (bool success) => { });
            PlayerPrefs.SetInt(High_id, (int)score);
            h_score = score;
        }
    }
    public long GetHighScore()
    {
        return h_score;
    }
    public void ShowLeaderBoard()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboard_id);
    }
    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Social.LoadScores(leaderboard_id,(UnityEngine.SocialPlatforms.IScore[] score)=>{
                    h_score = score[0].value;
                });
                m_login = true;
            }
            else
            {
                h_score = PlayerPrefs.GetInt(High_id);
            }
        });
    }
}

