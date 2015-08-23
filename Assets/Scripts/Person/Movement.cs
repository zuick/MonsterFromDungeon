using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

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
		
		rigidbody2D.velocity = new Vector2 (moveX * 3f, rigidbody2D.velocity.y);

		bool jump = Input.GetButtonDown("Jump");
		
		if (jump) {
			rigidbody2D.AddForce (new Vector2 (0f, 2000f));
		}
	}
}
