using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Animator anim;

	GameObject player;
	ItemController ic;
	WeaponController wc;

	private float cD;
	float timer;


	void Awake () {
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		ic = player.GetComponent<ItemController> ();
	}

	void FixedUpdate () {
		cD = ic.getCD ();
		if (Input.GetMouseButtonDown(0))
		{
			timer += Time.deltaTime;
			if (timer >= cD) {
				anim.SetTrigger ("Attacking");
			}
		}
	}
}
