using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	//TODO Adapt script to Enemy 
	public float playerDamage;

	Animator animator;
	Transform target;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		//base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//TODO write base script
	private void AttemptMove<T>(int xDir,int yDir)
	{
		//base.AttemptMove<T> (xDir, yDir);
	}
	public void MoveEnemy()
	{
		int xDir = 0;
		int yDir = 0;
		if (Mathf.Abs (target.position.x - transform.position.x) < float.Epsilon) {
			yDir = target.position.x > transform.position.y ? 1 : -1;
		} else {
			xDir = target.position.x > transform.position.x ? 1 : -1;
		}
		//AttemptMove<Player> (xDir, yDir);
	}
}
