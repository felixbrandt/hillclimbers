using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemController : MonoBehaviour {

	public GameObject[] weapons = new GameObject[2];
	public GameObject[] tools = new GameObject[2];
    public float damage = 0f;
    private Button weaponSprite1;
    private Button weaponSprite2;
    private Button toolSprite1;
    private Button toolSprite2;


    // Use this for initialization
    void Start() {
        weaponSprite1 = GameObject.Find("HUD/Items/WeaponSlots").GetComponentsInChildren<Button>()[0];
        weaponSprite2 = GameObject.Find("HUD/Items/WeaponSlots").GetComponentsInChildren<Button>()[1];
        toolSprite1 = GameObject.Find("HUD/Items/ToolSlots").GetComponentsInChildren<Button>()[0];
        toolSprite2 = GameObject.Find("HUD/Items/ToolSlots").GetComponentsInChildren<Button>()[1];
            
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
                        weapons[0] = transform.Find("player_torso/player_arm_upper/player_arm_lower/player_hand/Knife").gameObject;
                        weapons[0].SetActive(true);
                        Sprite sprite = Resources.Load<Sprite>("Weapons/Knife");
                        if (sprite != null)
                        {
                            weaponSprite1.image.overrideSprite = sprite;
                            weaponSprite1.image.color = Color.white;            // empty slot has Alpha(opacity) to 0, giving an image the color white simply sets the opacity to 100
                        }
                        else
                        {
                            Debug.Log("Sprite not found");
                        }
                        

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
