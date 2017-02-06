using UnityEngine;
using System.Collections;

public class Boulder : MonoBehaviour {

    public GameObject dust;
    public float x = -42.8f;
    public float y = -2.33f;
    public AudioClip stones1;
    public AudioClip stones2;
    public AudioClip stones3;
    public int soundNr = 1;
    Rigidbody2D rb;
    
	// Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SpeedUp());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (soundNr == 1)
        {
            GetComponent<AudioSource>().clip = stones1;
            GetComponent<AudioSource>().Play();
            soundNr = 2;
        }
        if (soundNr == 2)
        {
            GetComponent<AudioSource>().clip = stones2;
            GetComponent<AudioSource>().Play();
            soundNr = 3;
        }
        if (soundNr == 3)
        {
            GetComponent<AudioSource>().clip = stones3;
            GetComponent<AudioSource>().Play();
            soundNr = 1;
        }
        Instantiate(dust, collision.contacts[0].point, new Quaternion());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("boulderDespawn"))
        {
            Destroy(gameObject);
        }
    }

        IEnumerator SpeedUp()
    {
        while (true)
        {
            rb.AddForce(new Vector2(x, y));
            yield return new WaitForSeconds(0.2f);
        }

    }
}
