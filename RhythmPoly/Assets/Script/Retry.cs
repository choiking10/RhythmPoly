using UnityEngine;
using System.Collections;
using BestHTTP;
using System;
using RhythmPoly.Common;
using System.Collections.Generic;
public class Retry : MonoBehaviour {

	public UILabel perfect;
	public UILabel great;
	public UILabel good;
	public UILabel miss;
	public UILabel score;


    public List<GameObject> gradeobjlist;

    public GameObject mygradeObj;
    List<UserListInfo> userlist = new List<UserListInfo>();

    private void SetHighScoreText()
    {
        userlist = ParseListInfo(UserInfo.Instance.UserList);

        for (int i = 0; i < userlist.Count; ++i)
        {
            if (i >= gradeobjlist.Count)
                break;
            gradeobjlist[i].GetComponent<UILabel>().text = userlist[i].highscore.ToString();
        }
    }

    // Use this for initialization
    void Start () {
		float f = TouchReceiver02.endScore;
		int num = (int)f;
		perfect.text = TouchReceiver02.perfect.ToString ();
		great.text = TouchReceiver02.great.ToString ();
		good.text = TouchReceiver02.good.ToString ();
		miss.text = TouchReceiver02.miss.ToString ();
		score.text = num.ToString ();

        if (UserInfo.Instance.Highscore > num)
        {
            UserInfo.Instance.Highscore = num;
            SendData();
        }


        GetTopUser();
    }


    public void GetTopUser()
    {
        HTTPRequest request = new HTTPRequest(new Uri(GameInfo.ServerUrl + @"gettopuser/"), onGetRequestFinished);
        request.Send();
    }

    void onGetRequestFinished(HTTPRequest request, HTTPResponse response)
    {
        UserInfo.Instance.UserList = response.DataAsText;
        SetHighScoreText();
        Debug.Log(response.DataAsText);
    }

    public List<UserListInfo> ParseListInfo(string var)
    {
        List<string> templist = new List<string>();
        string temp = "";
        foreach (char c in var)
        {
            if (c == ':')
            {
                templist.Add(temp);
                temp = "";
            }
            else
            {
                temp += c.ToString();
            }
        }
        List<UserListInfo> userlist = new List<UserListInfo>();
        for (int i = 0; i < templist.Count; i = i + 3)
        {
            int high = 0;
            if (templist[i + 2] != "")
                high = int.Parse(templist[i + 2]);
            userlist.Add(new UserListInfo(templist[i], templist[i + 1], high));
        }

        return userlist;
    }



    public void SendData()
    {
        try
        {
            HTTPRequest request = new HTTPRequest(new Uri(GameInfo.ServerUrl + @"setuser/"), HTTPMethods.Post, OnRequestFinished);
            request.AddField("deviceid", UserInfo.Instance.DeviceID.ToString());
            request.AddField("facebookid", UserInfo.Instance.Id.ToString());
            request.AddField("name", UserInfo.Instance.Name.ToString());
            request.AddField("highscore", UserInfo.Instance.Highscore.ToString());
            request.Send();
        }
        catch (Exception e)
        {

        }
    }
    void OnRequestFinished(HTTPRequest request, HTTPResponse response)
    {
        UserInfo.Instance.WebId = response.DataAsText;
        Debug.Log(response.DataAsText);
    }


    public void Update() {
		//Application.LoadLevel("InGameScene");
		if (Input.anyKeyDown) {
			TouchReceiver02.finalScore = 0;
			TouchReceiver02.endScore = 0;
			TouchReceiver02.miss = 0;
			TouchReceiver02.good = 0;
			TouchReceiver02.great = 0;
			TouchReceiver02.perfect = 0;
			Application.LoadLevel("InGameScene");
		}
	}
}
