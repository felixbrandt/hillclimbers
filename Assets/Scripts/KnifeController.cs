using UnityEngine;
using System.Collections;

public class KnifeController : MonoBehaviour {

	Animator anim;
	GameObject player;
	ItemController ic;

	private float cD;
	private float attack;
	float timer;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = player.GetComponent<Animator> ();
		ic = player.GetComponent<ItemController> ();
	}
	void FixedUpdate()
	{
		cD = ic.getCD ();
		if (Input.GetMouseButtonDown (0)) {
			timer += Time.deltaTime;
			if (timer >= cD) {
				Debug.Log ("231");
				GetComponent<BoxCollider2D> ().enabled = true;
				anim.SetTrigger ("Attacking");
			}
		}
		Debug.Log ("12134");
		GetComponent<BoxCollider2D> ().enabled = false;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{				
			attack=ic.getAD();
			other.GetComponent<EnemyHealth>().TakeDamage(attack);
		}
	}
}
