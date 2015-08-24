using UnityEngine;
using System.Collections;

public class Climbing : MonoBehaviour {
	public float climbingSpeed = 3f;	
	private bool grounded;

	private CircleCollider2D circleCollider;
	private bool climbing = false;
	private Rigidbody2D rigidbody2D;

	bool isInRect( Vector2 Point){
		return true;
	}

	bool canClimb(){
		GameObject[] objectsBehind = GameObject.FindGameObjectsWithTag ("Climbable");

		foreach (GameObject obj in objectsBehind) {
			Renderer objRenderer = obj.transform.GetComponent<Renderer>();
			if ( objRenderer ){
				if( circleCollider.bounds.Intersects( objRenderer.bounds ) ){
					return true;
				}

			}
		}
		return false;
	}

	
	void SetGroundedState( bool value ){
		if (!grounded && value ) { // grounded become true
			StopClimbing();
		}
	}

	void ChangeGravityScale( float value ){
		rigidbody2D.gravityScale = value;
	}

	void StartClimbing(){
		climbing = true;
		BroadcastMessage ("ChangeGravityScale", 0f);
	}

	void StopClimbing(){
		climbing = false;
		BroadcastMessage ("ChangeGravityScale", 1f);
	}

	void Start () {
		circleCollider = GetComponent<CircleCollider2D>();
		rigidbody2D = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate(){

		float moveY = Input.GetAxis ("Vertical");
		if (moveY != 0f && !climbing ) {
			if( canClimb () ) StartClimbing();
		}

		if (climbing) {
			if( canClimb () ) rigidbody2D.velocity = new Vector2 ( rigidbody2D.velocity.x, moveY * climbingSpeed );
			else StopClimbing();
		}
	}

	void Update () {

	}
}
