using UnityEngine;
using System.Collections;
using RhythmPoly.Common;

using BestHTTP;
using System;
using RhythmPoly.Common;

public class MainCamera : MonoBehaviour {


    FacebookConnector fbConnector = new FacebookConnector();
    int count = 0;
    // Use this for initialization
    void Start () {

        //ZPlayerPrefs.Initialize("UnitoneGames", "unitonepwpw75");
        //ZPlayerPrefs.SetString("score", "5");

        //Debug.Log(ZPlayerPrefs.GetString("score
        //UserInfo.Instance.Score = 10;
        //Debug.Log(UserInfo.Instance.Score); 

        fbConnector.Init();
      
    }



    /*
    static bool NaverLogin1(String ID, String PW)
    {

        WinHttpRequest Winhttp = new WinHttpRequest();

        Winhttp.Open("POST", "https://nid.naver.com/nidlogin.login");
        Winhttp.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        Winhttp.SetRequestHeader("Referer", "https://nid.naver.com/nidlogin.login");
        Winhttp.Send("enctp=2&url=http://www.naver.com&enc_url=http://www.naver.com&postDataKey=&saveID=0&nvme=0&smart_level=1&id=" + ID + "&pw=" + PW);
        Winhttp.WaitForResponse();

        if (Winhttp.ResponseText.IndexOf("네이버에 등록되지 않은 아이디이거나, 아이디 또는 비밀번호를 잘못 입력하셨습니다.") == -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    */


    public void GetData()
    {
        HTTPRequest request = new HTTPRequest(new Uri(GameInfo.ServerUrl + @"testpage/"), onGetRequestFinished);
        request.Send();
    }

    void onGetRequestFinished(HTTPRequest request, HTTPResponse response)
    {
        Debug.Log(response.DataAsText);
    }
    
    public void SendData()
    {
        try
        {
            HTTPRequest request = new HTTPRequest(new Uri(GameInfo.ServerUrl + @"testpost/"), HTTPMethods.Post, OnRequestFinished);
            request.AddField("test", "ok!");
            request.Send();
        }
        catch (Exception e)
        {

        }
    }
    void OnRequestFinished(HTTPRequest request, HTTPResponse response)
    {
        Debug.Log(response.DataAsText);
    }
    

    // Update is called once per frame
    void Update () {
        count++;

        if (Input.GetMouseButton(0) && count > 100)
        {
            fbConnector.Login();
        }

    }
}
