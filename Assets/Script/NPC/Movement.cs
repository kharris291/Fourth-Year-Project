using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	
		public Transform target;
		public int moveSpeed, rotationSpeed, maxDistance;
		private Transform myTransform;
		int counter = 0;
		public bool atWall = false;

		void Awake ()
		{
				myTransform = transform;	
				moveSpeed = 2;
				rotationSpeed = 3;
		}

		GameObject[] go;
		GameObject[] houses;
		// Use this for initialization
		void Start ()
		{
		
				go = GameObject.FindGameObjectsWithTag ("Wall");
		
				houses = GameObject.FindGameObjectsWithTag ("House");
				target = go [counter].transform;
		
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
				if (Vector3.Distance (target.position, myTransform.position) > maxDistance) {
						//more towards target
						myTransform.position += new Vector3 (myTransform.forward.x * moveSpeed * Time.deltaTime, 0, myTransform.forward.z * moveSpeed * Time.deltaTime);

				}

				if (changeWalkingDirection == 50) {
						//if(atWall){
						changeWalkingDirection = 0;
						counter = Random.Range (0, go.Length);
						target = go [counter].transform;

				}
				for (int i =0; i >= houses.Length; i++) {
						if (Vector3.Distance (houses[i].transform.position, myTransform.position)>1) {
								Debug.Log ("in it");
						}
				}
				changeWalkingDirection++;
		}


}
