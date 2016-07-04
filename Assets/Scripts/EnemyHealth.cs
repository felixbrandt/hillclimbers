using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float health=100f;
	public Animator anim;
	public AudioClip dying;

	AudioSource enemyAudio;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		enemyAudio = GetComponent<AudioSource> ();
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
			enemyAudio.clip = dying;
			enemyAudio.Play ();
			Destroy (gameObject);
		}
	}
}
