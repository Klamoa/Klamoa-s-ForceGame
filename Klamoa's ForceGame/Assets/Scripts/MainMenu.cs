
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Slider audioSlider;

	void Awake() {

		audioSlider.value = PlayerPrefs.GetFloat("_volume");

	}

	public void ResetHighScore () {
		PlayerPrefs.SetInt("HighScore", 0);
	}

}
