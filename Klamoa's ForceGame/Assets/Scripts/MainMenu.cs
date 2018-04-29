using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	void Awake() {		
		//only for no FullscreenScreen.fullScreen = !Screen.fullScreen;
		Screen.SetResolution(1080, 1920, false);
	}

	public void StartButton () {
		SceneManager.LoadScene (1);
	}

	public void QuitButton () {
		Application.Quit ();
		Debug.Log ("Quit!");
	}

}
