using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
class SetHighScore : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "" + HighScoreManager.GetInstance().GetHighScore();
    }
}

