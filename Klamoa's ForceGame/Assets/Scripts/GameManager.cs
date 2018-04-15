using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

	public static int score = 0;
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
		gameOverScreen.SetActive(false);
	}

	void Update () {
		scoreText.text = "Score: " + score.ToString();
		highScoreText.text = "Highscore: " + highScore.ToString();
		
		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt("HighScore", highScore);
		}

		if (!alive) {
			if(Input.GetKeyDown(KeyCode.Return)){
				score = 0;
				player.transform.position = startPosition;
				alive = true;
			}
		}

		gameOverScreen.SetActive(!alive);
	}

}

