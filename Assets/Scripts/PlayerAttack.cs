using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Animator anim;

	GameObject enemy;
	EnemyHealth eh;
	GameObject weapon;


	bool hit = false;
	int attackpoints;

	void Awake () {
		anim = GetComponent<Animator> ();
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		eh = enemy.GetComponent<EnemyHealth> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButtonDown(0))
		{
			anim.SetTrigger("Attacking");
			Attack ();
		}
	}
	void Attack()
	{
		if (hit) {
			if (eh.health > 0) {
				eh.TakeDamage (attackpoints);
			}

		}
	}
}
