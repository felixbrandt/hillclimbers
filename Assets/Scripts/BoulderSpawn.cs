using UnityEngine;
using System.Collections;

public class BoulderSpawn : MonoBehaviour {

    public float time = 3f;
    public GameObject boulder;  
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            Instantiate(boulder, transform.position, new Quaternion());
            yield return new WaitForSeconds(time);
        }
        
    }
}
