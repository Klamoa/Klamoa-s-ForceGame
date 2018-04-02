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
		float inputX = Input.GetAxisRaw ("Horizontal");

		//calculate force
		calculatedForce = Vector3.right * inputX * force * Time.deltaTime;

		//add force to rigidBody
		rb.AddForce (calculatedForce);

	}
}
