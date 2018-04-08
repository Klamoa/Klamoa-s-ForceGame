using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

	public static int score = 0;
	public static bool alive = true;
	public GameObject levelStartScreen;
	public GameObject gameOverScreen;
	public GameObject player;
	public TextMeshProUGUI scoreText;
	public Vector3 startPosition = new Vector3(0f, 1f, 0f);
	public int inspectorScore;
	
	void Start () {
		levelStartScreen.SetActive(false);
		gameOverScreen.SetActive(false);
	}

	void Update () {
		inspectorScore = score;
		scoreText.text = "Score: " + score;

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

