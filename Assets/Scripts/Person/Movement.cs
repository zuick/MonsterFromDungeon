using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 3f;
	public float jumpForce = 2000f;

	private Rigidbody2D rigidbody2D;
	
	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		float moveX = Input.GetAxis ("Horizontal");
		float newVelocity = moveX * speed;

		rigidbody2D.velocity = new Vector2 (newVelocity, rigidbody2D.velocity.y);

		bool jump = Input.GetButtonDown("Jump");
		
		if (jump) {
			rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
		}

		SendMessageUpwards ("ChangeAnimSpeed", newVelocity);
	}
}
