using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 3f;

	private Rigidbody2D rigidbody2D;
	private Climbing climbing;

	// Use this for initialization
	void Start () {
		climbing = GetComponent<Climbing> ();
		rigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (!climbing.climbing) {

			float moveX = Input.GetAxis ("Horizontal");
			float newVelocity = moveX * speed;
			
			rigidbody2D.velocity = new Vector2 (newVelocity, rigidbody2D.velocity.y);
			
			SendMessageUpwards ("ChangeAnimSpeed", newVelocity);
		}
	}
}
