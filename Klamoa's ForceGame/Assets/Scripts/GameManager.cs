using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

	public static int score = 0;
	public TextMeshProUGUI scoreText;

	public int inspectorScore;

	void Start () {
		
	}

	void Update () {
		inspectorScore = score;
		scoreText.text = "Score: " + score;
	}
}
