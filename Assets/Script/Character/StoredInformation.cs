using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class StoredInformation : MonoBehaviour {

	public string characterName;
	private string[] _primaryAttribute;
	private int[] _primaryAttributeValues;
	private string[] _vital;
	private int[] _vitalValue;
	private string[] _mana;
	private int[] _manaValue;
	private string[] _attack;
	private int[] _attackValue;
	private string[] _defence;
	private int[] _defenceValue;
	private MoneySystem money;
	public string[] items, itemId;
	public int moneyTotal;
	public Vector3 positionOnScreen;
	GameObject playerPos;
	int itemAmount;
	public int enemyTypeNumber,playerNumber;
	//string[] tempItems,tempItemsId;
	private ArrayList itemsNameArray,itemsContentArray;

	PlayerInformation info;
	CharacterGen chars;
	// Use this for initialization
	public void Start () {
		info = new PlayerInformation();
		info.Awake();
		chars = new CharacterGen();
		enemyTypeNumber =0;
		playerNumber =1;
		for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
			info.GetPrimaryAttribute (i).BaseValue = chars.STARTING_VALUE;
		}	
		characterName = String.Empty;
		itemAmount = 0;
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
		money = new MoneySystem();
		itemsNameArray = new ArrayList();
		itemsContentArray = new ArrayList();

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

		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		StoredInformation st = objGame.GetComponent<StoredInformation>();

		if(Application.loadedLevelName=="NewGame"){
			moneyTotal = money.StarterMoney();
			st.moneyTotal = moneyTotal;
		}
		else if((PlayerPrefs.GetInt("Money")!= null)||(PlayerPrefs.GetInt("Money")!= 0)){
			moneyTotal = PlayerPrefs.GetInt("Money");
			st.moneyTotal = moneyTotal;
		}
		else if(moneyTotal==0){
			moneyTotal = money.StarterMoney();
			st.moneyTotal = moneyTotal;
		}
		else{
			moneyTotal = PlayerPrefs.GetInt("Money");
			st.moneyTotal = moneyTotal;

		}
		info.StatUpdate();
		_vitalValue=info.VitalUpdate();
		_attackValue=info.AttackUpdate();
		_defenceValue=info.DefenceUpdate();
		_manaValue=info.ManaUpdate();
		if(characterName==String.Empty){
			characterName = PlayerPrefs.GetString ("Player Name");
			st.characterName = PlayerPrefs.GetString ("Player Name");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void CharacterName(string chName){
		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		
		StoredInformation st = objGame.GetComponent<StoredInformation>();
		characterName=chName;
		st.characterName=chName;

		initiliseConstantVariables();
	}

	public void addItems(string chName, string itemPower){
		
		
		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		
		StoredInformation stored = objGame.GetComponent<StoredInformation>();

		if(itemAmount ==0){
			itemAmount=1;
		}else{
			itemAmount++;
		}
		
		stored.itemsNameArray.Add(chName);
		stored.itemsContentArray.Add(itemPower);
		stored.items = new string[stored.itemsNameArray.Count];
		stored.itemsNameArray.CopyTo(stored.items);
		stored.itemId = new string[stored.itemsContentArray.Count];
		stored.itemsContentArray.CopyTo(stored.itemId);
	}

	public void AddEnemyToScene(int fighting){
		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		
		StoredInformation st = objGame.GetComponent<StoredInformation>();

		st.enemyTypeNumber = fighting;
	}

	public void AddPlayerToScene(int fighting){
		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		
		StoredInformation st = objGame.GetComponent<StoredInformation>();
		
		st.playerNumber = fighting;
	}

	public void SaveData(){
		GameObject playerPrefab = GameObject.FindGameObjectWithTag("Player");
	
		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		
		StoredInformation st = objGame.GetComponent<StoredInformation>();
		
		PlayerPrefs.SetString ("Player Name",st.characterName);

		st.positionOnScreen = playerPrefab.transform.position;

		PlayerPrefs.SetInt("Money",st.moneyTotal);

		PlayerPrefs.SetFloat("Position - x",st.positionOnScreen.x);
		PlayerPrefs.SetFloat("Position - y",st.positionOnScreen.y);
		PlayerPrefs.SetFloat("Position - z",st.positionOnScreen.z);

		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			PlayerPrefs.SetString("Attribute Name - " + cnt, st._primaryAttribute[cnt]);
			PlayerPrefs.SetInt (((AttributeName)cnt).ToString () + " - Base Value - " + cnt, st._primaryAttributeValues[cnt] );
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			PlayerPrefs.SetString("Vital Name - " + cnt, st._vital[cnt]);
			PlayerPrefs.SetInt (((VitalName)cnt).ToString () + " - Base Value - " + cnt, st._vitalValue[cnt]);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttackName)).Length; cnt++) {
			PlayerPrefs.SetString("Attack Name - " + cnt, st._attack[cnt]);
			PlayerPrefs.SetInt (((AttackName)cnt).ToString () + " - Base Value - " + cnt, st._attackValue[cnt]);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(ManaName)).Length; cnt++) {
			PlayerPrefs.SetString("Mana Name - " + cnt, st._mana[cnt]);
			PlayerPrefs.SetInt (((ManaName)cnt).ToString () + " - Base Value - " + cnt, st._manaValue[cnt]);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(DefenceName)).Length; cnt++) {
			PlayerPrefs.SetString("Defence Name - " + cnt, st._defence[cnt]);
			PlayerPrefs.SetInt (((DefenceName)cnt).ToString () + " - Base Value - " + cnt, st._defenceValue[cnt]);
		}

		PlayerPrefs.Save();
	}

	public void LoadData(){

		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");

		StoredInformation st = objGame.GetComponent<StoredInformation>();

		characterName = PlayerPrefs.GetString ("Player Name");
		st.characterName = PlayerPrefs.GetString ("Player Name");

		moneyTotal = PlayerPrefs.GetInt("Money");

		st.positionOnScreen.x=PlayerPrefs.GetFloat("Position - x");
		st.positionOnScreen.y=PlayerPrefs.GetFloat("Position - y");
		st.positionOnScreen.z=PlayerPrefs.GetFloat("Position - z");
		if(Application.loadedLevelName!="Game"){
			PlayerPosition pl;

			pl = new PlayerPosition();
			pl.Awake();
			pl.SetPosition(st.positionOnScreen);
		}

		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			st._primaryAttribute[cnt]=PlayerPrefs.GetString("Attribute Name - " + cnt);
			st._primaryAttributeValues[cnt] = PlayerPrefs.GetInt (((AttributeName)cnt).ToString () + " - Base Value - " + cnt);

		}

		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			st._vital[cnt]=PlayerPrefs.GetString("Vital Name - " + cnt);
			st._vitalValue[cnt] = PlayerPrefs.GetInt (((VitalName)cnt).ToString () + " - Base Value - " + cnt);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttackName)).Length; cnt++) {
			st._attack[cnt]=PlayerPrefs.GetString("Attack Name - " + cnt);
			st._attackValue[cnt] = PlayerPrefs.GetInt (((AttackName)cnt).ToString () + " - Base Value - " + cnt);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(ManaName)).Length; cnt++) {
			st._mana[cnt]=PlayerPrefs.GetString("Mana Name - " + cnt);
			st._manaValue[cnt] = PlayerPrefs.GetInt (((ManaName)cnt).ToString () + " - Base Value - " + cnt,0);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(DefenceName)).Length; cnt++) {
			st._defence[cnt]= PlayerPrefs.GetString("Defence Name - " + cnt);
			st._defenceValue[cnt] = PlayerPrefs.GetInt (((DefenceName)cnt).ToString () + " - Base Value - " + cnt);
		}

	}
}

