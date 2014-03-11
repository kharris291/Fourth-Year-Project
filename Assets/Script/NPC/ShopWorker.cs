using UnityEngine;
using System.Collections;

public class ShopWorker : MonoBehaviour {
	
	private bool ShopMenu;
	public GameObject[] item,weapon,magic;
	public GameObject player;
	ReadAFile fileReading;

	private int buttonWidth=200,
	buttonHeight = 50,
	groupWidth = 600,
	groupHeight = 230;
	public bool paused = false,
	checkedOff = false,
	buying = false;
	StoredInformation info;

	public string shopAssistantType;
	public string shopStatus,shopType;
	float ItemDistance = 1000,
	WeaponDistance = 1000,
	MagicDistance = 1000;
	int ItemCounter,
	WeaponCounter,
	MagicCounter,
	counter;
	
	private MoneySystem money;

	bool filereadingCheck = false;
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		Time.timeScale=1;

		item = GameObject.FindGameObjectsWithTag("Item");
		weapon = GameObject.FindGameObjectsWithTag("Weapon");
		magic = GameObject.FindGameObjectsWithTag("Magic");
		player = GameObject.FindGameObjectWithTag("Player");

		money = new MoneySystem();
		info = new StoredInformation();
	}
	// Update is called once per frame
	void Update () {
		animation.Play("idle");


		if ((Input.GetKeyUp("joystick button 0"))&&(ShopMenu==true)){
			for(int cnt = 0; cnt < item.Length; cnt++){
				if(Vector3.Distance(item[cnt].transform.position,player.transform.position)<=ItemDistance){
					ItemDistance = Vector3.Distance(item[cnt].transform.position,player.transform.position);
					counter=ItemCounter = cnt;
				}
				if(cnt == item.Length-1){
					if(Vector3.Distance(item[ItemCounter].transform.position,player.transform.position)<10){
						
						shopType = "Item";
					}
				}
			}
			for(int cnt1 = 0; cnt1 < weapon.Length; cnt1++){
				if(Vector3.Distance(weapon[cnt1].transform.position,player.transform.position)<=WeaponDistance){
					WeaponDistance = Vector3.Distance(weapon[cnt1].transform.position,player.transform.position);
					counter=WeaponCounter = cnt1;
				}
				if(cnt1 == weapon.Length-1){
					if(Vector3.Distance(weapon[WeaponCounter].transform.position,player.transform.position)<10){
						shopType = "Weapon";
					}
				}
			}
			for(int i = 0; i < magic.Length; i++){
				if(Vector3.Distance(magic[i].transform.position,player.transform.position)<=MagicDistance){
					MagicDistance = Vector3.Distance(magic[i].transform.position,player.transform.position);
					counter=MagicCounter = i;
				}
				if(i == magic.Length-1){
					if(Vector3.Distance(magic[MagicCounter].transform.position,player.transform.position)<10){
						shopType = "Magic";
					}
				}
			}


			paused = TooglePausedScreen();
		}
	}
	bool shopOpen = false;
	
	GameObject[] ga;
	void OnGUI(){
		if(ShopMenu){
			shopStatus= "Press O to open";
			GUI.Label(new Rect(0,0, 300,30),shopStatus);
			shopOpen=true;

		}
		if(paused){
			shopStatus="";
			//if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight),"Buy")){
			if(shopAssistantType =="buy"){
//				buying=true;
				buyingStuff();
				/*GUI.BeginGroup(new Rect(((Screen.width/3)-(groupWidth/2)),
				                        ((Screen.height/3)-(groupHeight/2)),
				                        Screen.width, Screen.height));
				if(GUI.Button(new Rect(buttonWidth+10,0,buttonWidth,buttonHeight),"Buying")){
					//buyingStuff(shopType);
					
					
				}
				if(GUI.Button(new Rect(buttonWidth+10,60,buttonWidth,buttonHeight),"Sell")){
					
				}
				
				GUI.EndGroup();
*/

				GUI.BeginGroup(new Rect(((Screen.width/2)-(groupWidth/2)),
				                        ((Screen.height/2)-(groupHeight/2)),
				                        Screen.width, Screen.height));
				int startingPosLeft =0;
				int StartingPosTop =0;
				int itemPrice =0;
				ga = GameObject.FindGameObjectsWithTag(shopType);
				string details="";
				bool buyingAttempt;
				for(int cnt =0; cnt < fileReading._name.Length; cnt ++){

					if((ga[counter].GetComponent<ReadAFile>()._name[cnt]!=null)&&(ga[counter].GetComponent<ReadAFile>()._name[cnt]!="")){
						if(shopType=="Magic"){
							details = "Ability";
						}
						if(shopType=="Weapon"){
							details = "Power";
						}
						if(shopType=="Item"){
							details = "Recovers";
						}
						if(GUI.Button(new Rect(startingPosLeft,StartingPosTop,buttonWidth,buttonHeight),
						              "Name : "+ ga[counter].GetComponent<ReadAFile>()._name[cnt] +
						              "\r\n "+ details +" : " + ga[counter].GetComponent<ReadAFile>()._id[cnt] +
						              "\r\n Price : " + ga[counter].GetComponent<ReadAFile>()._price[cnt])){
							itemPrice = int.Parse(ga[counter].GetComponent<ReadAFile>()._price[cnt]);
							//buyingAttempt=money.money("minus",itemPrice);
						
							GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
							StoredInformation st = objGame.GetComponent<StoredInformation>();
							if((st.moneyTotal-itemPrice)>-1){
								money.processMoney("minus",itemPrice);

							
								if(money.test){
									
									st.moneyTotal -= itemPrice;
									info.addItems(ga[counter].GetComponent<ReadAFile>()._name[cnt],ga[counter].GetComponent<ReadAFile>()._id[cnt]);
								}else{
									GUI.Label(new Rect(((Screen.width/2)-(groupWidth/2)),
									          ((Screen.height/2)-(groupHeight/2))-100,
									          Screen.width, Screen.height), " Not enough monry to buy");
								}
							}
						}
					}
					startingPosLeft+=buttonWidth;
					if(startingPosLeft >= groupWidth){
						startingPosLeft=0;
						StartingPosTop+=buttonHeight+20;
					}
				}
				GUI.EndGroup();
			}
			//if(GUI.Button(new Rect(0,60,buttonWidth,buttonHeight),"Sell")){
			if(shopAssistantType =="sell"){
				sellBits();
			}
		}
	}
	void buyingStuff(){


		if(shopType =="Item"){
			if(!filereadingCheck){
				fileReading = new ReadAFile();
				fileReading.Load("items.txt", shopType);
				filereadingCheck = true;
			}
		}
		if(shopType =="Magic"){
			if(!filereadingCheck){
				fileReading = new ReadAFile();
				fileReading.Load("magic.txt", shopType);
				filereadingCheck = true;
			}
		}
		if(shopType =="Weapon"){
			if(!filereadingCheck){
				fileReading = new ReadAFile();
				fileReading.Load("weapons.txt", shopType);
				filereadingCheck = true;
			}
		}

	}

	void sellBits(){

	}

	bool TooglePausedScreen(){
		if(Time.timeScale ==0){
			Screen.lockCursor = true;
			Time.timeScale=1;
			filereadingCheck = false;
			return false;
		}else{
			Screen.lockCursor = false;
			Time.timeScale = 0;
			return true;
		}
	}

	void OnTriggerEnter (Collider playerInRange)
	{
		if (playerInRange.gameObject.tag == "Player") {
			ShopMenu = true;
		}
	}
	
	void OnTriggerExit (Collider playerNotInRange)
	{
		if (playerNotInRange.gameObject.tag == "Player") {
			ShopMenu = false;
		}
	}
}
