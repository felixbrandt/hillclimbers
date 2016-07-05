using UnityEngine;
using System.Collections;

public class HideFlare : MonoBehaviour {
    public LayerMask mask;
    public bool hide;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        hide = Physics2D.OverlapCircle(transform.position, 0.1f, mask);
        if (hide)
        {
            if (GetComponent<LensFlare>().brightness >= 0)
                GetComponent<LensFlare>().brightness -= 0.04f;
        }
        else
        {
            if (GetComponent<LensFlare>().brightness <= 0.5)
            GetComponent<LensFlare>().brightness += 0.04f;
        }
    }
}
