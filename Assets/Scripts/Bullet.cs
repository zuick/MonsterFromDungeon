using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("SelfDestruct", 5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SelfDestruct() {
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) 
	{
		if (collider.gameObject.tag == "Guard" || collider.transform.parent.tag == "Guard") return;

		CancelInvoke("SelfDestruct");
		if (collider.gameObject.tag == "Player" || collider.transform.parent.tag == "Player") {
			Application.LoadLevel(Application.loadedLevel);
		} else {
			Destroy(gameObject);
		}
	}
}
