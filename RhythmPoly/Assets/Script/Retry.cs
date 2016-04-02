using UnityEngine;
using System.Collections;
using BestHTTP;
using System;
using RhythmPoly.Common;
using System.Collections.Generic;
public class Retry : MonoBehaviour {

	public UILabel match_number;
	public UILabel score;


    public List<GameObject> gradeobjlist;
    public List<GameObject> gradeNameobjlist;

    public GameObject mygradeObj;
    public GameObject mynameObj;
    public GameObject mypointObj;

    List<UserListInfo> userlist = new List<UserListInfo>();
    FacebookConnector fbConnector = new FacebookConnector();

    int mypoint = 0;

    private void SetHighScoreText()
    {
        userlist = ParseListInfo(UserInfo.Instance.UserList);

        for (int i = 0; i < userlist.Count; ++i)
        {
            if (i >= gradeobjlist.Count)
                break;
            gradeobjlist[i].GetComponent<UILabel>().text = userlist[i].highscore.ToString();
            string name = "";
            name = userlist[i].name.ToString();
            if(name.TrimEnd() == "")
            {
                name = "User" + userlist[i].webid;
            }

            gradeNameobjlist[i].GetComponent<UILabel>().text = name;
        }
        int grade = 0;
        for (int i = 0; i < userlist.Count; ++i)
        {
            if (userlist[i].highscore <= UserInfo.Instance.Highscore)
            {
                break;
            }
            grade = i;
        }
        grade++;
        mygradeObj.GetComponent<UILabel>().text = grade.ToString();
    }

    // Use this for initialization
    void Start () {
		float f = TouchReceiver02.endScore;
		int num = (int)f;
        mypoint = num;
		match_number.text = TouchReceiver02.match_number.ToString ();
		score.text = num.ToString ();
      

        SetHighScoreText();
        if (UserInfo.Instance.Highscore <= num)
        {
            UserInfo.Instance.Highscore = num;
            SendData();
        }
        else
        {
            GetTopUser();
        }

        string name = UserInfo.Instance.Name;
        if (name.TrimEnd() == "")
        {
            name = "Me";
        }
        mynameObj.GetComponent<UILabel>().text = name;
        mypointObj.GetComponent<UILabel>().text =  num.ToString ();



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
        GetTopUser();
        Debug.Log(response.DataAsText);
    }


    public void retry() {
		//Application.LoadLevel("InGameScene");
		TouchReceiver02.finalScore = 0;
		TouchReceiver02.endScore = 0;
		TouchReceiver02.match_number = 0;
		Application.LoadLevel("InGameScene");

	}
	public void facebook() {
        //Application.LoadLevel("InGameScene");
        fbConnector.Init();
        fbConnector.Login();

    }
}
