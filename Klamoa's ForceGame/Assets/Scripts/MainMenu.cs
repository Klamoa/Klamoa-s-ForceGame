using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Slider audioSlider;

	void Awake() {

		audioSlider.value = PlayerPrefs.GetFloat("_volume");

	#if UNITY_STANDALONE				
		//only for no FullscreenScreen.fullScreen = !Screen.fullScreen;
		Screen.SetResolution(1080, 1920, false);
	#endif

	#if UNITY_ANDROID			
		//only for no FullscreenScreen.fullScreen = !Screen.fullScreen;
		Screen.SetResolution(1080, 1920, true);
		Application.targetFrameRate = 30;
	#endif
	}

	public void StartButton (int sceneIndex) {
		SceneManager.LoadSceneAsync (sceneIndex);
	}

	public void QuitButton () {
		Application.Quit ();
		Debug.Log ("Quit!");
	}

}
