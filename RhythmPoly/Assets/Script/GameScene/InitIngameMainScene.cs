
using UnityEngine;
using System.Collections;


public class InitIngameMainScene : MonoBehaviour
{
    public AudioSource audi;
    void Start(){
        PolySoundManager.setAudio(audi);
    }
}

