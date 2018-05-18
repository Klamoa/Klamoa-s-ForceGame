using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 calculatedForce;
	public float force = 10f;
	public Rect rectLeft;
	public Rect rectRight;
	public ParticleSystem windEffectRight;
	public ParticleSystem windEffectLeft;

	private Rigidbody rb;
	private AudioManager myAudioManager;
	private bool windleftBool = false;
	private bool windrightBool = false;

	void Awake () {
		myAudioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
	}

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

		//myAudioManager = FindObjectOfType<AudioManager>(); //Doesn't work in Awake() or in Start(), is not a performent way to do it

		if(calculatedForce.x > 0f && !windleftBool){
			//Debug.Log("WindLeft");
			windEffectLeft.Play();
			windEffectRight.Stop();
			myAudioManager.Play("WindSound");
			windleftBool = true;
		}

		if(calculatedForce.x < 0f && !windrightBool){
			//Debug.Log("WindRight");
			windEffectRight.Play();
			windEffectLeft.Stop();
			myAudioManager.Play("WindSound");
			windrightBool = true;
		}

		if(calculatedForce.x == 0f){
			windEffectLeft.Stop();
			windEffectRight.Stop();
			myAudioManager.Stop("WindSound");
			windleftBool = false;
			windrightBool = false;
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "fallingObject"){
			GameObject[] fallingObjects = GameObject.FindGameObjectsWithTag("fallingObject");
			foreach (GameObject g in fallingObjects) {
				Destroy(g);
			}
			GameManager.alive = false;
		}
	}
}