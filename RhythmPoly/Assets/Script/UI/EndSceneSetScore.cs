using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndSceneSetScore : MonoBehaviour 
{
    public void Start(){
        Text t = gameObject.GetComponent<Text>();
        t.text = ""+TouchReceiver02.finalScore;
    }
}

