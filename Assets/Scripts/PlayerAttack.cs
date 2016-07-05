using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Animator anim;
	public AudioClip knife;
	GameObject player;
	ItemController ic;
	WeaponController wc;

	private float cD;
	float timer;
	AudioSource playerAudio;

	void Awake () {
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		ic = player.GetComponent<ItemController> ();
		playerAudio = GetComponent<AudioSource> ();
	}

	void FixedUpdate () {
		cD = ic.getCD ();
		if (Input.GetMouseButtonDown(0))
		{
			timer += Time.deltaTime;
			if (timer >= cD) {
				anim.SetTrigger ("Attacking");
				playerAudio.clip = knife;
				playerAudio.Play();
			}
		}
	}
}
