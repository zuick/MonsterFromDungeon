using UnityEngine;
using System.Collections;

public class BodyPart : MonoBehaviour {

	public bool useJointLimits = true;
	private HingeJoint2D joint;

	// Use this for initialization
	void Start () {
		//set stable state
		joint = GetComponent<HingeJoint2D>();

		SetJointLimits (useJointLimits);
	}

	void SetJointLimits( bool useLimits ){
		JointAngleLimits2D limits = joint.limits;
		limits.max = 0f;
		limits.min = 0f;
		joint.limits = limits;
		UseJointLimits (useLimits);
	}
		
	void UseJointLimits( bool useLimits ){
		if (joint != null) {
			joint.useLimits = useLimits;		
		}
		useJointLimits = useLimits;		
	}
}
