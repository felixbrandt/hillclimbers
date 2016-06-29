using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemController : MonoBehaviour {


    public GameObject[] weapons = new GameObject[2];
    public GameObject[] tools = new GameObject[2];
    public GameObject hook;
	public Transform firePoint;
    public PlayerHealth health;
    public bool damageOverTimeActive;
    public float damage = 0f;
    private Button weaponSprite1;
    private Button weaponSprite2;
    private Button toolSprite1;
    private Button toolSprite2;




    // Use this for initialization
    void Start() {
        health = GetComponent<PlayerHealth>();
        weaponSprite1 = GameObject.Find("HUD/Items/WeaponSlots").GetComponentsInChildren<Button>()[0];
        weaponSprite2 = GameObject.Find("HUD/Items/WeaponSlots").GetComponentsInChildren<Button>()[1];
        toolSprite1 = GameObject.Find("HUD/Items/ToolSlots").GetComponentsInChildren<Button>()[0];
        toolSprite2 = GameObject.Find("HUD/Items/ToolSlots").GetComponentsInChildren<Button>()[1];
        Activate(1);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1")){
            Activate(1);
        }
        if (Input.GetKeyDown("2"))
        {
            Activate(2);
        }
        if (Input.GetKeyDown("3"))
        {
            Activate(3);
        }
        if (Input.GetKeyDown("4"))
        {
            Activate(4);
        }


    }

	void OnTriggerEnter2D(Collider2D collider){

		if (collider.CompareTag("icicleTrap"))
		{
			collider.gameObject.GetComponentInChildren<Animator> ().SetTrigger ("Falling");
		}

        if (collider.CompareTag("icicle"))
        {
            if (damageOverTimeActive == false)
            {
                StartCoroutine("DamageOverTime");
                damageOverTimeActive = true;
            }
        }

        if (collider.CompareTag("stoneTrap"))
        {
            health.TakeDamage(100);
        }


        if (collider.CompareTag ("weapon")) {
            Debug.Log("entered collider");
            if (weapons [0] == null) {
                Debug.Log("weaponslot free");
                switch (collider.gameObject.name)
                {
                    case "KnifeItem":
                        weapons[0] = transform.Find("player_torso/player_arm_upper/player_arm_lower/player_hand/Knife").gameObject;
                        GetComponent<PlayerAttack>().enabled = true;
                        GetComponent<Grapplinghook>().enabled = false;
                        Activate(1);
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
                switch (collider.gameObject.name)
                {
                    case "HookItem":
                        tools[0] = transform.Find("player_torso/player_arm_upper/player_arm_lower/player_hand/Hook").gameObject;
                        GetComponent<PlayerAttack>().enabled = false;
                        GetComponent<Grapplinghook>().enabled = true;
                        Activate(3);
                        Sprite sprite = Resources.Load<Sprite>("Tools/Grapplinghook");
                        if (sprite != null)
                        {
                            toolSprite1.image.overrideSprite = sprite;
                            toolSprite1.image.color = Color.white;            // empty slot has Alpha(opacity) to 0, giving an image the color white simply sets the opacity to 100
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
            }
            else if (tools [1] == null) {

			} else {
				Debug.Log ("toolslots full");
			}
		}
	}

    void OnTriggerExit2D(Collider2D collider)
    {
        damageOverTimeActive = false;
        StopCoroutine("DamageOverTime");
    }

    private IEnumerator DamageOverTime()
    {
        while (true)
        {
            health.TakeDamage(36);
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Activate(int i)
    {
        switch (i){
            case 1:
                weaponSprite1.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = true;
                weaponSprite2.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = false;
                toolSprite1.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = false;
                toolSprite2.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = false;
                GetComponent<PlayerAttack>().enabled = false;
                GetComponent<Grapplinghook>().enabled = false;
                if (weapons[0] != null)
                {
                    GetComponent<PlayerAttack>().enabled = true;
                    GetComponent<Grapplinghook>().enabled = false;
                    weapons[0].SetActive(true);
                }
                if (weapons[1] != null)
                {
                    weapons[1].SetActive(false);
                }
                if (tools[0] != null)
                {
                    tools[0].SetActive(false);
                }
                if (tools[1] != null)
                {
                    tools[1].SetActive(false);
                }
                break;

            case 2:
                weaponSprite1.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = false;
                weaponSprite2.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = true;
                toolSprite1.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = false;
                toolSprite2.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = false;
                GetComponent<PlayerAttack>().enabled = false;
                GetComponent<Grapplinghook>().enabled = false;
                if (weapons[0] != null)
                {
                    weapons[0].SetActive(false);
                }
                if (weapons[1] != null)
                {
                    GetComponent<PlayerAttack>().enabled = true;
                    GetComponent<Grapplinghook>().enabled = false;
                    weapons[1].SetActive(true);
                }
                if (tools[0] != null)
                {
                    tools[0].SetActive(false);
                }
                if (tools[1] != null)
                {
                    tools[1].SetActive(false);
                }
                break;

            case 3:
                weaponSprite1.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = false;
                weaponSprite2.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = false;
                toolSprite1.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = true;
                toolSprite2.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = false;
                GetComponent<PlayerAttack>().enabled = false;
                GetComponent<Grapplinghook>().enabled = false;
                if (weapons[0] != null)
                {
                    weapons[0].SetActive(false);
                }
                if (weapons[1] != null)
                {
                    weapons[1].SetActive(false);
                }
                if (tools[0] != null)
                {
                    GetComponent<PlayerAttack>().enabled = false;
                    GetComponent<Grapplinghook>().enabled = true;
                    tools[0].SetActive(true);
                }
                if (tools[1] != null)
                {
                    tools[1].SetActive(false);
                }
                break;

            case 4:
                weaponSprite1.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = false;
                weaponSprite2.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = false;
                toolSprite1.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = false;
                toolSprite2.transform.FindChild("Activated").gameObject.GetComponent<Image>().enabled = true;
                GetComponent<PlayerAttack>().enabled = false;
                GetComponent<Grapplinghook>().enabled = false;
                if (weapons[0] != null)
                {
                    weapons[0].SetActive(false);
                }
                if (weapons[1] != null)
                {
                    weapons[1].SetActive(false);
                }
                if (tools[0] != null)
                {
                    tools[0].SetActive(false);
                }
                if (tools[1] != null)
                {
                    GetComponent<PlayerAttack>().enabled = false;
                    GetComponent<Grapplinghook>().enabled = false;
                    tools[1].SetActive(true);
                }
                break;
        }

    }
}
