using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public bool isDead;                                         // Whether the player is dead.

    //for Statistics:
    public int totalDamage = 0;
    public int totalDeaths = 0;
    public int totalKills = 0;

    Animator anim;                                              // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    GameObject respawnMenu;

    bool damaged;                                               // True when the player gets damaged.

    


    void Awake()
    {
        // Setting up the references.
        //anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        respawnMenu = GameObject.Find("Respawn");
        // Set the initial health of the player.
        currentHealth = startingHealth;
    }


    void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        if (!isDead) {
            // Set the damaged flag so the screen will flash.
            damaged = true;

            // Reduce the current health by the damage amount.
            currentHealth -= amount;
            healthSlider.value = currentHealth;
            totalDamage += amount;


            // Play the hurt sound effect.
            // playerAudio.Play();
            }
        }


        void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
		GetComponent<Animator> ().SetTrigger ("Die");
        respawnMenu.GetComponent<Canvas>().enabled = true;
        respawnMenu.transform.FindChild("Btn_respawn").GetComponent<Button>().enabled = true;
        respawnMenu.transform.FindChild("Btn_main_menu").GetComponent<Button>().enabled = true;

        totalDeaths += 1;

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        playerAudio.clip = deathClip;
        playerAudio.Play();

        // Turn off the movement scripts.
        GetComponent<WalkingScript>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        GetComponent<Grapplinghook>().enabled = false;
    }

}