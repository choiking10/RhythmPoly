using UnityEngine;
using System.Collections;

public class sound : MonoBehaviour {

	public AudioClip otherClip;

	IEnumerator Start() {
		AudioSource audio = GetComponent<AudioSource>();

		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		audio.clip = otherClip;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
