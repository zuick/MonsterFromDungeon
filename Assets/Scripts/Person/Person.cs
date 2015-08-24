using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Person : MonoBehaviour {

	public bool ragdollEnabled = false;
	public bool leftFace = true;

	private CircleCollider2D circleCollider;
	private Animator anim;

	void EnableRagdoll( bool enabled ){
		BroadcastMessage ("UseJointLimits", !enabled);

		circleCollider.enabled = !enabled;
		anim.enabled = !enabled;

		ragdollEnabled = enabled;
		if(enabled) anim.SetFloat ("Speed", 0f );

	}

	void setLeftFacing( bool left ){
		Vector3 scale = transform.localScale;
		if (left) {
			scale.x = 1f;
		} else {
			scale.x = -1f;
		}

		transform.localScale = scale;
	}

	void ChangeAnimSpeed( float speed ){
		anim.SetFloat ("Speed", Mathf.Abs( speed ) );
		if( speed != 0f ) setLeftFacing (speed < 0);
	}

	// Use this for initialization
	void Start () {
		// ignore body parts collisions with themselves
		Physics2D.IgnoreLayerCollision (8, 8, true);

		anim = GetComponent<Animator> ();
		circleCollider = GetComponent<CircleCollider2D> ();

		EnableRagdoll (ragdollEnabled);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			EnableRagdoll (!ragdollEnabled);
		}
	}

}
