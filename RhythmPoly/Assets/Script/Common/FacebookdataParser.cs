using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.MiniJSON;
namespace RhythmPoly.Common
{
    public struct FriendInfo
    {
        public string id;
        public string name;
        public bool hasPicture;
        public string pictureUrl;
        public long score;
        public FriendInfo(string id, string name, bool hasPicture, string pictureUrl, long score)
        {
            this.id = id;
            this.name = name;
            this.hasPicture = hasPicture;
            this.pictureUrl = pictureUrl;
            this.score = score;
        }
    }

    public struct FriendScore
    {
        string id;
        string score;
        public FriendScore(string id, string score)
        {
            this.id = id;
            this.score = score;
        }
    }


    public class FacebookdataParser
    {
        List<FriendInfo> friendInfoList = new List<FriendInfo>();
        List<FriendScore> friendScoreList = new List<FriendScore>();

        FriendInfo myInfo = new FriendInfo();

        public FacebookdataParser()
        {

        }

        public List<FriendInfo> GetFriendList()
        {
            return friendInfoList;
        }

        public List<FriendScore> GetScoreList()
        {
            return friendScoreList;
        }


        public void SetMyInfo(string jsonData)
        {
            myInfo = new FriendInfo();
            try
            {
                Dictionary<string, object> dict = (Dictionary<string, object>)Json.Deserialize(jsonData);


                Dictionary<string, object> tempdic = dict as Dictionary<string, object>;
                string id = "";
                string name = "";
                bool hasPicture = false;
                string url = "";
                long score = 0L;
                object temp;

                if (tempdic.TryGetValue("id", out temp))
                {
                    id = tempdic["id"] as string;
                }
                if (tempdic.TryGetValue("name", out temp))
                {
                    name = tempdic["name"] as string;
                }
                if (tempdic.TryGetValue("picture", out temp))
                {

                    Dictionary<string, object> tempdic2 = tempdic["picture"] as Dictionary<string, object>;
                    var tempdic3 = tempdic2["data"] as Dictionary<string, object>;
                    object siluet = tempdic3["is_silhouette"];
                    if (siluet is bool)
                    {
                        hasPicture = !(bool)(siluet);
                    }
                    url = tempdic3["url"] as string;
                }

                if (tempdic.TryGetValue("score", out temp))
                {

                    Dictionary<string, object> tempdic2 = tempdic["score"] as Dictionary<string, object>;
                    List<object> scoreslist = (List<object>)tempdic2["data"];
                    for (int j = 0; j < scoreslist.Count; ++j)
                    {
                        Dictionary<string, object> tempdicScore = scoreslist[j] as Dictionary<string, object>;

                        if (tempdicScore.TryGetValue("score", out temp))
                        {
                            var tempobj = tempdicScore["score"] as object;
                            if (tempobj is long)
                            {
                                score = (long)tempobj;
                            }
                        }

                        /*
                        if (tempdicScore.TryGetValue("user", out temp))
                        {
                            Dictionary<string, object> tempdicUser = tempdic5["user"] as Dictionary<string, object>;
                            uid = tempdicUser["id"] as string;
                        }
                        */

                    }


                }

                myInfo = new FriendInfo(id, name, hasPicture, url, score);

            }
            catch
            {

            }
        }


    public void SetFriendList(string jsonData)
        {

            friendInfoList.Clear();
            friendScoreList.Clear();
            try
            {
                Dictionary<string, object> dict = (Dictionary<string, object>)Json.Deserialize(jsonData);

                object temp;
                List<object> friends = new List<object>();
                if (dict.TryGetValue("data", out temp))
                {
                    friends = (List<object>)dict["data"];
                    if (friends.Count < 1)
                        return;

                    for (int i = 0; i < friends.Count; ++i)
                    {
                        Dictionary<string, object> tempdic = friends[i] as Dictionary<string, object>;
                        string id = "";
                        string name = "";
                        bool hasPicture = false;
                        string url = "";
                        long score = 0L;

                        if (tempdic.TryGetValue("id", out temp))
                        {
                            id = tempdic["id"] as string;
                        }
                        if (tempdic.TryGetValue("name", out temp))
                        {
                            name = tempdic["name"] as string;
                        }
                        if (tempdic.TryGetValue("picture", out temp))
                        {

                            Dictionary<string, object> tempdic2 = tempdic["picture"] as Dictionary<string, object>;
                            var tempdic3 = tempdic2["data"] as Dictionary<string, object>;
                            object siluet = tempdic3["is_silhouette"];
                            if (siluet is bool)
                            {
                                hasPicture = !(bool)(siluet);
                            }
                            url = tempdic3["url"] as string;
                        }

                        if (tempdic.TryGetValue("score", out temp))
                        {

                            Dictionary<string, object> tempdic2 = tempdic["score"] as Dictionary<string, object>;
                            List<object> scoreslist = (List<object>)tempdic2["data"];
                            for (int j = 0; j < scoreslist.Count; ++j)
                            {
                                Dictionary<string, object> tempdicScore = scoreslist[j] as Dictionary<string, object>;
                              
                                if (tempdicScore.TryGetValue("score", out temp))
                                {
                                    var tempobj = tempdicScore["score"] as object;
                                    if(tempobj is long)
                                    {
                                        score = (long)tempobj;
                                    }
                                }

                                /*
                                if (tempdicScore.TryGetValue("user", out temp))
                                {
                                    Dictionary<string, object> tempdicUser = tempdic5["user"] as Dictionary<string, object>;
                                    uid = tempdicUser["id"] as string;
                                }
                                */

                            }


                        }

                        friendInfoList.Add(new FriendInfo(id, name, hasPicture, url, score));
                    }
                }
            }
            catch
            {

            }
        }

        /*app/scores?fields/score,user.limit(30)*/
        public void SetScoreList(string jsonData)
        {
            friendScoreList.Clear();
            try
            {
                Dictionary<string, object> dict = (Dictionary<string, object>)Json.Deserialize(jsonData);
                object temp;
                List<object> scores = new List<object>();
                if (dict.TryGetValue("data", out temp))
                {
                    scores = (List<object>)dict["data"];
                    if (scores.Count < 1)
                        return;

                    for (int i = 0; i < scores.Count; ++i)
                    {

                        Dictionary<string, object> tempdic = scores[i] as Dictionary<string, object>;
                        string score = "";
                        string id = "";
                        if (tempdic.TryGetValue("score", out temp))
                        {
                            score = tempdic["score"] as string;
                        }

                        if (tempdic.TryGetValue("user", out temp))
                        {

                            Dictionary<string, object> tempdicsub = tempdic["user"] as Dictionary<string, object>;
                            id = tempdicsub["id"] as string;
                        }

                        friendScoreList.Add(new FriendScore(id, score));
                    }
                }
            }
            catch
            {

            }
        }



    }
}