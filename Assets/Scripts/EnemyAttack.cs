using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float range = 0f;
	public int ad=10;
	public float cooldown=0.5f;

	public Animator animator;
	GameObject player;
	//EnemyHealth eh;
	PlayerHealth ph;
	Vector3 targetPositionDelta;
	float timer;
	bool inRange =false;


	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		ph = player.GetComponent<PlayerHealth> ();
		//eh = GetComponent<EnemyHealth> ();
		animator=GetComponent<Animator>();
	}
	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= cooldown && inRange) {
			Attack ();	
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		Vector3 targetPosition=player.transform.position;
		targetPositionDelta = targetPosition - transform.position;
		if (Mathf.Abs(targetPositionDelta.x) <= range) {
			inRange = true;
		} else {
			inRange = false;	
		}
	}

	void OnTriggerExit2D(Collider2D other){
		inRange = false;
	}
	void Attack()
	{
		timer = 0f;	
		if (ph.currentHealth > 0) {
			ph.TakeDamage (ad);
		}

        animator.SetTrigger("Attacking");
        animator.SetBool("Walking", false);
	}
}
