using UnityEngine;
using System.Collections;

namespace RhythmPoly.Common
{
    public class UserInfo : Singleton<UserInfo>
    {
        protected UserInfo()
        {
            ZPlayerPrefs.Initialize("UnitonGames", "unitonpwpw75");
        }


        public int Score
        {
            get
            {
                return ZPlayerPrefs.GetInt("score");
            }
            set
            {
                ZPlayerPrefs.SetInt("score", value);
            }
        }


        public int Highscore
        {
            get
            {
                return ZPlayerPrefs.GetInt("highscore");
            }
            set
            {
                if(value > ZPlayerPrefs.GetInt("highscore"))
                    ZPlayerPrefs.SetInt("highscore", value);
            }
        }


        public string Name
        {
            get
            {
                return ZPlayerPrefs.GetString("Name");
            }
            set
            {
                ZPlayerPrefs.SetString("Name", value);
            }
        }


        public string Id
        {
            get
            {
                return ZPlayerPrefs.GetString("Id");
            }
            set
            {
                ZPlayerPrefs.SetString("Id", value);
            }
        }



        public string DeviceID
        {
            get
            {
                return SystemInfo.deviceUniqueIdentifier;
            }
        }

    }
}