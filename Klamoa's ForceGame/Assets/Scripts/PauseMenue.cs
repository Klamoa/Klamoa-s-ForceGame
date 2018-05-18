using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenue : MonoBehaviour {

	[Header("Pause Menue")]
	public Animator animatorPauseMenue;
	public TextMeshProUGUI scoreTextPauseMenue;
	public TextMeshProUGUI highScoreTextPauseMenue;

	void Start () {
		RunGame();
	}

	public void PauseGame () {

		HandleScore();

		Time.timeScale = 0f;

		FindObjectOfType<GameManager>().SetGameOverPauseScreen();

		animatorPauseMenue.SetBool("PauseMenueOn", true);
	}

	public void RunGame () {

		Time.timeScale = 1f;

		FindObjectOfType<GameManager>().ResetGameOverPauseScreen();

		animatorPauseMenue.SetBool("PauseMenueOn", false);

	}

	void HandleScore () {
		scoreTextPauseMenue.text = "Score: " + GameManager.score;
		highScoreTextPauseMenue.text = "Highscore: " + GameManager.highScore;
	}

}
