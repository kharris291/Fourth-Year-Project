/// <summary>
/// Stored information.cs
/// Author: Harris Kevin
/// </summary>
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
	public MoneySystem money;
	public string[] items, itemId;
	public int moneyTotal;
	public Vector3 positionOnScreen;
	GameObject playerPos;
	int itemAmount;
	public int enemyTypeNumber,playerNumber;
	private ArrayList itemsNameArray,itemsContentArray;
	public int enemyRemoval;
	public int BattlePosition,EnemyBattlePosition;
	public int experience,level,nextLevel;
	public float nextLevelvalue;
	Vector3 position = new Vector3();
	public bool actionBeingTaken = false;
	PlayerInformation info;
	CharacterGen chars;

	public bool checkloop =false;
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
		moneyTotal=0;
		money = new MoneySystem();
		itemsNameArray = new ArrayList();
		itemsContentArray = new ArrayList();
		experience =100;
		
		nextLevelvalue = experience*1.2f;
		nextLevel = (int)(experience*1.2f);
		level =1;
		initiliseConstantVariables();

		playerPos = GameObject.FindGameObjectWithTag("Player");
		if(playerPos!=null)
			positionOnScreen= playerPos.transform.position;


		if(PlayerPrefs.GetString ("Player Name")!= ""){
			LoadData();
		}
	}
	/// <summary>
	/// Initilises the variables.
	/// </summary>
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
		StoredInformation storedIN = objGame.GetComponent<StoredInformation>();
		moneyTotal=0;
		money = new MoneySystem();

		if(Application.loadedLevelName=="NewGame"){
			level =1;
			experience=100;
			storedIN.level =1;
			storedIN.experience=100;

			storedIN.nextLevelvalue = experience*1.2f;
			storedIN.nextLevel = (int)(experience*1.2f);
			nextLevelvalue = experience*1.2f;
			nextLevel = (int)(experience*1.2f);

			moneyTotal = money.StarterMoney();
			storedIN.moneyTotal = moneyTotal;
		}
		else if((PlayerPrefs.GetInt("Money")!= null)||(PlayerPrefs.GetInt("Money")!= 0)){
			moneyTotal = PlayerPrefs.GetInt("Money");
			storedIN.moneyTotal = moneyTotal;
			level = PlayerPrefs.GetInt("Level");
			experience = PlayerPrefs.GetInt("Experience");
			storedIN.experience = experience;

			storedIN.level = level;
			if(level==0){
				level=1;
				storedIN.level=1;
				storedIN.experience=100;
				experience=100;
			}

		}
		else if(moneyTotal==0){
			moneyTotal = money.StarterMoney();
			storedIN.moneyTotal = moneyTotal;
		}
		else{
			moneyTotal = PlayerPrefs.GetInt("Money");
			storedIN.moneyTotal = moneyTotal;
		}

		info.StatUpdate();
		_vitalValue=info.VitalUpdate();
		_attackValue=info.AttackUpdate();
		_defenceValue=info.DefenceUpdate();
		_manaValue=info.ManaUpdate();

		if(characterName==String.Empty){
			characterName = PlayerPrefs.GetString ("Player Name");
			storedIN.characterName = PlayerPrefs.GetString ("Player Name");
		}

		itemsNameArray = new ArrayList();
		itemsContentArray = new ArrayList();
	}
	public int check =0;
	// Update is called once per frame
	/// <summary>
	/// Update this instance.
	/// updates the position, money and stats if new game
	/// deals with checking the expereience and also changes the stats and level on battle end
	 /// if the level is increased
	/// 
	/// </summary>
	void Update () {
		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		
		GameObject[] enemiesObject = GameObject.FindGameObjectsWithTag("Enemy2");
		StoredInformation storedIN = objGame.GetComponent<StoredInformation>();
		/*if(nextLevel >=storedIN.nextLevel){
			nextLevel = storedIN.nextLevel;
		}*/
		if(Application.loadedLevelName=="NewGame"){

			initiliseConstantVariables();

			position.x=1133.947f;
			position.y=377.0055f;
			position.z=3224.786f;

			storedIN.positionOnScreen = position;
			level = 1;
			experience = 100;
			storedIN.experience= 100;
		}
		if((storedIN.nextLevel==0)||(nextLevel==0)){
			level = 1;
			experience = 100;
			storedIN.experience= 100;
			storedIN.nextLevelvalue = experience* 1.2f;
			storedIN.nextLevel = (int)(experience* 1.2f);
			
			nextLevelvalue = experience* 1.2f;
			nextLevel = (int)(experience* 1.2f);
		}

		

		if(Application.loadedLevelName=="Battle Simulation"){
			GameObject[] player2Tag = GameObject.FindGameObjectsWithTag("Player2");
			BattleEnding battle = player2Tag[0].GetComponent<BattleEnding>();
			if(check <battle.myexp){
				check = battle.myexp;
				checkloop=false;
			}
			if((enemiesObject.Length==0)
			   &&(!checkloop)
			   &&(!battle.addFlag)){

				checkloop=true;
				experience = battle.myexp;
				storedIN.experience = battle.myexp;
				if(experience ==0){
					experience = check;
				}
				int count=0;
				if(battle.myexp > battle.oldLevel){
					storedIN.level+=1;

					storedIN.nextLevelvalue = battle.oldLevel * 1.5f;
					storedIN.nextLevel = (int)(battle.oldLevel * 1.5f);

					nextLevelvalue = battle.oldLevel * 1.5f;
					nextLevel = (int)(battle.oldLevel * 1.5f);
				
					while(storedIN.nextLevelvalue < battle.myexp){
						storedIN.nextLevelvalue = storedIN.nextLevelvalue *1.5f;
						storedIN.nextLevel = (int)(storedIN.nextLevel * 1.5f);
						
						nextLevelvalue = nextLevelvalue * 1.5f;
						nextLevel = (int)(nextLevel * 1.5f);
						count++;
					}
					
					int cont =0;
					while(cont <= count){
						for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
							storedIN._primaryAttributeValues[cnt] = (int)((float)storedIN._primaryAttributeValues[cnt]*1.2f);
						}
						
						for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
							storedIN._vitalValue[cnt] = (int)((float)storedIN._vitalValue[cnt]*1.2f);
						}
						
						for (int cnt = 0; cnt < Enum.GetValues(typeof(AttackName)).Length; cnt++) {
							storedIN._attackValue[cnt] = (int)((float)storedIN._attackValue[cnt]*1.2f);
						}
						
						for (int cnt = 0; cnt < Enum.GetValues(typeof(ManaName)).Length; cnt++) {
							storedIN._manaValue[cnt] = (int)((float)storedIN._manaValue[cnt]*1.2f);
						}
						
						for (int cnt = 0; cnt < Enum.GetValues(typeof(DefenceName)).Length; cnt++) {
							storedIN._defenceValue[cnt] = (int)((float)storedIN._defenceValue[cnt] *1.2f);
						}
						cont++;
					}
				}



			}

		}
		if(/*(enemiesObject.Length>0)*/(Application.loadedLevelName=="Game")&&(checkloop)){

			checkloop=false;
		}
	}
	/// <summary>
	/// Characters name.
	/// </summary>
	/// <param name="chName">Ch name.</param>
	public void CharacterName(string chName){
		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		
		StoredInformation storedIN = objGame.GetComponent<StoredInformation>();
		characterName=chName;
		storedIN.characterName=chName;

		initiliseConstantVariables();

	}
	/// <summary>
	/// Adds the items.
	/// </summary>
	/// <param name="chName">Ch name.</param>
	/// <param name="itemPower">Item power.</param>
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
	/// <summary>
	/// Adds the enemy to scene.
	/// </summary>
	/// <param name="fighting">Fighting.</param>
	public void AddEnemyToScene(int fighting){
		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		
		StoredInformation storedIN = objGame.GetComponent<StoredInformation>();

		storedIN.enemyTypeNumber = fighting;
	}
	/// <summary>
	/// Adds the player to scene.
	/// </summary>
	/// <param name="fighting">Fighting.</param>
	public void AddPlayerToScene(int fighting){
		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		
		StoredInformation storedIN = objGame.GetComponent<StoredInformation>();
		
		storedIN.playerNumber = fighting;
	}
	/// <summary>
	/// Adds the player position after battle.
	/// </summary>
	/// <param name="playerPositionAfterBattle">Player position after battle.</param>
	public void AddPlayerPositionAfterBattle(Vector3 playerPositionAfterBattle){
		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		
		StoredInformation storedIN = objGame.GetComponent<StoredInformation>();
		
		storedIN.positionOnScreen = playerPositionAfterBattle;

	}
	/// <summary>
	/// Adds the enemy number.
	/// </summary>
	/// <param name="num">Number.</param>
	public void AddEnemyNumber(int num){
		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		
		StoredInformation storedIN = objGame.GetComponent<StoredInformation>();
		
		storedIN.enemyRemoval = num;
	}
/// <summary>
/// Saves the data.
/// </summary>
	public void SaveData(){
		GameObject playerPrefab = GameObject.FindGameObjectWithTag("Player");
	
		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
		
		StoredInformation storedIN = objGame.GetComponent<StoredInformation>();
		
		PlayerPrefs.SetString ("Player Name",storedIN.characterName);

		storedIN.positionOnScreen = playerPrefab.transform.position;

		PlayerPrefs.SetInt("Money",storedIN.moneyTotal);
		PlayerPrefs.SetInt("Level",storedIN.level);
		PlayerPrefs.SetInt("Experience",storedIN.experience);
		if(storedIN.nextLevelvalue!=0){
			PlayerPrefs.SetInt("ExperienceTONextLevel",(int)storedIN.nextLevelvalue);
		}else{
			storedIN.nextLevelvalue = storedIN.experience*1.2f;
			storedIN.nextLevel = (int)(storedIN.experience*1.2f);
			
			PlayerPrefs.SetInt("ExperienceTONextLevel",storedIN.nextLevel);
		}

		PlayerPrefs.SetFloat("Position - x",storedIN.positionOnScreen.x);
		PlayerPrefs.SetFloat("Position - y",storedIN.positionOnScreen.y);
		PlayerPrefs.SetFloat("Position - z",storedIN.positionOnScreen.z);
		#region - region of modified code
		///<summary>
		/// Title: Hack & Slash RPG - A Unity3D Game Engine Tutorial | BurgZerg Arcade. [Online].;
		/// Author: Laliberte P. 
		/// Date: 2013 October 24. 
		/// Available from: http://www.burgzergarcade.com/hack-slash-rpg-unity3d-game-engine-tutorial
		/// </summary>
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			PlayerPrefs.SetString("Attribute Name - " + cnt, storedIN._primaryAttribute[cnt]);
			PlayerPrefs.SetInt (((AttributeName)cnt).ToString () + " - Base Value - " + cnt, storedIN._primaryAttributeValues[cnt] );
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			PlayerPrefs.SetString("Vital Name - " + cnt, storedIN._vital[cnt]);
			PlayerPrefs.SetInt (((VitalName)cnt).ToString () + " - Base Value - " + cnt, storedIN._vitalValue[cnt]);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttackName)).Length; cnt++) {
			PlayerPrefs.SetString("Attack Name - " + cnt, storedIN._attack[cnt]);
			PlayerPrefs.SetInt (((AttackName)cnt).ToString () + " - Base Value - " + cnt, storedIN._attackValue[cnt]);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(ManaName)).Length; cnt++) {
			PlayerPrefs.SetString("Mana Name - " + cnt, storedIN._mana[cnt]);
			PlayerPrefs.SetInt (((ManaName)cnt).ToString () + " - Base Value - " + cnt, storedIN._manaValue[cnt]);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(DefenceName)).Length; cnt++) {
			PlayerPrefs.SetString("Defence Name - " + cnt, storedIN._defence[cnt]);
			PlayerPrefs.SetInt (((DefenceName)cnt).ToString () + " - Base Value - " + cnt, storedIN._defenceValue[cnt]);
		}
		#endregion
		string itemFromSave= string.Empty;
		int itemCounting =0;

		do{
			
			itemFromSave = PlayerPrefs.GetString("Items - " + itemCounting);
			string ItemPowerFromSave = PlayerPrefs.GetString ("Items Power - " + itemCounting);

			if(itemFromSave!=""){
				PlayerPrefs.DeleteKey("Items - " + itemCounting);
				PlayerPrefs.DeleteKey("Items Power - " + itemCounting);
			}
			itemCounting++;
		}while(itemFromSave!="");


		for (int cnt = 0; cnt < storedIN.items.Length; cnt++) {
			if(storedIN.items[cnt]!=""){
				PlayerPrefs.SetString("Items - " + cnt, storedIN.items[cnt]);
				PlayerPrefs.SetString ("Items Power - " + cnt, storedIN.itemId[cnt]);
			}
		}

		PlayerPrefs.Save();
	}
	/// <summary>
	/// Loads the data.
	/// </summary>
	public void LoadData(){

		GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");

		StoredInformation storedIN = objGame.GetComponent<StoredInformation>();

		characterName = PlayerPrefs.GetString ("Player Name");
		storedIN.characterName = PlayerPrefs.GetString ("Player Name");

		moneyTotal = PlayerPrefs.GetInt("Money");

		level = PlayerPrefs.GetInt("Level");
		experience = PlayerPrefs.GetInt("Experience");

		storedIN.level = level;
		storedIN.experience = experience;

		if(PlayerPrefs.GetInt("ExperienceTONextLevel")<=1){
			nextLevelvalue = experience*1.2f;
			storedIN.nextLevelvalue = experience*1.2f;

			storedIN.nextLevel = (int)(experience*1.2f);
			nextLevel = (int)(experience*1.2f);

		}else{
			nextLevelvalue = (float)PlayerPrefs.GetInt("ExperienceTONextLevel");
			storedIN.nextLevelvalue = (float)PlayerPrefs.GetInt("ExperienceTONextLevel");
			storedIN.nextLevel = PlayerPrefs.GetInt("ExperienceTONextLevel");
			nextLevel = PlayerPrefs.GetInt("ExperienceTONextLevel");

		}

		storedIN.positionOnScreen.x=PlayerPrefs.GetFloat("Position - x");
		storedIN.positionOnScreen.y=PlayerPrefs.GetFloat("Position - y");
		storedIN.positionOnScreen.z=PlayerPrefs.GetFloat("Position - z");
		if(Application.loadedLevelName!="Game"){
			PlayerPosition pl;

			pl = new PlayerPosition();
			pl.Awake();

			pl.SetPosition(storedIN.positionOnScreen,Application.loadedLevelName);
		}
		#region - modified code region
		///<summary>
		/// Title: Hack & Slash RPG - A Unity3D Game Engine Tutorial | BurgZerg Arcade. [Online].;
		/// Author: Laliberte P. 
		/// Date: 2013 October 24. 
		/// Available from: http://www.burgzergarcade.com/hack-slash-rpg-unity3d-game-engine-tutorial
		/// </summary>
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			storedIN._primaryAttribute[cnt]=PlayerPrefs.GetString("Attribute Name - " + cnt);
			storedIN._primaryAttributeValues[cnt] = PlayerPrefs.GetInt (((AttributeName)cnt).ToString () + " - Base Value - " + cnt);
		}

		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			storedIN._vital[cnt]=PlayerPrefs.GetString("Vital Name - " + cnt);
			storedIN._vitalValue[cnt] = PlayerPrefs.GetInt (((VitalName)cnt).ToString () + " - Base Value - " + cnt);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttackName)).Length; cnt++) {
			storedIN._attack[cnt]=PlayerPrefs.GetString("Attack Name - " + cnt);
			storedIN._attackValue[cnt] = PlayerPrefs.GetInt (((AttackName)cnt).ToString () + " - Base Value - " + cnt);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(ManaName)).Length; cnt++) {
			storedIN._mana[cnt]=PlayerPrefs.GetString("Mana Name - " + cnt);
			storedIN._manaValue[cnt] = PlayerPrefs.GetInt (((ManaName)cnt).ToString () + " - Base Value - " + cnt,0);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(DefenceName)).Length; cnt++) {
			storedIN._defence[cnt]= PlayerPrefs.GetString("Defence Name - " + cnt);
			storedIN._defenceValue[cnt] = PlayerPrefs.GetInt (((DefenceName)cnt).ToString () + " - Base Value - " + cnt);
		}
		#endregion
		string itemFromSave= string.Empty;
		int itemCounting =0;

		do{
			itemFromSave = PlayerPrefs.GetString("Items - " + itemCounting);

			string ItemPowerFromSave = PlayerPrefs.GetString ("Items Power - " + itemCounting);
			if(itemFromSave!="")
				storedIN.addItems(itemFromSave,ItemPowerFromSave);
			itemCounting++;
		}while(itemFromSave!="");

	}
}