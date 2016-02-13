using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
using System;

namespace RhythmPoly.Common
{
    public class FacebookConnector
    {


        public static string success = "";

        FacebookdataParser fparser = new FacebookdataParser();
        public FacebookConnector()
        {

        }


        public void Init()
        {
            if(!FB.IsInitialized)
                FB.Init(this.OnInitComplete, this.OnHideUnity);

        }


        private void OnInitComplete()
        {

        }



        public void GetMyInfo()
        {
            string ApiQuery = "me/?fields=id,name,picture,score";
            FB.API(ApiQuery, HttpMethod.GET, CallbackMyInfo);
        }

        public void CallbackMyInfo(IGraphResult result)
        {
            if (!string.IsNullOrEmpty(result.RawResult))
            {
                fparser.SetMyInfo(result.RawResult);
            }
        }





        private void OnHideUnity(bool isGameShown)
        {
        }

        public bool IsLoggedIn()
        {
            return FB.IsLoggedIn;
        }

        public void Login()
        {
            #if UNITY_ANDROID  && !UNITY_EDITOR
                CallFBLogin();
            #endif

        }
        private void CallFBLogin()
        {
            FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email", "user_friends" }, this.LoginHandleResult);
        }



            

        string LastResponse = "";
        string Status;
        protected void LoginHandleResult(IResult result)
        {
            if (result == null)
            {
                this.LastResponse = "Null Response\n";
                return;
            }


            // Some platforms return the empty string instead of null.
            if (!string.IsNullOrEmpty(result.Error))
            {
                this.Status = "Error - Check log for details";
            }
            else if (result.Cancelled)
            {
                this.Status = "Cancelled - Check log for details";
                this.LastResponse = "Cancelled Response:\n" + result.RawResult;
            }
            else if (!string.IsNullOrEmpty(result.RawResult))
            {
                this.Status = "Success - Check log for details";
                this.LastResponse = "Success Response:\n" + result.RawResult;

                GetMyInfo();
            
            }
            else
            {
                this.LastResponse = "Empty Response\n";
            }
        }


        public void GetFriendsList()
        {
            string ApiQuery = "me/friends?fields=name,id,picture,score";
            FB.API(ApiQuery, HttpMethod.GET, CallbackFriends);
        }

        public void CallbackFriends(IGraphResult result)
        {
            if (!string.IsNullOrEmpty(result.RawResult))
            {
                fparser.SetFriendList(result.RawResult);

                List<FriendInfo> list = fparser.GetFriendList();
                for (int i = 0; i < list.Count; ++i)
                {
                    this.LastResponse = list[i].name.ToString() + " : " + list[i].score.ToString() + " : ";
                }

            }

        }




        protected void PublishHandleResult(IResult result)
        {
            if (result == null)
            {
                this.LastResponse = "Null Response\n";
                return;
            }


            // Some platforms return the empty string instead of null.
            if (!string.IsNullOrEmpty(result.Error))
            {
                this.Status = "Error - Check log for details";
            }
            else if (result.Cancelled)
            {
                this.Status = "Cancelled - Check log for details";
                this.LastResponse = "Cancelled Response:\n" + result.RawResult;
            }
            else if (!string.IsNullOrEmpty(result.RawResult))
            {
                this.Status = "Success - Check log for details";
                this.LastResponse = "Success Response:\n" + result.RawResult;
            }
            else
            {
                this.LastResponse = "Empty Response\n";
            }
        }

        public void CallFBLoginForPublish()
        {
            if(!FB.IsInitialized)
            {
                Init();
                return;
            }

            if (!FB.IsLoggedIn)
            {
                FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email", "user_friends" }, delegate (ILoginResult result)
                {
                    if (!string.IsNullOrEmpty(result.RawResult))
                    {
                        //success
                        FB.LogInWithPublishPermissions(new List<string>() { "publish_actions" }, this.PublishHandleResult);
                    }
                });
            }
            else
            {
                // It is generally good behavior to split asking for read and publish
                // permissions rather than ask for them all at once.
                //
                // In your own game, consider postponing this call until the moment
                // you actually need it.
                FB.LogInWithPublishPermissions(new List<string>() { "publish_actions" }, this.PublishHandleResult);
            }
        }


        public void LogOut()
        {
            FB.LogOut();
        }



        public void SetScore(long score)
        {
            if (!FB.IsInitialized || !FB.IsLoggedIn)
                return;
            var scoreData = new Dictionary<string, string>();
            string tmpscore = score.ToString();
            scoreData["score"] = tmpscore;
            FB.API("/me/scores", HttpMethod.POST, delegate (IGraphResult result)
            {
                if (!string.IsNullOrEmpty(result.RawResult))
                {
                    //success
                }
            }, scoreData);
        }
       

      

        public IEnumerator TakeScreenshot()
        {
            yield return new WaitForEndOfFrame();

            var width = Screen.width;
            var height = Screen.height;
            var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
            // Read screen contents into the texture
            tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            tex.Apply();
            byte[] screenshot = tex.EncodeToPNG();

            var wwwForm = new WWWForm();
            wwwForm.AddBinaryData("image", screenshot, "InteractiveConsole.png");

            FB.API("me/photos", HttpMethod.POST, Callback, wwwForm);
        }

        public void Callback(IGraphResult result)
        {

        }
    }
}