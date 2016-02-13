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


        public string DeviceID
        {
            get
            {
                return SystemInfo.deviceUniqueIdentifier;
            }
        }

    }
}