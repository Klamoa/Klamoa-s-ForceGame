using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

	public static int score = 0;
	public int highScore;
	public static bool alive;
	public GameObject gameOverScreen;
	public GameObject mobileInput;
	public GameObject player;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI scoreTextGameOverScreen;
	public TextMeshProUGUI highScoreTextGameOverScreen;
	public Vector3 startPosition = new Vector3(0f, 1f, 0f);
	
	void Start () {
		ResetGame();
		gameOverScreen.SetActive(false);
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
		gameOverScreen.SetActive(!alive);
	}

	void ResetGame () {
		score = 0;
		player.transform.position = startPosition;
		player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		alive = true;		
	}

	public void RestartButton () {
		ResetGame();
	}

	public void MenuButton () {	
		SceneManager.LoadScene (0);
	}
}

