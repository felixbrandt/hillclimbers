using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float health=100f;
	public Animator anim;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}
	public void TakeDamage(float amount)
	{
		//Check if Enemy has enough Health left to get fought
		if (health > 0) {
			health -= amount;
		}
		//Kill enemy if health <= 0
		else {
			anim.SetBool ("Walking", false);
			anim.SetTrigger ("Die");
			Destroy (gameObject);
		}
	}
}
