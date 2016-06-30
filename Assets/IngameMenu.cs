using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour {

    GameObject endGameScreen;
    GameObject pauseMenu;
    GameObject player;
    bool gamePaused = false;

	// Use this for initialization
	void Start () {
        endGameScreen = GameObject.Find("EndGameScreen");
        pauseMenu = GameObject.Find("PauseMenu");
        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!gamePaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
	}

    public void Pause()
    {
        pauseMenu.GetComponent<Canvas>().enabled = true;
        pauseMenu.transform.FindChild("Btn_continue").GetComponent<Button>().enabled = true;
        pauseMenu.transform.FindChild("Btn_save_game").GetComponent<Button>().enabled = true;
        pauseMenu.transform.FindChild("Btn_settings").GetComponent<Button>().enabled = true;
        pauseMenu.transform.FindChild("Btn_main_menu").GetComponent<Button>().enabled = true;
        gamePaused = true;
        Time.timeScale = 0;
        player.GetComponent<ItemController>().enabled = false;
        player.GetComponent<PlayerHealth>().enabled = false;
        player.GetComponent<WalkingScript>().enabled = false;
    }

    public void Unpause()
    {
        pauseMenu.GetComponent<Canvas>().enabled = false;
        pauseMenu.transform.FindChild("Btn_continue").GetComponent<Button>().enabled = false;
        pauseMenu.transform.FindChild("Btn_save_game").GetComponent<Button>().enabled = false;
        pauseMenu.transform.FindChild("Btn_settings").GetComponent<Button>().enabled = false;
        pauseMenu.transform.FindChild("Btn_main_menu").GetComponent<Button>().enabled = false;
        gamePaused = false;
        Time.timeScale = 1;
        player.GetComponent<ItemController>().enabled = true;
        player.GetComponent<PlayerHealth>().enabled = true;
        player.GetComponent<WalkingScript>().enabled = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("DemoLevel");
    }


    public void EndGame(int exit)
    {
        player.GetComponent<ItemController>().enabled = false;
        player.GetComponent<PlayerHealth>().enabled = false;
        player.GetComponent<WalkingScript>().enabled = false;
        endGameScreen.GetComponent<Canvas>().enabled = true;
        endGameScreen.transform.FindChild("Btn_next_level").GetComponent<Button>().enabled = true;
        endGameScreen.transform.FindChild("Btn_main_menu").GetComponent<Button>().enabled = true;
        Debug.Log(player.GetComponent<PlayerHealth>().totalDamage.ToString());
        endGameScreen.transform.FindChild("Statistics").transform.FindChild("Damage").GetComponent<Text>().text = player.GetComponent<PlayerHealth>().totalDamage.ToString();
        endGameScreen.transform.FindChild("Statistics").transform.FindChild("Deaths").GetComponent<Text>().text = player.GetComponent<PlayerHealth>().totalDeaths.ToString();
        endGameScreen.transform.FindChild("Statistics").transform.FindChild("Kills").GetComponent<Text>().text = player.GetComponent<PlayerHealth>().totalKills.ToString();

        if (exit == 1)
        {
            endGameScreen.transform.FindChild("Progress").transform.FindChild("Exit2").GetComponent<Image>().enabled = true;
        }

        if (exit == 2)
        {
            endGameScreen.transform.FindChild("Progress").transform.FindChild("Exit1").GetComponent<Image>().enabled = true;
        }
    }
}
