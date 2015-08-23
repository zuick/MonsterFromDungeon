using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Person : MonoBehaviour {

	public bool ragdollEnabled = false;
	private List<GameObject> bodyParts = new List<GameObject>();
	private GameObject noRagdoll;

	void EnableRagdoll( bool enabled ){
		foreach (GameObject part in bodyParts) {
			HingeJoint2D joint = part.GetComponent<HingeJoint2D>();
			JointAngleLimits2D limits = joint.limits;
			limits.max = 0f;
			limits.min = 0f;
			joint.limits = limits;
			joint.useLimits = !enabled;
		}

		noRagdoll.SetActive (!enabled);
		ragdollEnabled = enabled;
	}

	void SetBodyPartsAngleLimits(){
		foreach (GameObject part in bodyParts) {
			HingeJoint2D joint = part.GetComponent<HingeJoint2D>();
			JointAngleLimits2D limits = joint.limits;
			limits.max = 0f;
			limits.min = 0f;
			joint.limits = limits;
		}
	}
	
	// Use this for initialization
	void Start () {
		// ignore body parts collisions with themselves
		Physics2D.IgnoreLayerCollision (8, 8, true);

		foreach(Transform child in transform){
			if(child.CompareTag("BodyPart"))
				bodyParts.Add(child.gameObject);
		}

		foreach(Transform child in transform){
			if(child.CompareTag("noRagdoll"))
				noRagdoll = child.gameObject;
		}

		SetBodyPartsAngleLimits ();
		EnableRagdoll (ragdollEnabled);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			EnableRagdoll (!ragdollEnabled);
		}
	}

}
