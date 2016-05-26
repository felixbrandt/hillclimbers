using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

	public GameObject[] weapons = new GameObject[2];
	public GameObject[] tools = new GameObject[2];
    public float damage = 0f;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.CompareTag ("weapon")) {
            Debug.Log("entered collider");
            if (weapons [0] == null) {
                Debug.Log("weaponslot free");
                switch (collider.gameObject.name)
                {
                    case "KnifeItem":
                        transform.Find("player_torso/player_arm_upper/player_arm_lower/player_hand/Knife").gameObject.SetActive(true);
                        break;
                        //case "Taser":
                        //case "Revolver":
                        //case "Pfeffer":
                        //case "Jagdgewehr":
                        //case: Leuchtpistole":
                }
                Destroy(collider.gameObject);
			} else if (weapons [1] == null) {

			} else {
				Debug.Log ("weaponslots full");
			}
		}
		if (collider.CompareTag ("tool")) {
			if (tools [0] == null) {
           
			}
            else if (tools [1] == null) {

			} else {
				Debug.Log ("toolslots full");
			}
		}
	}
}
