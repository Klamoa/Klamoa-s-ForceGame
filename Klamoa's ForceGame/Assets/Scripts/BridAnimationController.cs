using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridAnimationController : MonoBehaviour {

	public int animationNumber;
	public float waitTime;

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
		anim.SetInteger("animationNumber", 0);
		StartCoroutine(DelayAnimation(waitTime));
	}

	IEnumerator DelayAnimation (float _waitTime) {

		yield return new WaitForSeconds(_waitTime);
		anim.SetInteger("animationNumber", animationNumber);
	}

}
