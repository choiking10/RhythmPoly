using UnityEngine;
using System.Collections;
using BestHTTP;
using System;
using RhythmPoly.Common;
using System.Collections.Generic;
public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetTopUser();
        SendData();
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

    void OnRequestFinished(HTTPRequest request, HTTPResponse response)
    {
        UserInfo.Instance.WebId = response.DataAsText;
        Debug.Log(response.DataAsText);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
