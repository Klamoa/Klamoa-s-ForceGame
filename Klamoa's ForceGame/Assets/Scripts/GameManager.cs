using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

	public static int score = 0;
	public static bool alive;
	public GameObject gameOverScreen;
	public GameObject player;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI scoreTextGameOverScreen;
	public TextMeshProUGUI highScoreTextGameOverScreen;
	public Vector3 startPosition = new Vector3(0f, 1f, 0f);

	public int inspectorScore;
	public int highScore;
	
	void Start () {
		ResetGame();
		gameOverScreen.SetActive(false);
		highScore = PlayerPrefs.GetInt("HighScore");
	}

	void Update () {
		inspectorScore = score;
		scoreText.text = "Score: " + score;
		scoreTextGameOverScreen.text = "Score: " + score;
		highScoreTextGameOverScreen.text = "Highscore: " + highScore;

		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt("HighScore", highScore);
		}

		gameOverScreen.SetActive(!alive);
	}

	void ResetGame () {
		score = 0;
		player.transform.position = startPosition;
		alive = true;		
	}

	public void RestartButton () {
		ResetGame();
	}

	public void MenuButton () {	
		SceneManager.LoadScene (0);
	}
}

