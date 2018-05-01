using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector3 calculatedForce;
	public float force = 10f;
	public Rect rectLeft;
	public Rect rectRight;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
#if UNITY_STANDALONE		
		//Keyboard INPUT
		//get the input
		if(GameManager.alive){
			float inputX = Input.GetAxisRaw ("Horizontal");

			//calculate force
			calculatedForce = Vector3.right * inputX * force * Time.deltaTime;
		} else {
			calculatedForce = Vector3.right * 0f;
		}
#endif
		
#if UNITY_ANDROID

		if(GameManager.alive){

			//Mobile Input
			if(Input.touchCount > 0){

				Touch touch = Input.touches[0];

				if(rectLeft.Contains(touch.position)){
					if(Input.GetButton("Fire1")){
						//Debug.Log("Left");
						calculatedForce = -Vector3.right * force * Time.deltaTime;
					}
				}

				if(rectRight.Contains(Input.mousePosition)){
					if(Input.GetButton("Fire1")){
						//Debug.Log("Right");
						calculatedForce = Vector3.right * force * Time.deltaTime;
					}
				}
			} else {
				calculatedForce = Vector3.right * 0f;
			}
		} else {
			calculatedForce = Vector3.right * 0f;
		}
#endif

		//add force to rigidBody
		rb.AddForce (calculatedForce);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "fallingObject"){
			GameManager.alive = false;
			foreach(GameObject g in GameObject.FindGameObjectsWithTag("fallingObject")) {
				Destroy(g);
			}
		}
	}
}