﻿using UnityEngine;
using System.Collections;

public class CitizenMovement : MonoBehaviour {
	public float speed = 1f;

	[HideInInspector] public float moveX = 0;
	
	private bool grounded;
	private Rigidbody2D rigidbody2D;
	private Person person;
	
	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D> ();
		person = GetComponent<Person> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetGroundedState( bool value ){
		grounded = value;
	}

	void FixedUpdate(){
		if (grounded && !person.ragdollEnabled) {
			float newVelocity = moveX * speed;
			
			rigidbody2D.velocity = new Vector2 (newVelocity, rigidbody2D.velocity.y);
			
			SendMessageUpwards ("ChangeAnimSpeed", newVelocity);
		
		}
	}
}
