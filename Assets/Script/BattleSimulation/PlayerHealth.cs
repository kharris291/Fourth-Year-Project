/// <summary>
/// Player health.cs
/// Author: Harris Kevin
/// </summary>
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
	int starting;
	
	GameObject constVar;
	StoredInformation stored;
	CharacterInformation playerInfo;

	void Awake(){
		constVar= GameObject.FindGameObjectWithTag("Constant");
		stored = constVar.GetComponent<StoredInformation>();
		curHealth = stored._vitalValue[0];
		maxHealth = stored._vitalValue[0];
		healthBarLength = new float[stored.playerNumber];
		for(int cnt =0; cnt > stored.playerNumber; cnt++){
			healthBarLength[cnt] = (Screen.width / 4) * (curHealth / (float)maxHealth);
		}
		healthBarLength1 = (Screen.width / 4);
	}

	void Start ()
	{   

	}
	
	// Update is called once per frame
	void Update ()
	{
		if(stored.playerNumber>=1){
			starting = 60;
		}
		if(stored.playerNumber>=2){
			starting = 90;
		}
		if(stored.playerNumber>=3){
			starting = 120;
		}
		AdjustCurrentHealth (0,0);
	}

	public GUIStyle textstyle;
	public void OnGUI ()
	{
		GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy2");
		if(enemyObjects.Length!=0){
			textstyle.alignment = TextAnchor.MiddleLeft;
			
			if(stored.playerNumber>=1){
				GUI.Label(new Rect(Screen.width/3-70,Screen.height-30,healthBarLength[0],20),stored.characterName,textstyle);
				GUI.Box(new Rect(Screen.width/2+200,Screen.height-30,healthBarLength[0],20),"");
				GUI.Box(new Rect(Screen.width/2+200,Screen.height-30,healthBarLength1,20),curHealth+"/"+maxHealth);
			}
			if(stored.playerNumber>=2){
				GUI.Label(new Rect(Screen.width/3-70,Screen.height-60,healthBarLength[1],20),stored.characterName,textstyle);
				GUI.Box(new Rect(Screen.width/2+200,Screen.height-60,healthBarLength[1],20),"");
				GUI.Box(new Rect(Screen.width/2+200,Screen.height-60,healthBarLength1,20),curHealth+"/"+maxHealth);
			}
			if(stored.playerNumber>=3){
				GUI.Label(new Rect(Screen.width/3-70,Screen.height-90,healthBarLength[2],20),stored.characterName,textstyle);
				GUI.Box(new Rect(Screen.width/2+200,Screen.height-90,healthBarLength[2],20),"");
				GUI.Box(new Rect(Screen.width/2+200,Screen.height-90,healthBarLength1,20),curHealth+"/"+maxHealth);
			}
			
			GUI.Label(new Rect(Screen.width/3-70,Screen.height-starting,healthBarLength[0],20),"Name",textstyle);
			GUI.Label(new Rect(Screen.width/2-50,Screen.height-starting,healthBarLength[0],20),"Time Till Attack",textstyle);
			GUI.Label(new Rect(Screen.width/2+200,Screen.height-starting,healthBarLength[0],20),"Health",textstyle);
		}
		
	}
	
	public void AdjustCurrentHealth (int adj, int counter)
	{		
		curHealth -= adj;

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