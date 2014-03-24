using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int curHealth = 100;
	GameObject[] player;
	GameObject constant;
	BattleAttackDisplay playerStored;
	StoredInformation constantStored;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddjustCurrentHealth (int adj, string type)
	{
		
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy2");

		constant = GameObject.FindGameObjectWithTag("Constant");
		constantStored = constant.GetComponent<StoredInformation>();

		player= GameObject.FindGameObjectsWithTag("Player2");
		playerStored = player[constantStored.playerNumber-1].GetComponent<BattleAttackDisplay>();
		
		if(type=="plus"){
			curHealth += adj;
		}
		if(type=="minus"){
			curHealth -= adj;
		}


		if (curHealth <= 0){
			//curHealth = 0;
			//Destroy(this);
			Destroy(Enemies[playerStored.EnemyNumber]);
		}
		
		if (curHealth > maxHealth)
			curHealth = maxHealth;

	}
}
