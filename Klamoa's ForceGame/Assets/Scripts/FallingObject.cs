using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

	public float speedMax = 15f;
	public float speedMin = 8f;
	float randomSpeed;

	private bool triggered = true;

	void Start () {
		randomSpeed = Random.Range(speedMin, speedMax);
	}

	void Update () {

		//add movement
		transform.position += Vector3.down * randomSpeed * Time.deltaTime;

		//destroy if below ground
		if (transform.position.y < -1f) {
			Destroy (gameObject, 2f);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "ground" && triggered) {
			GameManager.score += 1;
			triggered = false;
		}
	}

}
