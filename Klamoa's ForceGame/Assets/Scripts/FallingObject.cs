using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

	public float speed = 10f;

	void Update () {

		//add movement
		transform.position += Vector3.down * speed * Time.deltaTime;

		//destroy if below ground
		if (transform.position.y < -1f) {
			Destroy (gameObject, 2f);
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "ground") {
			print ("sore");
			GameManager.score += 1;
		}
		print ("OnCollisionEnter");
	}
}
