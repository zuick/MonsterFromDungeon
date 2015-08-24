using UnityEngine;
using System.Collections;

public class BodyPart : MonoBehaviour {
	private Vector2 savedAnchor;
	private Vector2 savedConnectedAnchor;
	private GameObject savedConnectedGameObject;
	private bool savedUseJointLimits;
	private JointAngleLimits2D savedJointLimits;
	// Use this for initialization
	void Start () {
		
	}
		
	void EnableRagdollBodyParts( bool enable ){
		HingeJoint2D joint = GetComponent<HingeJoint2D> ();
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();


		if (enable && !rigid && !joint) {
			transform.gameObject.AddComponent<Rigidbody2D>();
			HingeJoint2D newJoint = transform.gameObject.AddComponent<HingeJoint2D>();
			newJoint.anchor = savedAnchor;
			newJoint.connectedAnchor = savedConnectedAnchor;
			newJoint.connectedBody = savedConnectedGameObject.GetComponent<Rigidbody2D>();
			newJoint.useLimits = savedUseJointLimits;
			newJoint.limits = savedJointLimits;
;
		} else if( !enable && rigid && joint ) {
			savedAnchor = joint.anchor;
			savedConnectedAnchor = joint.connectedAnchor;
			savedConnectedGameObject = joint.connectedBody.gameObject;
			savedUseJointLimits = joint.useLimits;
			savedJointLimits = joint.limits;

			Destroy( joint );
			Destroy( rigid );

		}


	}

	void ChangeGravityScale( float value ){
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D> ();
		if( rigidbody2D ) rigidbody2D.gravityScale = value;
	}

	public void SetGrabbed(){
		SendMessageUpwards ("EnableRagdoll", true);
	}
}
