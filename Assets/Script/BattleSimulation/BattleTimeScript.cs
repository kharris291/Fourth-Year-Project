/// <summary>
/// Battle time script.cs
/// Author: Harris Kevin
/// </summary>
using UnityEngine;
using System.Collections;

public class BattleTimeScript : MonoBehaviour {

	public int timeToAttack = 0;
	public int attackTime = 100;
	private Texture3D bgImage;
	private Texture3D fgImage;
	private float attackBarLength1;
	public float timeToAttack1 = 0f;
	private float[] attackBarLength;
	public bool[] check;

	// Use this for initialization
	GameObject constVar;
	StoredInformation stored;
	CharacterInformation playerInfo;
	
	void Awake(){
		//	playerInfo.Awake();
		
		constVar= GameObject.FindGameObjectWithTag("Constant");
		stored = constVar.GetComponent<StoredInformation>();
		attackBarLength = new float[stored.playerNumber];
		check = new bool[stored.playerNumber];
		//timeToAttack = Random.Range(0,80);
		for(int cnt =0; cnt > stored.playerNumber; cnt++){
			attackBarLength[cnt] = (Screen.width / 6) * (timeToAttack / (float)attackTime);
			
		}
		attackBarLength1 = (Screen.width / 6);
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//if(stored.actionBeingTaken==false){
			AdjustTimeToFight(Time.deltaTime*10,0);
		/*	if(stored.playerNumber>=2){
				AdjustTimeToFight(Time.deltaTime*3,1);
			}
			if(stored.playerNumber >=3){
				AdjustTimeToFight(Time.deltaTime*3,2);
			}
		}*/
	}

	public void OnGUI ()
	{
//		int len = attackBarLength * (attackTime / (float)timeToAttack);
		GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy2");
		if(enemyObjects.Length!=0){
			if(stored.playerNumber>=1){
				GUI.Box(new Rect(Screen.width/2-50,Screen.height-30,attackBarLength1,20),"");
				GUI.Box(new Rect(Screen.width/2-50,Screen.height-30,attackBarLength[0],20),"");
			}
			if(stored.playerNumber>=2){
				GUI.Box(new Rect(Screen.width/2-50,Screen.height-60,attackBarLength1,20),"");
				GUI.Box(new Rect(Screen.width/2-50,Screen.height-60,attackBarLength[1],20),"");
			}
			if(stored.playerNumber>=3){
				GUI.Box(new Rect(Screen.width/2-50,Screen.height-90,attackBarLength1,20),"");
				GUI.Box(new Rect(Screen.width/2-50,Screen.height-90,attackBarLength[2],20),"");
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
			stored.BattlePosition = counter;
		}

		//if (timeToAttack1 < timeToAttack)
		//	timeToAttack1 = (float)timeToAttack;

		if (attackTime < 1)
			attackTime = 1;

		timeToAttack = (int)timeToAttack1;
		attackBarLength[counter] = (Screen.width / 6) * (timeToAttack / (float)attackTime);
		if((timeToAttack1>99)&&((check[counter]!= true))){
			check[counter] =true;
			//stored.actionBeingTaken=true;
		}
		else if(timeToAttack1<99){
			check[counter] =false;
			//stored.actionBeingTaken = false;
		}
		attackBarLength1 = (Screen.width / 6);
	}
}
