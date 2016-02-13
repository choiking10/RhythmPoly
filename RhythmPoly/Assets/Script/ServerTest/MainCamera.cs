using UnityEngine;
using System.Collections;
using RhythmPoly.Common;

using BestHTTP;
using System;
using RhythmPoly.Common;
using System.Collections.Generic;

public class MainCamera : MonoBehaviour {


    FacebookConnector fbConnector = new FacebookConnector();
    int count = 0;

    public GameObject labelobj;
    // Use this for initialization
    void Start () {

        //ZPlayerPrefs.Initialize("UnitoneGames", "unitonepwpw75");
        //ZPlayerPrefs.SetString("score", "5");

        //Debug.Log(ZPlayerPrefs.GetString("score
        //UserInfo.Instance.Score = 10;
        //Debug.Log(UserInfo.Instance.Score); 

        fbConnector.Init();
        List<UserListInfo>  userlist = ParseListInfo(UserInfo.Instance.UserList);
        Debug.Log(UserInfo.Instance.UserList);
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




    public void GetTopUser()
    {
        HTTPRequest request = new HTTPRequest(new Uri(GameInfo.ServerUrl + @"gettopuser/"), onGetRequestFinished);
        request.Send();
    }

    void onGetRequestFinished(HTTPRequest request, HTTPResponse response)
    {
        UserInfo.Instance.UserList = response.DataAsText;
        Debug.Log(response.DataAsText);
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
    

    // Update is called once per frame
    void Update () {
        count++;

        if (Input.GetMouseButton(0) && count > 100)
        {
            fbConnector.Login();
        }

        if (UserInfo.Instance.Id != "")
        {
            labelobj.GetComponent<UILabel>().text = UserInfo.Instance.Name + UserInfo.Instance.Id;
        }

    }
}
