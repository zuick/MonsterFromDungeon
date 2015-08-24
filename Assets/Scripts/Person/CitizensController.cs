using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class CitizensController : MonoBehaviour {
	
	public GameObject LeftSpawnPoint;
	public GameObject RightSpawnPoint;
	public Transform[] CitizensPrefabs;
	public float SpawnInterval = 3.0f;
	
	private List<GameObject> CitizensList;

	// Use this for initialization
	void Start () 
	{
		CitizensList = new List<GameObject>();
		Invoke("SpawnCitizen", RandomizeInterval());
	}
	
	// Update is called once per frame
	void Update () {
		if (CitizensList == null) return;
		
		List<GameObject> citizensDestroyed = new List<GameObject>();
		foreach (GameObject citizen in CitizensList) {
			float citizenMoveX = citizen.GetComponent<CitizenMovement>().moveX;
			if (citizenMoveX < 0 && citizen.transform.position.x < LeftSpawnPoint.transform.position.x) {
				citizensDestroyed.Add(citizen);
				Destroy(citizen);
			} else if (citizenMoveX > 0 && citizen.transform.position.x > RightSpawnPoint.transform.position.x) {
				citizensDestroyed.Add(citizen);
				Destroy(citizen);
			}
		}
		foreach (GameObject destroyedCitizen in citizensDestroyed) {
			CitizensList.Remove(destroyedCitizen);
		}
	}
	
	float RandomizeInterval()
	{
		return Random.Range(SpawnInterval - 1f, SpawnInterval + 1f);
	}
	
	void SpawnCitizen() 
	{
		int direction = Random.Range(0, 2);
		int citizenToInst = Random.Range(0, CitizensPrefabs.Length);
		if (direction == 0) {
			var instance = Instantiate(CitizensPrefabs[citizenToInst], RightSpawnPoint.transform.position, RightSpawnPoint.transform.rotation);
			GameObject newCitizen = ((Transform)instance).gameObject;
			//GameObject newCitizen = ((Rigidbody2D)Instantiate(CitizenPrefab, RightSpawnPoint.transform.position, RightSpawnPoint.transform.rotation)).gameObject;
			newCitizen.GetComponent<CitizenMovement>().moveX = -1;
			CitizensList.Add(newCitizen);
		} else {
			var instance = Instantiate(CitizensPrefabs[citizenToInst], LeftSpawnPoint.transform.position, LeftSpawnPoint.transform.rotation);
			GameObject newCitizen = ((Transform)instance).gameObject;
			newCitizen.GetComponent<CitizenMovement>().moveX = 1;
			CitizensList.Add(newCitizen);
		}
		Invoke("SpawnCitizen", RandomizeInterval());
	}
}
