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
		if (gameObject.tag == "Player") {
			PreventCollisionsWithLukes();
		}
	}

	void PreventCollisionsWithLukes()
	{
		GameObject[] lukes = GameObject.FindGameObjectsWithTag("Luke");
		foreach (var luke in lukes) {
			foreach(var collider in gameObject.GetComponents<Collider2D>()) {
				Physics2D.IgnoreCollision(collider, luke.GetComponent<Collider2D>(), true);
			}
			foreach(var childCollider in gameObject.GetComponentsInChildren<Collider2D>()) {
				Physics2D.IgnoreCollision(childCollider, luke.GetComponent<Collider2D>(), true);
			}
		}
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
