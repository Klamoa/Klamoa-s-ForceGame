using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] spawnObjects;
	public float timeBetweenSpawn = 2f;
	public float screenHalfWith = 4.3f;

	float nextSpawn;

	void Update () {

		if(GameManager.alive){
			//spawn gameObject every 'timeBetweenSpawn'
			if (Time.time > nextSpawn) {
				//calculate next spawnTime
				nextSpawn = Time.time + timeBetweenSpawn;

				//choose gmaeObject of spawnObjects
				int randomObject = Random.Range (0, spawnObjects.Length);

				//calculate random posiotion and spawn gameObject
				float randomXPosition = Random.Range (-screenHalfWith, screenHalfWith);
				Vector3 spawnPosition = new Vector3 (randomXPosition, 13f, 0f);
				GameObject myObject = (GameObject)Instantiate (spawnObjects[randomObject], spawnPosition, Quaternion.identity);

				//applying scale
				myObject.transform.localScale = new Vector3 (1, 1, 1);

				//givng mesh a random colour
				//MeshRenderer myMeshRenderer = myObject.GetComponent<MeshRenderer> ();
				//myMeshRenderer.material.color = new Color (Random.value, Random.value, Random.value, Random.value);
			}
		}
	}
}
