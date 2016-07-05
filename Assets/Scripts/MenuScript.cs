using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	public void StartGame () {
		SceneManager.LoadScene ("DemoLevel");
	}
	
	// Update is called once per frame
	public void Exit() {
		Application.Quit ();
	}
}
