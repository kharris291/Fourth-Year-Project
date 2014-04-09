using UnityEngine;
using System.Collections;
/// <summary>
/// Magic attack.cs
/// is used to instaantiate the attacks for magic
/// retrieves information from the stored information class to attack enemies health points
/// Author: Kevin Harris
/// </summary>
public class MagicAttack : MonoBehaviour {

	StoredInformation stored;
	public GameObject[] enemyObjects;
	public GameObject EnemyTarget;
	public bool attempt;
	Transform myTransform;
	public int funTimes;
	string attackType;
	GameObject initialiseParticles;
	
	public GameObject[] particles =new GameObject[5];
	
	void Awake(){
		myTransform = transform;
		attempt = false;
		
		initialiseParticles = new GameObject();
	}
	
	// Use this for initialization
	public void Start () {
		
		
		myTransform = GameObject.FindGameObjectWithTag("Player2").transform;
		
		enemyObjects = GameObject.FindGameObjectsWithTag("Enemy2");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		enemyObjects = GameObject.FindGameObjectsWithTag("Enemy2");
		
		if(enemyObjects.Length!=0){
			GameObject constVar= GameObject.FindGameObjectWithTag("Constant");
			StoredInformation stored = constVar.GetComponent<StoredInformation>();
			int counter = stored.BattlePosition;
			
			MagicAttack pl;
			GameObject[] obj = GameObject.FindGameObjectsWithTag("Player2");
			pl = obj[counter].GetComponent<MagicAttack>();
			
			enemyObjects = GameObject.FindGameObjectsWithTag("Enemy2");
			
			BattleAttackDisplay battleAttack =  obj[counter].GetComponent<BattleAttackDisplay>();
			funTimes = battleAttack.EnemyNumber;
			EnemyTarget = enemyObjects[funTimes];
			
			if(EnemyTarget==null){
				EnemyTarget = enemyObjects[funTimes+1];
			}

			if(attempt){

				EnemyTarget = enemyObjects[funTimes];
				
				EnemyHealth attackEnemy = EnemyTarget.GetComponent<EnemyHealth>();
				attackType = battleAttack.attackType;
				if(attackType == "Fire"){

					initialiseParticles = Instantiate(particles[0],EnemyTarget.transform.position, Quaternion.identity) as GameObject;
					initialiseParticles.name = "Fire";
					
					attackEnemy.AddjustCurrentHealth(stored._manaValue[0],"minus");
				}
				if(attackType == "Wind"){
					initialiseParticles = Instantiate(particles[1],EnemyTarget.transform.position, Quaternion.identity) as GameObject;
					initialiseParticles.name = "Wind";
					attackEnemy.AddjustCurrentHealth(stored._manaValue[1],"minus");
					
				}
				if(attackType == "Ice"){
					
					initialiseParticles = Instantiate(particles[2],EnemyTarget.transform.position, Quaternion.identity) as GameObject;
					initialiseParticles.name = "Ice";
					
					attackEnemy.AddjustCurrentHealth(stored._manaValue[2],"minus");
				}
				if(attackType == "Water"){
					attackEnemy.AddjustCurrentHealth(stored._manaValue[3],"minus");
					initialiseParticles = Instantiate(particles[3],EnemyTarget.transform.position, Quaternion.identity) as GameObject;
					initialiseParticles.name = "Water";
				}
				if(attackType == "Lightning"){
					initialiseParticles = Instantiate(particles[4],EnemyTarget.transform.position, Quaternion.identity) as GameObject;
					initialiseParticles.name = "Lightning";
					attackEnemy.AddjustCurrentHealth(stored._manaValue[4],"minus");
					
				}

				
				pl.attempt = false;
				

				BattleTimeScript batTimeScript = obj[counter].GetComponent<BattleTimeScript>();
				batTimeScript.timeToAttack1=0;
				
				animation.Play("idle");
				
			}
			
		}
	}
	
	public void retrieveEnemies(int fight){
		funTimes = fight;
	}
	/// <summary>
	/// Fires the attack enemy.
	/// </summary>
	public void FireAttackEnemy(){
		myTransform = GameObject.FindGameObjectWithTag("Player2").transform;
		MagicAttack pl;
		GameObject obj = GameObject.FindGameObjectWithTag("Player2");
		
		EnemyTarget = enemyObjects[funTimes];
		
		pl = obj.GetComponent<MagicAttack>();
		
		if(EnemyTarget!=null){
			pl.attempt =true;		
		}
	}
	/// <summary>
	/// Ices the attack enemy.
	/// </summary>
	public void IceAttackEnemy(){
		myTransform = GameObject.FindGameObjectWithTag("Player2").transform;
		MagicAttack pl;
		GameObject obj = GameObject.FindGameObjectWithTag("Player2");
		
		EnemyTarget = enemyObjects[funTimes];
		
		pl = obj.GetComponent<MagicAttack>();
		
		if(EnemyTarget!=null){
			pl.attempt =true;		
		}
	}
	/// <summary>
	/// Lightnings the attack enemy.
	/// </summary>
	public void LightningAttackEnemy(){
		myTransform = GameObject.FindGameObjectWithTag("Player2").transform;
		MagicAttack pl;
		GameObject obj = GameObject.FindGameObjectWithTag("Player2");
		
		EnemyTarget = enemyObjects[funTimes];
		
		pl = obj.GetComponent<MagicAttack>();
		
		if(EnemyTarget!=null){
			pl.attempt =true;		
		}
	}
	/// <summary>
	/// Waters the attack enemy.
	/// </summary>
	public void WaterAttackEnemy(){
		myTransform = GameObject.FindGameObjectWithTag("Player2").transform;
		MagicAttack pl;
		GameObject obj = GameObject.FindGameObjectWithTag("Player2");
		
		EnemyTarget = enemyObjects[funTimes];
		
		pl = obj.GetComponent<MagicAttack>();
		
		if(EnemyTarget!=null){
			pl.attempt =true;		
		}
	}

}
