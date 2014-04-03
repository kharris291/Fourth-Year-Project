/// <summary>
/// Player attack.cs
/// Author: Harris Kevin
/// </summary>
using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	StoredInformation stored;
	public GameObject[] enemyObjects;
	public GameObject EnemyTarget;
	public bool attemptAttack;
	Transform characterTransform;
	public int fighterNumber;
	string attackType;
	GameObject initialiseParticles;
	public bool magicCheck = false;
	
	public GameObject[] particles =new GameObject[3];

	void Awake(){
		//constVar = GameObject.FindGameObjectsWithTag("Enemy2");
		//player = GameObject.FindGameObjectWithTag("Player2");
		characterTransform = transform;
		attemptAttack = false;
		
		initialiseParticles = new GameObject();
	}

	// Use this for initialization
	public void Start () {


		characterTransform = GameObject.FindGameObjectWithTag("Player2").transform;
	
		enemyObjects = GameObject.FindGameObjectsWithTag("Enemy2");
		//EnemyTarget = enemyObjects[0];

	}
	
	// Update is called once per frame
	void Update () {
		
	
		enemyObjects = GameObject.FindGameObjectsWithTag("Enemy2");

		if(enemyObjects.Length!=0){
			GameObject constVar= GameObject.FindGameObjectWithTag("Constant");
			StoredInformation stored = constVar.GetComponent<StoredInformation>();
			int counter = stored.BattlePosition;

			PlayerAttack playerAttack;
			GameObject[] obj = GameObject.FindGameObjectsWithTag("Player2");
			playerAttack = obj[counter].GetComponent<PlayerAttack>();
			
			enemyObjects = GameObject.FindGameObjectsWithTag("Enemy2");
			
			BattleAttackDisplay bat =  obj[counter].GetComponent<BattleAttackDisplay>();
			fighterNumber = bat.EnemyNumber;
			EnemyTarget = enemyObjects[fighterNumber];

			if(EnemyTarget==null){
				EnemyTarget = enemyObjects[fighterNumber+1];
			}

			if(characterTransform ==null ){
				characterTransform = transform;
			}

			if(attemptAttack){
				Quaternion rot;

				Vector3 lookRotate = EnemyTarget.transform.position - characterTransform.position;
				rot = Quaternion.Slerp (characterTransform.rotation, Quaternion.LookRotation (lookRotate), 3 * Time.deltaTime);
				characterTransform.rotation = rot;
				characterTransform = GameObject.FindGameObjectWithTag("Player2").transform;
				Vector3 charPosition = new Vector3 (characterTransform.forward.x * 8 * Time.deltaTime, 
				                                0, 
				                                characterTransform.forward.z * 8 * Time.deltaTime);
				characterTransform.position+= charPosition;
				animation.Play("run");

			}
			if(Vector3.Distance(characterTransform.position,EnemyTarget.transform.position)<=1){
				
				EnemyTarget = enemyObjects[fighterNumber];

				EnemyHealth attackEnemy = EnemyTarget.GetComponent<EnemyHealth>();
				attackType = bat.attackType;
				if(attackType == "Attack"){
					attackEnemy.AddjustCurrentHealth(stored._attackValue[0],"minus");
				}
				if(attackType == "FireAttack"){

					initialiseParticles = Instantiate(particles[0],EnemyTarget.transform.position, Quaternion.identity) as GameObject;
					initialiseParticles.name = "Fire";

					attackEnemy.AddjustCurrentHealth(stored._attackValue[1],"minus");
				}
				if(attackType == "IceAttack"){
					attackEnemy.AddjustCurrentHealth(stored._attackValue[2],"minus");
					initialiseParticles = Instantiate(particles[1],EnemyTarget.transform.position, Quaternion.identity) as GameObject;
					initialiseParticles.name = "Ice";
				}
				if(attackType == "LightningAttack"){
					initialiseParticles = Instantiate(particles[2],EnemyTarget.transform.position, Quaternion.identity) as GameObject;
					initialiseParticles.name = "Lightning";
					attackEnemy.AddjustCurrentHealth(stored._attackValue[3],"minus");

				}

				playerAttack.attemptAttack = false;

				GameObject[] atemptingChange = GameObject.FindGameObjectsWithTag("PlayerBattle");
				obj[counter].transform.position = atemptingChange[counter].transform.position;
				
				BattleTimeScript batTimeScript = obj[counter].GetComponent<BattleTimeScript>();
				batTimeScript.timeToAttack1=0;

				animation.Play("idle");

			}

		}
	}
	
	public void retrieveEnemies(int fight){
		fighterNumber = fight;
	}

	public void AttackEnemy(){
		characterTransform = GameObject.FindGameObjectWithTag("Player2").transform;
		PlayerAttack playerAttack;
		GameObject obj = GameObject.FindGameObjectWithTag("Player2");

		EnemyTarget = enemyObjects[fighterNumber];
		Transform enemyTransform = EnemyTarget.transform;
		playerAttack = obj.GetComponent<PlayerAttack>();

		if(Vector3.Distance(characterTransform.position,enemyTransform.position)>1){

			characterTransform.position+= new Vector3 (characterTransform.forward.x * 12 * Time.deltaTime,
			                                    0,
			                                    characterTransform.forward.z * 12 * Time.deltaTime);
			playerAttack.attemptAttack =true;

		}
	}

	public void FireAttackEnemy(){
		characterTransform = GameObject.FindGameObjectWithTag("Player2").transform;
		PlayerAttack playerAttack;
		GameObject obj = GameObject.FindGameObjectWithTag("Player2");
		
		EnemyTarget = enemyObjects[fighterNumber];

		playerAttack = obj.GetComponent<PlayerAttack>();

		if(Vector3.Distance(characterTransform.position,EnemyTarget.transform.position)>1){
			
			characterTransform.position+= new Vector3 (characterTransform.forward.x * 12 * Time.deltaTime,
			                                    0,
			                                    characterTransform.forward.z * 12 * Time.deltaTime);
			playerAttack.attemptAttack =true;
			
		}
	}

	public void IceAttackEnemy(){
		characterTransform = GameObject.FindGameObjectWithTag("Player2").transform;
		PlayerAttack playerAttack;
		GameObject obj = GameObject.FindGameObjectWithTag("Player2");
		
		EnemyTarget = enemyObjects[fighterNumber];

		playerAttack = obj.GetComponent<PlayerAttack>();

		if(Vector3.Distance(characterTransform.position,EnemyTarget.transform.position)>1){
			
			characterTransform.position+= new Vector3 (characterTransform.forward.x * 12 * Time.deltaTime, 
			                                    0,
			                                    characterTransform.forward.z * 12 * Time.deltaTime);
			playerAttack.attemptAttack =true;
			
		}
	}

	public void LightningAttackEnemy(){
		characterTransform = GameObject.FindGameObjectWithTag("Player2").transform;
		PlayerAttack playerAttack;
		GameObject obj = GameObject.FindGameObjectWithTag("Player2");
		
		EnemyTarget = enemyObjects[fighterNumber];
		
		playerAttack = obj.GetComponent<PlayerAttack>();

		if(Vector3.Distance(characterTransform.position,EnemyTarget.transform.position)>1){
			
			characterTransform.position+= new Vector3 (characterTransform.forward.x * 12 * Time.deltaTime,
			                                    0,
			                                    characterTransform.forward.z * 12 * Time.deltaTime);
			playerAttack.attemptAttack =true;
			
		}
	}
}
