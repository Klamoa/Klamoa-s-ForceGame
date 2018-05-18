using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenue : MonoBehaviour {

	public GameObject pauseMenue;
	public TextMeshProUGUI scoreTextPauseMenue;
	public TextMeshProUGUI highScoreTextPauseMenue;

	void Start () {
		RunGame();
	}

	public void PauseGame () {

		HandleScore();

		Time.timeScale = 0f;

		pauseMenue.SetActive(true);
	}

	public void RunGame () {

		Time.timeScale = 1f;

		pauseMenue.SetActive(false);

	}

	void HandleScore () {
		scoreTextPauseMenue.text = "Score: " + GameManager.score;
		highScoreTextPauseMenue.text = "Highscore: " + GameManager.highScore;
	}

}
