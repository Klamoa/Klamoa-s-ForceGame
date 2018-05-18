using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

	public static int score = 0;
	public static int highScore;
	public static bool alive;

	[Header("Player")]
	public GameObject player;
	
	[Header("UI")]
	public TextMeshProUGUI scoreText;	

	[Header("Mobile Input")]	
	public GameObject mobileInput;

	[Header("Game Over")]
	public GameObject gameOverPauseScreen;
	public Animator animatorGameOverScreen;	
	public TextMeshProUGUI scoreTextGameOverScreen;
	public TextMeshProUGUI highScoreTextGameOverScreen;

	[Header("Startsettings")]
	public Vector3 startPosition = new Vector3(0f, 1f, 0f);

	void Start () {
		ResetGame();
		mobileInput.SetActive(false);
		highScore = PlayerPrefs.GetInt("HighScore");
	}

	void Update () {

		HandleScore();
		GameUI();

	}

	void HandleScore () {
		scoreText.text = "Score: " + score;
		scoreTextGameOverScreen.text = "Score: " + score;
		highScoreTextGameOverScreen.text = "Highscore: " + highScore;

		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt("HighScore", highScore);
		}
	}

	void GameUI () {
	#if UNITY_ANDROID
		mobileInput.SetActive(true);
	#endif
		animatorGameOverScreen.SetBool("GameOverOn", !alive);
	}

	void ResetGame () {
		score = 0;
		ResetGameOverPauseScreen();
		player.transform.position = startPosition;
		player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		alive = true;
	}

	public void RestartButton () {
		ResetGame();
	}

	public void SetGameOverPauseScreen () {
		gameOverPauseScreen.SetActive(true);
	}

	public void ResetGameOverPauseScreen () {
		gameOverPauseScreen.SetActive(false);
	}

}
