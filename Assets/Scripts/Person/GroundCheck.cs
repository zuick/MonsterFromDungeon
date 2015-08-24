using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {
	public bool grounded = false;
	public float groundCheckRadious = 0.1f;
	public LayerMask groundLayer;

	// Use this for initialization
	void Start () {
	
	}
			
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (transform.position, groundCheckRadious, groundLayer);
		SendMessageUpwards ("SetGroundedState", grounded);
	}
}
