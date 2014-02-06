using UnityEngine;
using System.Collections;

public class Town2Movement : MonoBehaviour
{
	
	public Transform target;
	public int moveSpeed, rotationSpeed, maxDistance;
	private Transform myTransform;
	public int counter = 0;
	public bool atWall = false;
	
	void Awake ()
	{
		myTransform = transform;	
		moveSpeed = 2;
		rotationSpeed = 3;
	}
	
	GameObject[] movementAllowance;
	// Use this for initialization
	void Start ()
	{
		
		movementAllowance = GameObject.FindGameObjectsWithTag ("SecondPoint");
		
		target = movementAllowance [counter].transform;
		
		maxDistance = 4;
	}
	
	int changeWalkingDirection = 0;
	// Update is called once per frame
	void Update ()
	{
		animation.Play ("walk");
		Debug.DrawLine (target.position, myTransform.position, Color.red);
		
		
		//look at the target
		Quaternion rot;
		
		rot = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		//	rot.y=90.0f;
		myTransform.rotation = rot;
		Vector3 tar = new Vector3 (target.position.x, myTransform.position.y, target.position.z);
		if (Vector3.Distance (target.position, myTransform.position) >= maxDistance) {
			//more towards target
			myTransform.position += new Vector3 (myTransform.forward.x * moveSpeed * Time.deltaTime, 0, myTransform.forward.z * moveSpeed * Time.deltaTime);
			
		}
		//Debug.Log (myTransform.transform.position.z);
		if (Vector3.Distance (target.position, myTransform.position)<= maxDistance) {
			//if(atWall){
			/*changeWalkingDirection = 0;
			counter = Random.Range (0, movementAllowance.Length);*/
			Debug.Log("her");
			counter ++;
			if(counter >8){
				counter = 0;
			}
			target = movementAllowance [counter].transform;
			
			
		}
		
		//changeWalkingDirection++;
	}
	
	void OnTriggerEnter (Collider playerInRange)
	{
		
	}
	
	void OnTriggerExit (Collider playerNotInRange)
	{
		
	}
	
}
