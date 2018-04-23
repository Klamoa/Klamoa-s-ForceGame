using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

	public float speed = 10f;

	private bool triggered = true;

	void Update () {

		//add movement
		speed = Random.Range(5f, 10f);
		transform.position += Vector3.down * speed * Time.deltaTime;

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
