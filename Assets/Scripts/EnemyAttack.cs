using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float range = 0f;
	public int ad=10;
	public float cooldown=0.5f;
	public AudioClip inSight;
	public AudioClip attack;

	public Animator animator;
	GameObject player;
	//EnemyHealth eh;
	PlayerHealth ph;
	Vector3 targetPositionDelta;
	float timer;
	bool inRange =false;

	AudioSource enemyAudio;


	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		ph = player.GetComponent<PlayerHealth> ();
		//eh = GetComponent<EnemyHealth> ();
		animator=GetComponent<Animator>();
		enemyAudio = GetComponent<AudioSource> ();
	}
	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= cooldown && inRange) {
			Attack ();	
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
			if(other.CompareTag("Player"))
			{
				enemyAudio.clip = inSight;
				enemyAudio.volume = 0.8f;
				enemyAudio.Play();
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
		enemyAudio.clip = attack;
		enemyAudio.volume = 0.8f;
		enemyAudio.Play ();
        animator.SetTrigger("Attacking");
        animator.SetBool("Walking", false);
	}
}
