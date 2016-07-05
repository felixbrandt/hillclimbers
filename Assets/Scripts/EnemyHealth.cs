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
            
	           	// Disable all colliders -> Yeti falls off
            		foreach (var collider in gameObject.GetComponents<BoxCollider2D>())
            		{
                		collider.enabled = false;
            		}

            		// Disable Scripts
            		gameObject.GetComponent<EnemyWalk>().enabled = false;
            		gameObject.GetComponent<EnemyAttack>().enabled = false;
            		this.enabled = false;
	
						// Play sound
			    	enemyAudio.clip = dying;
		    		enemyAudio.Play();

            		// Destroy Object in 3 seconds (probably off screen by then)
            		Destroy(gameObject, 3);
	    }
	}
}
