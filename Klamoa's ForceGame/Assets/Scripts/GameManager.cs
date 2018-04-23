using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

	public static int score = 0;
<<<<<<< HEAD
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
=======
	public int highScore;
	public static bool alive = true;
	public GameObject levelStartScreen;
	public GameObject gameOverScreen;
	public GameObject player;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI highScoreText;
	public Vector3 startPosition = new Vector3(0f, 1f, 0f);
	
	void Start () {
		highScore = PlayerPrefs.GetInt("HighScore");
		levelStartScreen.SetActive(false);
>>>>>>> 80eb15887c6c33487661cbf00bccf137803e96f5
		gameOverScreen.SetActive(false);
		highScore = PlayerPrefs.GetInt("HighScore");
	}

	void Update () {
<<<<<<< HEAD
		inspectorScore = score;
		scoreText.text = "Score: " + score;
		scoreTextGameOverScreen.text = "Score: " + score;
		highScoreTextGameOverScreen.text = "Highscore: " + highScore;
=======
		scoreText.text = "Score: " + score.ToString();
		highScoreText.text = "Highscore: " + highScore.ToString();
		
		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt("HighScore", highScore);
		}
>>>>>>> 80eb15887c6c33487661cbf00bccf137803e96f5

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

