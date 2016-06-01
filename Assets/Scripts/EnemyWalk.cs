using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyWalk : MonoBehaviour {
	
	public List<Vector3> waypointPositions;
	public float speed = 1;
	public Animator animator;

	Vector3 moveDirection=Vector3.zero;
	Vector3 targetPositionDelta;
	int currentWaypoint=0;
	Transform player;
	bool enter=false;

	void Awake (){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (enter) {
			catchPlayer ();
			Move ();
		} else {
			WaypointWalk ();
			Move ();
		}
	}
	void catchPlayer()
	{
		Vector3 targetPosition = player.position;
		targetPositionDelta = targetPosition - transform.position;
	}
	void WaypointWalk()
	{
		Vector3 targetPosition = waypointPositions[currentWaypoint];
		targetPositionDelta = targetPosition - transform.position;

		if (targetPositionDelta.sqrMagnitude <= 1) {
			currentWaypoint ++;
			if (currentWaypoint >= waypointPositions.Count)
				currentWaypoint = 0;
		} else {
			if (targetPositionDelta.x > 0) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
			} else {
				transform.rotation = Quaternion.Euler(0, 180, 0);
			}
		}
	}
	void Move()
	{
		moveDirection = targetPositionDelta.normalized * speed;
		transform.Translate (moveDirection * Time.deltaTime, Space.World);
		animator.SetBool("Walking", true);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		enter = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		enter = false;
	}
}
