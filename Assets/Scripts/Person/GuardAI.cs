using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class GuardAI : MonoBehaviour {

	public Transform WallToPlacePrefab;
	public Transform BulletPrefab;
	public string EnemyTag = "Player";
	public float MinThinkingTime = 1f;
	public float MaxThinkingTime = 5f;
	public float MinWalkingTime = 1f;
	public float MaxWalkingTime = 5f;

	private CitizenMovement movementComponent;
	private Person personComponent;
	private Transform myHead;
	private bool isAttacking;

	// Use this for initialization
	void Awake () 
	{
		isAttacking = false;
		movementComponent = gameObject.GetComponent<CitizenMovement>();
		personComponent = gameObject.GetComponent<Person>();
		Transform[] childTransforms = GetComponentsInChildren<Transform>();
		foreach (Transform childTransform in childTransforms) {
			if (childTransform.gameObject.name == "head") {
				myHead = childTransform;
				break;
			}
		}
	}

	void Start() 
	{
		StopAndThink();
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (!isAttacking) {
			Transform whichEnemyInSight;
			if (IsEnemyInSight(out whichEnemyInSight)) {
				//Debug.Log("I see " + whichEnemyInSight.name);
				//Debug.DrawRay(myHead.position, (whichEnemyInSight.position - myHead.position).normalized, Color.green);
				StartCoroutine(StopAndAttack(whichEnemyInSight));
			}
		}
	}

	IEnumerator StopAndAttack(Transform target)
	{
		isAttacking = true;
		CancelInvoke("ChangeMoving");
		CancelInvoke("StopAndThink");
		movementComponent.moveX = 0;
		yield return new WaitForSeconds(1);

		Vector2 direction = (target.position - transform.position).normalized; //Quaternion.LookRotation
		Transform bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as Transform;
		if (bullet != null) {
			bullet.GetComponent<Rigidbody2D>().velocity = direction * 5;
			//bullet.GetComponent<SpriteRenderer>().sortingLayerName = "Particles";
		}
		isAttacking = false;
		StopAndThink();
	}

	void StopAndThink()
	{
		movementComponent.moveX = 0;
		float thinkingTime = Random.Range(MinThinkingTime, MaxThinkingTime);
		Invoke("ChangeMoving", thinkingTime);
	}

	void ChangeMoving()
	{
		int direction = Random.Range(0, 2);
		if (direction == 0) direction = -1;
		movementComponent.moveX = direction;

		float walkingTime = Random.Range(MinWalkingTime, MaxWalkingTime);
		Invoke("StopAndThink", walkingTime);
	}

	bool IsEnemyInSight(out Transform whichEnemy)
	{
		whichEnemy = null;
		GameObject[] enemys = GameObject.FindGameObjectsWithTag(EnemyTag);
		foreach (GameObject enemy in enemys) {
			if (personComponent.leftFace && enemy.transform.position.x < myHead.position.x || !personComponent.leftFace && enemy.transform.position.x > myHead.position.x) {
				//int direction = personComponent.leftFace ? -1 : 1;
				var enemyDirection = (enemy.transform.position - myHead.position).normalized;
				//Debug.DrawRay(myHead.position, enemyDirection, Color.green);
				RaycastHit2D rayHit = Physics2D.Raycast(myHead.position, enemyDirection);
				//Debug.Log("My eyes see " + rayHit.collider.gameObject.GetComponentInParent<Transform>().name);
				//whichEnemy = rayHit.transform;
				if (rayHit.collider != null) {
					if (rayHit.transform == enemy.transform || rayHit.transform.parent == enemy.transform) {
						whichEnemy = rayHit.transform;
						return true;
					}
				}
			} else {
				return false;
			}
		}
		return false;
	}

	bool IsSteepAhead()
	{
		return false;
		//if (Physics.Raycast(transform.position, fwd, 10))
			print("There is something in front of the object!");
	}
}
