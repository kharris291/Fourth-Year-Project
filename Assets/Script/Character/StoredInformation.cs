using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class StoredInformation : MonoBehaviour {

	public string characterName="";
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

	PlayerInformation info;
	CharacterGen chars;
	// Use this for initialization
	void Start () {

		info = new PlayerInformation();
		info.Awake();
		chars = new CharacterGen();
		
		for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
			info.GetPrimaryAttribute (i).BaseValue = chars.STARTING_VALUE;
		}	
		
		info.StatUpdate();

	}

	void initiliseConstantVariables(){
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
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void CharacterName(string chName){
		characterName=chName;
		
		initiliseConstantVariables();
	}
}
