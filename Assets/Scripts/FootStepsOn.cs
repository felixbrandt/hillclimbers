using UnityEngine;
using System.Collections;

public class FootStepsOn : MonoBehaviour {

	public AudioClip step;
	AudioSource playerAudio;
	WalkingScript ws;
	// Use this for initialization
	void Start () {
		playerAudio = GetComponent<AudioSource> ();
		ws = GetComponent<WalkingScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.A)) {
			playerAudio.clip = step;
			playerAudio.volume = 1f;
			playerAudio.Play ();
		}	
		else if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.A)) {
			playerAudio.clip = step;
			playerAudio.Stop ();
		}
		else if (ws.grounded==false) {
			playerAudio.clip = step;
			playerAudio.Stop ();
		}	
	}
}
