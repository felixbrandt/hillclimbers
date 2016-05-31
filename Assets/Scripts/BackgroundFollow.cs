using UnityEngine;
using System.Collections;

public class BackgroundFollow : MonoBehaviour {

	public GameObject foregroundLayer;
	public GameObject backgroundLayer;

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tempVector = backgroundLayer.transform.position;
		tempVector.x = player.transform.position.x;
		backgroundLayer.transform.position = tempVector;

		Debug.Log (backgroundLayer.transform.position.x);
	}
}
