using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour
{
	public int maxHealth = 100;
	public int curHealth = 100;
	private Texture3D bgImage;
	private Texture3D fgImage;
	private float healthBarLength1;
	private float[] healthBarLength;
	
	GameObject constVar;
	StoredInformation stored;
	CharacterInformation playerInfo;
	// Use this for initialization

	void Awake(){
	//	playerInfo.Awake();
		
		constVar= GameObject.FindGameObjectWithTag("Constant");
		stored = constVar.GetComponent<StoredInformation>();
		healthBarLength = new float[stored.playerNumber];
		for(int cnt =0; cnt > stored.playerNumber; cnt++){
			healthBarLength[cnt] = (Screen.width / 4) * (curHealth / (float)maxHealth);

		}
		healthBarLength1 = (Screen.width / 4);
	}

	void Start ()
	{   
		//Debug.Log(playerInfo.GetVitals(0));

	}
	
	// Update is called once per frame
	void Update ()
	{
		AdjustCurrentHealth (0,0);
	}
	public GUIStyle textstyle;
	public void OnGUI ()
	{
		
		if(stored.playerNumber>=1){
			GUI.Label(new Rect(Screen.width/3-70,Screen.height-70,healthBarLength[0],20),stored.characterName,textstyle);
			GUI.Box(new Rect(Screen.width/2+200,Screen.height-70,healthBarLength[0],20),"");
			GUI.Box(new Rect(Screen.width/2+200,Screen.height-70,healthBarLength1,20),curHealth+"/"+maxHealth);
		}
		if(stored.playerNumber>=2){
			GUI.Label(new Rect(Screen.width/3-70,Screen.height-100,healthBarLength[1],20),stored.characterName,textstyle);
			GUI.Box(new Rect(Screen.width/2+200,Screen.height-100,healthBarLength[1],20),"");
			GUI.Box(new Rect(Screen.width/2+200,Screen.height-100,healthBarLength1,20),curHealth+"/"+maxHealth);

		}
		if(stored.playerNumber>=3){
			GUI.Label(new Rect(Screen.width/3-70,Screen.height-130,healthBarLength[2],20),stored.characterName,textstyle);
			GUI.Box(new Rect(Screen.width/2+200,Screen.height-130,healthBarLength[2],20),"");
			GUI.Box(new Rect(Screen.width/2+200,Screen.height-130,healthBarLength1,20),curHealth+"/"+maxHealth);

		}


	}
	
	public void AdjustCurrentHealth (int adj, int counter)
	{
		
		curHealth += adj;
		
		if (curHealth < 0)
			curHealth = 0;
		
		if (curHealth > maxHealth)
			curHealth = maxHealth;
		
		if (maxHealth < 1)
			maxHealth = 1;
		
		healthBarLength[counter] = (Screen.width / 4) * (curHealth / (float)maxHealth);
		healthBarLength1 = (Screen.width / 4);
	}
}