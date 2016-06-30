using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	GameObject player;
	ItemController ic;

	private float attack;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		ic = player.GetComponent<ItemController> ();
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
