using UnityEngine;
using System.Collections;

public class Boulder : MonoBehaviour {

    public GameObject dust;
    public float x = -42.8f;
    public float y = -2.33f;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SpeedUp());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
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
