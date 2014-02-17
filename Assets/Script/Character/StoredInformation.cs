using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class StoredInformation : MonoBehaviour {

	public string characterName="";
	public string[] attributes;
	private string[] _vital;
	public int[] _vitalValue;
	private string[] _mana;
	public int[] _manaValue;
	private string[] _attack;
	public int[] _attackValue;
	private string[] _defence;
	public int[] _defenceValue;
	//public string[] Vitals,Mana,Attack,Defence;

	CharacterInformation info;
	// Use this for initialization
	void Start () {

		info = new CharacterInformation();
		info.Awake();
		init();

	}

	void init(){
		_vital = new string[info._vital.Length];
		_mana = new string[info._mana.Length];
		_attack = new string[info._attack.Length];
		_defence = new string[info._defence.Length];

		string[][] attributesList = new string[4][]{new string[3],
			new string[5],
			new string[4],
			new string[2]
		};

		for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++){
			_vital[i] = ((VitalName)i).ToString ();
			attributesList[0][i] = ((VitalName)i).ToString ();
		}
		for (int i = 0; i < Enum.GetValues(typeof(ManaName)).Length; i++){
			_mana[i] = ((ManaName)i).ToString ();
			attributesList[1][i] = ((ManaName)i).ToString ();
		}
		for (int i = 0; i < Enum.GetValues(typeof(AttackName)).Length; i++){
			_attack[i] = ((AttackName)i).ToString ();
			attributesList[2][i] = ((AttackName)i).ToString ();
		}
		for (int i = 0; i < Enum.GetValues(typeof(DefenceName)).Length; i++){
			_defence[i] = ((DefenceName)i).ToString ();
			attributesList[3][i] = ((DefenceName)i).ToString ();
		}
		//attributes = attributesList;


		Debug.Log (_vital.Length + "|" + _attack.Length + "|" + _defence.Length + "|" + _mana.Length);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void CharacterName(string chName){
		characterName=chName;
	}
}
