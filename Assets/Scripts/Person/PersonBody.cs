using UnityEngine;
using System.Collections;

public class PersonBody : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (8, 8, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
