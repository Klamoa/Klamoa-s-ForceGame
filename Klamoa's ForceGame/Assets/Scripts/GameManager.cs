using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static int score = 0;
	public Text scoreText;

	public int inspectorScore;

	void Start () {
		
	}

	void Update () {
		inspectorScore = score;
		scoreText.text = "Score: " + score;
	}
}
