/// <summary>
/// Enemy.cs
/// Author: Harris Kevin
/// </summary>
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject battleCommence;
	// Use this for initialization
	public int enemyNumb;
	void Start () {
		if(Application.loadedLevelName == "Battle Simulation"){
			enemyNumb = Random.Range(1,3);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Raises the trigger enter event.
	/// brings on about the battle simulations while telling the program the correct enemy to send into battle
	/// </summary>
	/// <param name="playerInRange">Player in range.</param>
	void OnTriggerEnter (Collider playerInRange)
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		GameObject constVar = GameObject.FindGameObjectWithTag("Constant");
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy2");
		float prev = 1000000;
		int num=0;
		for( int cnt =0; cnt < Enemies.Length; cnt ++){
			if(Vector3.Distance(player.transform.position,Enemies[cnt].transform.position)<prev){
				prev = Vector3.Distance(player.transform.position,Enemies[cnt].transform.position);
				num = cnt;
			}
		}
		int enemyfight=0;
		if(Enemies[num].name == "CaveWorm(Clone)"){
			enemyfight=0;
			
		}
		if(Enemies[num].name == "Monster2Prefab(Clone)"){
			enemyfight=1;
			
		}
		if(Enemies[num].name == "spider(Clone)"){
			enemyfight=2;
			
		}

		StoredInformation stored = constVar.GetComponent<StoredInformation>();
		if (playerInRange.gameObject.tag == "Player") {
			stored.AddEnemyToScene(enemyfight);
			stored.AddPlayerPositionAfterBattle(player.transform.position);
			stored.AddEnemyNumber(num);
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
