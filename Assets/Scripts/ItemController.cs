using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

	GameObject[] weapons = new GameObject[2];
	GameObject[] tools = new GameObject[2];


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.CompareTag ("weapon")) {
			if (weapons [0] == null) {
			 
			} else if (weapons [1] == null) {

			} else {
				Debug.Log ("weaponslots full");
			}
		}
		if (collider.CompareTag ("tool")) {
			if (tools [0] == null) {
			} else if (tools [1] == null) {

			} else {
				Debug.Log ("toolslots full");
			}
		}
	}
}
