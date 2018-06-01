using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] spawnObjects;
	public float minTimeBetweenSpawns = 0.5f;
	public float maxTimeBetweenSpawns = 2f;
	public float timeBetweenSpawn;
	public float screenHalfWith = 4.3f;
	public Vector2 spawnAngleZ = new Vector2(15f, -15f);
	public Vector2 spawnAngleX = new Vector2(15f, -15f);

	float nextSpawn;

	void Update () {

		if (!GameManager.alive){
			timeBetweenSpawn = maxTimeBetweenSpawns;
		}

		if(GameManager.alive){
			//spawn gameObject every 'timeBetweenSpawn'
			if (Time.time > nextSpawn){
				//calculate next spawnTime
				nextSpawn = Time.time + timeBetweenSpawn;
				if (timeBetweenSpawn >= minTimeBetweenSpawns){
					timeBetweenSpawn -= 0.05f;
				}

				//choose gmaeObject of spawnObjects
				int randomObject = Random.Range (0, spawnObjects.Length);

				//calculate random posiotion and spawn gameObject
				float randomXPosition = Random.Range (-screenHalfWith, screenHalfWith);
				float randomRotationZ = Random.Range (spawnAngleZ.x, spawnAngleZ.y);
				float randomRotationX = Random.Range (spawnAngleX.x, spawnAngleX.y);
				Vector3 spawnPosition = new Vector3 (randomXPosition, 13f, 0f);
				Vector3 spawnRotation = new Vector3 (randomRotationX, 0f, randomRotationZ);
				GameObject myObject = (GameObject)Instantiate (spawnObjects[randomObject], spawnPosition, Quaternion.Euler(spawnRotation));

				//applying scale
				//myObject.transform.localScale = new Vector3 (1, 1, 1);

				//givng mesh a random colour
				//MeshRenderer myMeshRenderer = myObject.GetComponent<MeshRenderer> ();
				//myMeshRenderer.material.color = new Color (Random.value, Random.value, Random.value, Random.value);
			}
		}
	}
}
