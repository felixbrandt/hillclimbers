using UnityEngine;
using System.Collections;

public class BackgroundFollow : MonoBehaviour {
    public float speed = 0.005f;
    public float ratio = 1.25f;

	public GameObject foregroundLayer;
	public GameObject backgroundLayer;

    private Vector3 foregroundStartPosition;
    private Vector3 backgroundStartPosition;

    private Vector2 foregroundStartOffset;
    private Vector2 backgroundStartOffset;

    private float saved = 0;

	// Use this for initialization
	void Start () {
        foregroundStartOffset = foregroundLayer.GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
        backgroundStartOffset = backgroundLayer.GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");

        foregroundStartPosition = foregroundLayer.transform.position;
        backgroundStartPosition = backgroundLayer.transform.position;
	}
	
	void FixedUpdate () {
        // Where is the camera?!
        var x = Camera.main.transform.position.x;
        var y = Camera.main.transform.position.y;

        var newpos = new Vector3(foregroundStartPosition.x + x, foregroundStartPosition.y + y, foregroundStartPosition.z);
        foregroundLayer.transform.position = newpos;

        newpos = new Vector3(backgroundStartPosition.x + x, backgroundStartPosition.y + y, backgroundStartPosition.z);
        backgroundLayer.transform.position = newpos;

        newpos = new Vector2(x * speed * ratio, 0);
        foregroundLayer.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", newpos);

        newpos = new Vector2(x * speed, 0);
        backgroundLayer.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", newpos);
    }

    void OnDisable()
    {
        backgroundLayer.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", backgroundStartOffset);
        foregroundLayer.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", foregroundStartOffset);
        // reset offsets to values set in scene view
    }
}
