using UnityEngine;
using System.Collections;

public class Climbing : MonoBehaviour {
	public float climbingSpeed = 1f;	
	public bool climbing = false;

	private bool grounded;
	private CircleCollider2D circleCollider;
	private Rigidbody2D rigidbody2D;
	private Animator anim;
	private Person basePerson;

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
		grounded = value;
	}

	void ChangeGravityScale( float value ){
		rigidbody2D.gravityScale = value;
	}

	void StartClimbing(){
		if (!basePerson.ragdollEnabled) {
			climbing = true;
			BroadcastMessage ("ChangeGravityScale", 0f);
			anim.SetBool ("Climbing", climbing);
		}
	}

	void StopClimbing(){
		climbing = false;
		BroadcastMessage ("ChangeGravityScale", 1f);
		anim.SetBool ("Climbing", climbing);
	}

	void Start () {
		circleCollider = GetComponent<CircleCollider2D>();
		rigidbody2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		basePerson = GetComponent<Person> ();
	}


	void FixedUpdate(){

		float moveY = Input.GetAxis ("Vertical");
		float moveX = Input.GetAxis ("Horizontal");

		if (moveY > 0f && !climbing ) {
			if( canClimb () ) StartClimbing();
		}

		if (climbing) {
			rigidbody2D.velocity = new Vector2 ( rigidbody2D.velocity.x, moveY * climbingSpeed );
			rigidbody2D.velocity = new Vector2 ( moveX * climbingSpeed, rigidbody2D.velocity.y );
		}

		bool jump = Input.GetButtonDown("Jump");
		
		if (jump) {
			StopClimbing();
		}
	}

	void Update () {

	}
}
