/// <summary>
/// Enemy health.cs
/// Author: Harris Kevin
/// </summary>
using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float maxHealth = 100,curHealth = 100;
	GameObject[] player;
	GameObject constant;
	BattleAttackDisplay playerStored;
	StoredInformation constantStored;
	// Use this for initialization
	void Start () {
		
		constant = GameObject.FindGameObjectWithTag("Constant");
		constantStored = constant.GetComponent<StoredInformation>();

		maxHealth = constantStored._vitalValue[0]/1.5f;
		curHealth = constantStored._vitalValue[0]/1.5f;
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
		
		/// <summary>
		/// Player information.cs
		/// Title: Hack & Slash RPG - A Unity3D Game Engine Tutorial | BurgZerg Arcade. [Online].;
		/// Author: Laliberte P. 
		/// Date: 2013 October 24. 
		/// Available from: http://www.burgzergarcade.com/hack-slash-rpg-unity3d-game-engine-tutorial
		/// inspired idea from tutorial but modified for my own use
		/// </summary>	
		if(type=="plus"){
			curHealth += adj;
		}
		if(type=="minus"){
			curHealth -= adj;
		}

		if (curHealth <= 0){
			Destroy(Enemies[playerStored.EnemyNumber]);
		}
		if (curHealth > maxHealth)
			curHealth = maxHealth;
	}
}
