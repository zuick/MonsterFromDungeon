using UnityEngine;
using System.Collections;

public class IgnoreCollisions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (8, 8, true);
		Physics2D.IgnoreLayerCollision (10, 10, true);
		Physics2D.IgnoreLayerCollision (11, 11, true);
		Physics2D.IgnoreLayerCollision (12, 12, true);

	}
	
	// Update is called once per frame
	void Update () {
	}
}
