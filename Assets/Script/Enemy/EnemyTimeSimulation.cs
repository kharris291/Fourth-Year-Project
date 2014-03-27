/// <summary>
/// Enemy time simulation.cs
/// Author : Harris Kevin
/// </summary>
using UnityEngine;
using System.Collections;

public class EnemyTimeSimulation : MonoBehaviour {

	
	public int timeToAttack = 0;
	public int attackTime = 100;
	private Texture3D bgImage;
	private Texture3D fgImage;
	private float attackBarLength1;
	public float timeToAttack1 = 0f;
	private float[] attackBarLength;
	public bool check;
	
	// Use this for initialization
	GameObject constVar;
	StoredInformation stored;
	CharacterInformation playerInfo;
	
	void Awake(){
		//	playerInfo.Awake();
		
		constVar= GameObject.FindGameObjectWithTag("Constant");
		stored = constVar.GetComponent<StoredInformation>();

		//timeToAttack = Random.Range(0,80);
		
	}
	
	// Use this for initialization
	void Start () {
		GameObject[] enemObj = GameObject.FindGameObjectsWithTag("Enemy2");
		check = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName=="Battle Simulation"){
			GameObject[] enemObj = GameObject.FindGameObjectsWithTag("Enemy2");
			//for(int cnt = 0; cnt < enemObj.Length; cnt ++){
				//if(stored.actionBeingTaken ==false)
			AdjustTimeToFight(Time.deltaTime,0);
			//}
			if(enemObj.Length>=1)
				AdjustTimeToFight(Time.deltaTime,1);
			if(enemObj.Length>=2)
				AdjustTimeToFight(Time.deltaTime,2);
			
			if((this.check==true)&&(timeToAttack1 >=100)){
				EnemyAttack enem = new EnemyAttack();

			}
		}
	}
	
	public void AdjustTimeToFight (float adj, int counter)
	{
		timeToAttack1 += adj;
		
		if (timeToAttack < 0)
			timeToAttack = 0;
		
		if (timeToAttack1 > attackTime){
			timeToAttack1 = (float)attackTime;
			

			
		}
		
		if (attackTime < 1)
			attackTime = 1;
		
		timeToAttack = (int)timeToAttack1;
		
		if((timeToAttack1>99)&&((this.check!= true))){
			this.check =true;
			stored.EnemyBattlePosition = counter;
			//stored.actionBeingTaken= true;
		}
		else if(timeToAttack1<99){
			this.check =false;
		//	stored.actionBeingTaken = false;
		}
		
	}
}
