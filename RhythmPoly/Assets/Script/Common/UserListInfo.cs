using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RhythmPoly.Common
{
    public struct UserListInfo
    {
        public string webid;
        public string name;
        public int highscore;

        public UserListInfo(string webid, string name, int highscore)
        {
            this.webid = webid;
            this.name = name;
            this.highscore = highscore;
        }



    }
}