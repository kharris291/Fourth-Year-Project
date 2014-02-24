using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class StoredInformation : MonoBehaviour {

	public string characterName;
	public string[] _primaryAttribute;
	public int[] _primaryAttributeValues;
	public string[] _vital;
	public int[] _vitalValue;
	public string[] _mana;
	public int[] _manaValue;
	public string[] _attack;
	public int[] _attackValue;
	public string[] _defence;
	public int[] _defenceValue;
	public Vector3 positionOnScreen;
	GameObject playerPos;

	PlayerInformation info;
	CharacterGen chars;
	// Use this for initialization
	public void Start () {
		info = new PlayerInformation();
		info.Awake();
		chars = new CharacterGen();
		
		for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
			info.GetPrimaryAttribute (i).BaseValue = chars.STARTING_VALUE;
		}	

		_primaryAttribute = new string[info._primaryAttribute.Length];
		_primaryAttributeValues=new int[info._primaryAttribute.Length];
		_vital = new string[info._vital.Length];
		_vitalValue=new int[info._vital.Length];
		_mana = new string[info._mana.Length];
		_manaValue=new int[info._mana.Length];
		_attack = new string[info._attack.Length];
		_attackValue = new int[info._attack.Length];
		_defence = new string[info._defence.Length];
		_defenceValue = new int[info._defence.Length];

		initiliseConstantVariables();
		playerPos = GameObject.FindGameObjectWithTag("Player");
		if(playerPos!=null)
			positionOnScreen= playerPos.transform.position;
	}

	public void initiliseConstantVariables(){


		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++){
			_primaryAttribute [cnt] = ((AttributeName)cnt).ToString ();
			_primaryAttributeValues[cnt] = info.GetPrimaryAttribute(cnt).AdjustedBaseValue;
		}

		for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++){
			_vital[i] = ((VitalName)i).ToString ();
			_vitalValue[i] = info.GetVitals(i).AdjustedBaseValue;
		}

		for (int i = 0; i < Enum.GetValues(typeof(ManaName)).Length; i++){
			_mana[i] = ((ManaName)i).ToString ();
			_manaValue[i] = info.GetMana(i).AdjustedBaseValue;
		}

		for (int i = 0; i < Enum.GetValues(typeof(AttackName)).Length; i++){
			_attack[i] = ((AttackName)i).ToString ();
			_attackValue[i] = info.GetAttack(i).AdjustedBaseValue;
		}

		for (int i = 0; i < Enum.GetValues(typeof(DefenceName)).Length; i++){
			_defence[i] = ((DefenceName)i).ToString ();
			_defenceValue[i] = info.GetDefence(i).AdjustedBaseValue;
		}
		positionOnScreen.x=PlayerPrefs.GetFloat("Position - x");
		positionOnScreen.y=PlayerPrefs.GetFloat("Position - y");
		positionOnScreen.z=PlayerPrefs.GetFloat("Position - z");
		
		info.StatUpdate();
		_vitalValue=info.VitalUpdate();
		_attackValue=info.AttackUpdate();
		_defenceValue=info.DefenceUpdate();
		_manaValue=info.ManaUpdate();
		characterName = PlayerPrefs.GetString ("Player Name");
	}
	
	// Update is called once per frame
	void Update () {
		/*Debug.Log(_primaryAttribute);
		Debug.Log(_primaryAttributeValues);
		Debug.Log(_vital);
		Debug.Log(_vitalValue);
		Debug.Log(_mana);
		Debug.Log(_manaValue);
		Debug.Log(_attack);
		Debug.Log(_attackValue);
		Debug.Log(_defence);
		Debug.Log(_defenceValue);*/
	}

	public void CharacterName(string chName){
		characterName=chName;
		
		initiliseConstantVariables();
	}

	public void SaveData(){
		GameObject playerPrefab = GameObject.FindGameObjectWithTag("Player");
	
		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		
		StoredInformation st = objGame.GetComponent<StoredInformation>();
		
		PlayerPrefs.SetString ("Player Name",st.characterName);

		//Debug.Log(playerPrefab.transform.position);
		st.positionOnScreen = playerPrefab.transform.position;

		//PlayerInformation player = playerPrefab.GetComponent<PlayerInformation>();
		PlayerPrefs.SetString("Player Name", st.characterName);
		PlayerPrefs.SetFloat("Position - x",st.positionOnScreen.x);
		PlayerPrefs.SetFloat("Position - y",st.positionOnScreen.y);
		PlayerPrefs.SetFloat("Position - z",st.positionOnScreen.z);

		//characterName = PlayerPrefs.GetString ("Player Name", "Name Me");

		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			//playerClass.GetPrimaryAttribute (cnt).BaseValue = PlayerPrefs.GetInt (((AttributeName)cnt).ToString () + " - Base Value");
//			Debug.Log(_primaryAttribute[cnt]);
			PlayerPrefs.SetString("Attribute Name - " + cnt, st._primaryAttribute[cnt]);
			PlayerPrefs.SetInt (((AttributeName)cnt).ToString () + " - Base Value - " + cnt, st._primaryAttributeValues[cnt] );
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			//playerClass.GetVitals (cnt).BaseValue = PlayerPrefs.GetInt (((VitalName)cnt).ToString () + " - Base Value");
			PlayerPrefs.SetString("Vital Name - " + cnt, st._vital[cnt]);
			PlayerPrefs.SetInt (((VitalName)cnt).ToString () + " - Base Value - " + cnt, st._vitalValue[cnt]);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttackName)).Length; cnt++) {
			//playerClass.GetAttack (cnt).BaseValue = PlayerPrefs.GetInt (((AttackName)cnt).ToString () + " - Base Value",0);
			PlayerPrefs.SetString("Attack Name - " + cnt, st._attack[cnt]);
			PlayerPrefs.SetInt (((AttackName)cnt).ToString () + " - Base Value - " + cnt, st._attackValue[cnt]);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(ManaName)).Length; cnt++) {
			//playerClass.GetAttack (cnt).BaseValue = PlayerPrefs.GetInt (((AttackName)cnt).ToString () + " - Base Value",0);
			PlayerPrefs.SetString("Mana Name - " + cnt, st._mana[cnt]);
			PlayerPrefs.SetInt (((ManaName)cnt).ToString () + " - Base Value - " + cnt, st._manaValue[cnt]);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(DefenceName)).Length; cnt++) {
			//playerClass.GetAttack (cnt).BaseValue = PlayerPrefs.GetInt (((AttackName)cnt).ToString () + " - Base Value",0);
			PlayerPrefs.SetString("Defence Name - " + cnt, st._defence[cnt]);
			PlayerPrefs.SetInt (((DefenceName)cnt).ToString () + " - Base Value - " + cnt, st._defenceValue[cnt]);
		}

		PlayerPrefs.Save();
	}

	public void LoadData(){

		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");

		StoredInformation st = objGame.GetComponent<StoredInformation>();
		
		st.characterName = PlayerPrefs.GetString ("Player Name");

		//characterName = PlayerPrefs.GetString("Player Name", "name");
		st.positionOnScreen.x=PlayerPrefs.GetFloat("Position - x");
		st.positionOnScreen.y=PlayerPrefs.GetFloat("Position - y");
		st.positionOnScreen.z=PlayerPrefs.GetFloat("Position - z");
		if(Application.loadedLevelName!="Game"){
			PlayerPosition pl;

			pl = new PlayerPosition();
			pl.Awake();
			pl.SetPosition(st.positionOnScreen);
		}
		//playerPos.transform.position = pos;
		//PlayerInformation playerClass = player.GetComponent<PlayerInformation> ();

		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			st._primaryAttribute[cnt]=PlayerPrefs.GetString("Attribute Name - " + cnt);
			st._primaryAttributeValues[cnt] = PlayerPrefs.GetInt (((AttributeName)cnt).ToString () + " - Base Value - " + cnt);
			
			if(PlayerPrefs.HasKey("Strength - Base Value - 0")){
				Debug.Log("it's here");	
			}
		}

		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			//playerClass.GetVitals (cnt).BaseValue = PlayerPrefs.GetInt (((VitalName)cnt).ToString () + " - Base Value");

			//_vital[cnt] = ((VitalName)cnt).ToString ();
			st._vital[cnt]=PlayerPrefs.GetString("Vital Name - " + cnt);
			st._vitalValue[cnt] = PlayerPrefs.GetInt (((VitalName)cnt).ToString () + " - Base Value - " + cnt);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttackName)).Length; cnt++) {
			//playerClass.GetAttack (cnt).BaseValue = PlayerPrefs.GetInt (((AttackName)cnt).ToString () + " - Base Value",0);
			//_attack[cnt]= ((AttackName)cnt).ToString ();
			st._attack[cnt]=PlayerPrefs.GetString("Attack Name - " + cnt);
			st._attackValue[cnt] = PlayerPrefs.GetInt (((AttackName)cnt).ToString () + " - Base Value - " + cnt);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(ManaName)).Length; cnt++) {
			//playerClass.GetAttack (cnt).BaseValue = PlayerPrefs.GetInt (((AttackName)cnt).ToString () + " - Base Value",0);
			st._mana[cnt]=PlayerPrefs.GetString("Mana Name - " + cnt);
				//((ManaName)cnt).ToString ();
			st._manaValue[cnt] = PlayerPrefs.GetInt (((ManaName)cnt).ToString () + " - Base Value - " + cnt,0);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(DefenceName)).Length; cnt++) {
			//playerClass.GetAttack (cnt).BaseValue = PlayerPrefs.GetInt (((AttackName)cnt).ToString () + " - Base Value",0);
			st._defence[cnt]= PlayerPrefs.GetString("Defence Name - " + cnt);
				//((DefenceName)cnt).ToString ();
			st._defenceValue[cnt] = PlayerPrefs.GetInt (((DefenceName)cnt).ToString () + " - Base Value - " + cnt);
		}

	}
}
