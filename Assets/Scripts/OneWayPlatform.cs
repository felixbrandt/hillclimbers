using UnityEngine;
using System.Collections;

public class OneWayPlatform : MonoBehaviour {

    public GameObject playerGroundcheck;
    public bool enabledCollider;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        enabledCollider = playerGroundcheck.transform.position.y > transform.position.y;
        if (enabledCollider)
        {
            GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
        }
	
	}
}
