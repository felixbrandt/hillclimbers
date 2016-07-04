using UnityEngine;
using System.Collections;

public class BoulderSpawn : MonoBehaviour {

    public float time = 3f;
    public GameObject boulder;  
	public AudioClip stoneFall;

	AudioSource stone;
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
		stone = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            Instantiate(boulder, transform.position, new Quaternion());
			stone.clip = stoneFall;
			stone.Play ();
            yield return new WaitForSeconds(time);
        }
        
    }
}
