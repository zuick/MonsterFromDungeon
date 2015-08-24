using UnityEngine;
using System.Collections;

public class Hunger : MonoBehaviour {
	public float hunger = 0f;

	private float interval = 5f;

	private float lastTime = 0f;
	private float currentTime = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime - lastTime > interval) {
			lastTime = currentTime;
			Debug.Log ("Time");
		} 
	}
}
