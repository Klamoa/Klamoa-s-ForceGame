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

		float inputX = Input.GetAxisRaw ("Horizontal");

		calculatedForce = Vector3.right * inputX * force * Time.deltaTime;

		rb.AddForce (calculatedForce);

	}
}
