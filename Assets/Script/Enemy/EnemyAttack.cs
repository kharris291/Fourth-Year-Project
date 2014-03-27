/// <summary>
/// Enemy attack.cs
/// Author: Harris Kevin
/// </summary>
using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	StoredInformation stored;
	public GameObject[] enemyObjects;
	public GameObject EnemyTarget;
	public bool attempt;
	Transform myTransform;
	public int funTimes;
	int attackType;
	public int counter;
	
	void Awake(){
	
		myTransform = transform;
		attempt = false;
	}
	
	// Use this for initialization
	public void Start () {
		
		myTransform = GameObject.FindGameObjectWithTag("Enemy2").transform;
		
		enemyObjects = GameObject.FindGameObjectsWithTag("Player2");
	}
	
	// Update is called once per frame
	void Update () {
		
		enemyObjects = GameObject.FindGameObjectsWithTag("Player2");
		
		if(enemyObjects.Length!=0){
			GameObject constVar= GameObject.FindGameObjectWithTag("Constant");
			StoredInformation stored = constVar.GetComponent<StoredInformation>();
			counter = stored.EnemyBattlePosition;
			
			EnemyAttack enAttack;
			GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemy2");
			enAttack = obj[counter].GetComponent<EnemyAttack>();
			
			enemyObjects = GameObject.FindGameObjectsWithTag("Player2");
			

			funTimes = Random.Range(0,enemyObjects.Length);
			EnemyTarget = enemyObjects[funTimes];
			if(EnemyTarget==null){
				EnemyTarget = enemyObjects[funTimes+1];
			}
			if(myTransform ==null ){
				myTransform = transform;
			}
			
			EnemyTimeSimulation enemTimeScript = obj[counter].GetComponent<EnemyTimeSimulation>();
			if(enemTimeScript.timeToAttack1>99){
				this.attempt = true;

				if(attempt){
					Quaternion rot;
					
					rot = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (EnemyTarget.transform.position - myTransform.position), 6 * Time.deltaTime);
					myTransform.rotation = rot;
					myTransform = GameObject.FindGameObjectWithTag("Enemy2").transform;
					myTransform.position+= new Vector3 (myTransform.forward.x * 6 * Time.deltaTime, 
					                                    0, 
					                                    myTransform.forward.z * 6 * Time.deltaTime);
					if(obj[0].name == "CaveWorm(Clone)"){
						
						animation.Play("Walk");
						
						
					}else{
						animation.Play("walk");
						
					}
					
				}

				if((Vector3.Distance(myTransform.position,EnemyTarget.transform.position)<1)&&(attempt!=false)){
					Debug.Log((Vector3.Distance(myTransform.position,EnemyTarget.transform.position)));
					EnemyTarget = enemyObjects[funTimes];
					Transform lo = EnemyTarget.transform;
					if(obj[0].name == "CaveWorm(Clone)"){
						animation.Play("Attack");	
					}

					if(obj[0].name == "Monster2Prefab(Clone)"){
						animation.Play("bitchslap");
					}

					if(obj[0].name == "spider(Clone)"){
						animation.Play("attack1");
					}

					PlayerHealth attackEnemy = EnemyTarget.GetComponent<PlayerHealth>();

					attackType = Random.Range(0,5);
					if(attackType == 1){
						attackEnemy.AdjustCurrentHealth((int)(stored._attackValue[0]/stored._defenceValue[0]),funTimes);
					}
					if(attackType == 2){
						attackEnemy.AdjustCurrentHealth((int)(stored._attackValue[1]/stored._defenceValue[1]),funTimes);
					}
					if(attackType == 3){
						attackEnemy.AdjustCurrentHealth((int)(stored._attackValue[2]/stored._defenceValue[1]),funTimes);
					}
					if(attackType == 4){
						attackEnemy.AdjustCurrentHealth((int)(stored._attackValue[3]/stored._defenceValue[1]),funTimes);
					}
					if(Vector3.Distance(myTransform.position,EnemyTarget.transform.position)<=1)
						this.attempt = false;
					if(enAttack.attempt==false){
						GameObject[] atemptingChange = GameObject.FindGameObjectsWithTag("EnemyBattle");
						obj[counter].transform.position = atemptingChange[counter].transform.position;
						enemTimeScript.timeToAttack1=0;
						this.attempt=false;
						enemTimeScript.timeToAttack=0;
						if(obj[0].name == "CaveWorm(Clone)"){
							animation.Play("Idle");
						}
						if((obj[0].name == "spider(Clone)")||(obj[0].name == "Monster2Prefab(Clone)")){
							animation.Play("idle");
						}
					}
				}
			}
		}
	}
	
	public void retrieveEnemies(int fight){
		funTimes = fight;
	}
	
	public void AttackEnemy(){
		myTransform = GameObject.FindGameObjectWithTag("Enemy2").transform;
		EnemyAttack enAttack;
		GameObject obj = GameObject.FindGameObjectWithTag("Enemy2");
		
		EnemyTarget = enemyObjects[funTimes];
		Transform lo = EnemyTarget.transform;
		enAttack = obj.GetComponent<EnemyAttack>();
		
		if(Vector3.Distance(myTransform.position,lo.position)>1){
			
			myTransform.position+= new Vector3 (myTransform.forward.x * 12 * Time.deltaTime,
			                                    0,
			                                    myTransform.forward.z * 12 * Time.deltaTime);
			enAttack.attempt =true;
			
		}
	}
	
	public void FireAttackEnemy(){
		myTransform = GameObject.FindGameObjectWithTag("Enemy2").transform;
		EnemyAttack enAttack;
		GameObject obj = GameObject.FindGameObjectWithTag("Enemy2");
		
		EnemyTarget = enemyObjects[funTimes];
		
		enAttack = obj.GetComponent<EnemyAttack>();
		
		if(Vector3.Distance(myTransform.position,EnemyTarget.transform.position)>1){
			
			myTransform.position+= new Vector3 (myTransform.forward.x * 12 * Time.deltaTime,
			                                    0,
			                                    myTransform.forward.z * 12 * Time.deltaTime);
			enAttack.attempt =true;
			
		}
	}
	
	public void IceAttackEnemy(){
		myTransform = GameObject.FindGameObjectWithTag("Enemy2").transform;
		EnemyAttack enAttack;
		GameObject obj = GameObject.FindGameObjectWithTag("Enemy2");
		
		EnemyTarget = enemyObjects[funTimes];
		
		enAttack = obj.GetComponent<EnemyAttack>();

		if(Vector3.Distance(myTransform.position,EnemyTarget.transform.position)>1){
			
			myTransform.position+= new Vector3 (myTransform.forward.x * 12 * Time.deltaTime, 
			                                    0,
			                                    myTransform.forward.z * 12 * Time.deltaTime);
			enAttack.attempt =true;
			
		}
	}
	
	public void LightningAttackEnemy(){
		myTransform = GameObject.FindGameObjectWithTag("Enemy2").transform;
		EnemyAttack enAttack;
		GameObject obj = GameObject.FindGameObjectWithTag("Enemy2");
		
		EnemyTarget = enemyObjects[funTimes];
		
		enAttack = obj.GetComponent<EnemyAttack>();
		
		if(Vector3.Distance(myTransform.position,EnemyTarget.transform.position)>1){
			
			myTransform.position+= new Vector3 (myTransform.forward.x * 12 * Time.deltaTime,
			                                    0,
			                                    myTransform.forward.z * 12 * Time.deltaTime);
			enAttack.attempt =true;
			
		}
	}

}
