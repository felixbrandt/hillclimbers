using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float health=100f;
	public float maxHealth=100f;

	public void RemoveHealth(float amount)
	{
		//Check if Enemy has enough Health left to get fought
		if (health > 0) {
			health -= amount;
		}
		//Kill enemy if health <= 0
		else {
			Destroy (gameObject);
		}
	}
}
