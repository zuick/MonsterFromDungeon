using UnityEngine;
using System.Collections;

public class CitizenMovement : MonoBehaviour {
	public float speed = 1f;

	[HideInInspector] public float moveX = 0;
	
	private Rigidbody2D rigidbody2D;
	
	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate(){
		//float moveX = Input.GetAxis ("Horizontal");
		float newVelocity = moveX * speed;
		
		rigidbody2D.velocity = new Vector2 (newVelocity, rigidbody2D.velocity.y);
		
		SendMessageUpwards ("ChangeAnimSpeed", newVelocity);
	}
}
