using UnityEngine;
using System.Collections;

public class GrapplinghookScript : MonoBehaviour {

	public float speed = 10f;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
	}

	public void OnBecameInvisible(){
		//when object gets out of screen
		Destroy (gameObject);
	}

}
