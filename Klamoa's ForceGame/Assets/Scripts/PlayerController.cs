using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector3 calculatedForce;
	public float force = 10f;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Keyboard INPUT
		//get the input
		if(GameManager.alive){
			float inputX = Input.GetAxisRaw ("Horizontal");

			//calculate force
			calculatedForce = Vector3.right * inputX * force * Time.deltaTime;

			//add force to rigidBody
			rb.AddForce (calculatedForce);
		}
	}

	void OnTriggerEnter(Collider other)
	{
<<<<<<< HEAD
		if(other.gameObject.tag == "fallingObject"){
=======
		if(other.gameObject.tag == "fallingObject") {
>>>>>>> 80eb15887c6c33487661cbf00bccf137803e96f5
			GameManager.alive = false;
			foreach(GameObject g in GameObject.FindGameObjectsWithTag("fallingObject")) {
				Destroy(g);
			}
		}
	}
}