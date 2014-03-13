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

	// Use this for initialization
	GameObject constVar;
	StoredInformation stored;
	CharacterInformation playerInfo;
	// Use this for initialization
	
	void Awake(){
		//	playerInfo.Awake();
		
		constVar= GameObject.FindGameObjectWithTag("Constant");
		stored = constVar.GetComponent<StoredInformation>();
		attackBarLength = new float[stored.playerNumber];

		//timeToAttack = Random.Range(0,80);
		for(int cnt =0; cnt > stored.playerNumber; cnt++){
			attackBarLength[cnt] = (Screen.width / 4) * (timeToAttack / (float)attackTime);
			
		}
		attackBarLength1 = (Screen.width / 4);
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		AdjustTimeToFight(Time.deltaTime*3,0);
		/*if(stored.playerNumber>=2){
			AdjustTimeToFight(Time.deltaTime*3,1);
		}
		if(stored.playerNumber >=3){
			AdjustTimeToFight(Time.deltaTime*3,2);
		}*/

	}

	public void OnGUI ()
	{
//		int len = attackBarLength * (attackTime / (float)timeToAttack);

		if(stored.playerNumber>=1){
			GUI.Box(new Rect(Screen.width/2-50,Screen.height-70,attackBarLength1,20),"");
			GUI.Box(new Rect(Screen.width/2-50,Screen.height-70,attackBarLength[0],20),"");
		}
		if(stored.playerNumber>=2){
			GUI.Box(new Rect(Screen.width/2-50,Screen.height-100,attackBarLength1,20),"");
			GUI.Box(new Rect(Screen.width/2-50,Screen.height-100,attackBarLength[1],20),"");
		}
		if(stored.playerNumber>=3){
			GUI.Box(new Rect(Screen.width/2-50,Screen.height-130,attackBarLength1,20),"");
			GUI.Box(new Rect(Screen.width/2-50,Screen.height-130,attackBarLength[2],20),attackTime+"/"+timeToAttack);
		}
	}

	public void AdjustTimeToFight (float adj, int counter)
	{
		timeToAttack1 += adj;
		
		if (timeToAttack < 0)
			timeToAttack = 0;
		
		if (timeToAttack1 > attackTime)
			timeToAttack1 = (float)attackTime;
		
		//if (timeToAttack1 < timeToAttack)
		//	timeToAttack1 = (float)timeToAttack;

		if (attackTime < 1)
			attackTime = 1;

		timeToAttack = (int)timeToAttack1;
		attackBarLength[counter] = (Screen.width / 4) * (timeToAttack / (float)attackTime);
		attackBarLength1 = (Screen.width / 4);
	}
}
