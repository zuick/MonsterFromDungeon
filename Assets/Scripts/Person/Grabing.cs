using UnityEngine;
using System.Collections;

public class Grabing : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool grab = Input.GetButtonDown("Fire1");
		
		if (grab) {
			Collider2D[] objects = Physics2D.OverlapCircleAll( transform.position, 0.1f );
			foreach( Collider2D col in objects ){
				if( col.transform.CompareTag("Citizen") )
					Debug.Log ("GRAB");
			}
		}
	}
}
