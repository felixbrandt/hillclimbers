using UnityEngine;
using System.Collections;

public class BackgroundFollow : MonoBehaviour {
    public float speed = 0.231f;

	public GameObject foregroundLayer;
	public GameObject backgroundLayer;

    private float foregroundWidth;
    private float backgroundWidth;

    private float foregroundInitialY;
    private float backgroundInitialY;

	// Use this for initialization
	void Start () {
        foregroundWidth = foregroundLayer.GetComponent<Renderer>().bounds.size.x;
        backgroundWidth = backgroundLayer.GetComponent<Renderer>().bounds.size.x;

        foregroundInitialY = foregroundLayer.transform.position.y;
        backgroundInitialY = backgroundLayer.transform.position.y;
        
        Debug.Log(foregroundWidth);
        Debug.Log(backgroundWidth);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tempVector = backgroundLayer.transform.position;
		tempVector.x = Camera.main.transform.position.x * speed;
        tempVector.y = Camera.main.transform.position.y + backgroundInitialY;
		backgroundLayer.transform.position = tempVector;

        Debug.Log(backgroundLayer.transform.position);


        tempVector = foregroundLayer.transform.position;
        tempVector.x = Camera.main.transform.position.x * speed * 0.75f;
        tempVector.y = Camera.main.transform.position.y + foregroundInitialY;
        foregroundLayer.transform.position = tempVector;

        // TODO: 2 sprites statt 1, mit endloser wiederholung
    }
}
