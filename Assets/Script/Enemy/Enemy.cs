using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject battleCommence;
	// Use this for initialization
	void Start () {
		if(Application.loadedLevelName == "Battle Simulation"){

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter (Collider playerInRange)
	{
		
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (playerInRange.gameObject.tag == "Player") {
			Application.LoadLevel("Battle Simulation");
			Destroy(player);
		}
	}
	
	void OnTriggerExit (Collider playerNotInRange)
	{
		if (playerNotInRange.gameObject.tag == "Player") {

		}
	}


}
