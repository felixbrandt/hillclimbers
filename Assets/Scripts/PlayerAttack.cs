using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Animator anim;
	public AudioClip knife;
	WeaponController wc;
	float timer;
	AudioSource playerAudio;

	void Awake () {
		anim = GetComponent<Animator> ();
		playerAudio = GetComponent<AudioSource> ();
	}

	void FixedUpdate () {
		if (Input.GetMouseButtonDown(0))
		{
				anim.SetTrigger ("Attacking");

				playerAudio.clip = knife;
            if (!playerAudio.isPlaying)
            {
                playerAudio.Play();
            }
        }
		}
	}
