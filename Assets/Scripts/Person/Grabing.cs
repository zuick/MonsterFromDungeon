using UnityEngine;
using System.Collections;

public class Grabing : MonoBehaviour {
	public float grabRadious = 0.5f;
	private HingeJoint2D grabJoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool grab = Input.GetButtonDown("Fire1");
		
		if (grab) {

			if( grabJoint ){
				Destroy( grabJoint );
			}else{
				Collider2D[] objects = Physics2D.OverlapCircleAll( transform.position, grabRadious );
				foreach( Collider2D col in objects ){
					if( col.transform.CompareTag("Grabable") ){
						BodyPart part = col.transform.gameObject.GetComponent<BodyPart>();
						if( part ){
							part.SetGrabbed();
							grabJoint = part.gameObject.AddComponent<HingeJoint2D>();
							Rigidbody2D r = GetComponent<Rigidbody2D>();
							grabJoint.connectedBody = r;
							return;
						}
					}
					
				}
			}
		}
	}
}
