using UnityEngine;
using System.Collections;
using UnityEngine.UI;

class PolySoundManager 
{
    static AudioSource audio_s;

    public static void setAudio(AudioSource audio)
    {
        audio_s = audio;
    }
    public static void PauseAudio()
    {
        audio_s.Pause();
    }
    public static void UnPauseAudio()
    {
        audio_s.UnPause();
    }
}
