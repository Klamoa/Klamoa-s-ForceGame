using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] spawnObjects;
	public float timeBetweenSpawn = 2f;
	public float screenHalfWith = 4.3f;

	float nextSpawn;

	void Update () {
		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + timeBetweenSpawn;

			int randomObject = Random.Range (0, spawnObjects.Length);

			float randomXPosition = Random.Range (-screenHalfWith, screenHalfWith);
			Vector3 spawnPosition = new Vector3 (randomXPosition, 13f, 0);
			GameObject myObject = (GameObject)Instantiate (spawnObjects[randomObject], spawnPosition, Quaternion.identity);

			myObject.transform.localScale = new Vector3 (1, 1, 1);

			//MeshRenderer myMeshRenderer = myObject.GetComponent<MeshRenderer> ();
			//myMeshRenderer.material.color = new Color (Random.value, Random.value, Random.value, Random.value);
		}
	}
}
