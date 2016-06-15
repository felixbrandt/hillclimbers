using UnityEngine;
using System.Collections;

public class MenuBackground : MonoBehaviour {
	public float speed = 0.005f;
	public float ratio = 1.25f;

	public GameObject foregroundLayer;
	public GameObject backgroundLayer;

	private Vector3 foregroundStartPosition;
	private Vector3 backgroundStartPosition;

	private Vector2 foregroundStartOffset;
	private Vector2 backgroundStartOffset;

	private float i;

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
		var newpos = new Vector3(foregroundStartPosition.x, foregroundStartPosition.y, foregroundStartPosition.z);
		foregroundLayer.transform.position = newpos;

		newpos = new Vector3(backgroundStartPosition.x, backgroundStartPosition.y, backgroundStartPosition.z);
		backgroundLayer.transform.position = newpos;

		newpos = new Vector2(i*speed, 0);
		foregroundLayer.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", newpos);

		newpos = new Vector2(i*speed*ratio, 0);
		backgroundLayer.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", newpos);
		i += 0.01f;
	}

	void OnDisable()
	{
		backgroundLayer.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", backgroundStartOffset);
		foregroundLayer.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", foregroundStartOffset);
		// reset offsets to values set in scene view
	}
}
