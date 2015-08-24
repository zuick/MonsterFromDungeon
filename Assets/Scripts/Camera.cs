using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	private Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 camPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
		transform.position = camPos;
	}
}
