using UnityEngine;
using System.Collections;

public class ShopWorker : MonoBehaviour {
	
	private bool ShopMenu;
	public GameObject item,weapon,magic,player;
	public string shopType;

	private int buttonWidth=200,
	buttonHeight = 50,
	groupWidth = 400,
	groupHeight = 230;
	bool paused = false;
	StoredInformation info;
	bool checkedOff = false;

	string shopStatus;
	// Use this for initialization
	void Start () {
		
		Screen.lockCursor = true;
		Time.timeScale=1;

		item = GameObject.FindGameObjectWithTag("Item");
		weapon = GameObject.FindGameObjectWithTag("Weapon");
		magic = GameObject.FindGameObjectWithTag("Magic");
		player = GameObject.FindGameObjectWithTag("Player");
	}
	// Update is called once per frame
	void Update () {
		animation.Play("idle");


		if ((Input.GetKeyUp("joystick button 0"))&&(ShopMenu==true)){


			if(Vector3.Distance(item.transform.position,player.transform.position)<3){
			/*	iMenu = new ItemMenu();
				iMenu.Check(!trying);
				iMenu.OnGUI();
				Debug.Log("item");*/
				shopType = "item";
			}
			if(Vector3.Distance(weapon.transform.position,player.transform.position)<3){
				/*wMenu = new WeaponMenu();
				iMenu.Check(!trying);

				Debug.Log("weapon");*/
				shopType = "weapon";
			}
			if(Vector3.Distance(magic.transform.position,player.transform.position)<3){
				/*mMenu = new MagicMenu();
				mMenu.Check(!trying);
				mMenu.OnGUI();
				Debug.Log("magic");*/
				shopType = "magic";
			}
			paused = TooglePausedScreen();
		}
	}
	bool shopOpen = false;
	void OnGUI(){
		if(ShopMenu){
			shopStatus= "Press O to open";
			GUI.Label(new Rect(0,0, 300,30),shopStatus);
			shopOpen=true;

		}
		if ((shopOpen) &&(Input.GetKeyUp("joystick button 0"))){
			shopStatus = "Press O to close";
			GUI.Label(new Rect(0,0, 300,30), shopStatus);

		}
		if(paused){
			GUI.BeginGroup(new Rect(((Screen.width/3)-(groupWidth/2)),
			                        ((Screen.height/3)-(groupHeight/2)),
			                        groupWidth, groupHeight));
			
			if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight),"Buy")){
				buyingStuff(shopType);
			}
			if(GUI.Button(new Rect(0,60,buttonWidth,buttonHeight),"Sell")){
				
			}
			GUI.EndGroup();
		}
	}

	void buyingStuff(string shopType){
		Debug.Log(shopType);
		if(shopType =="magic"){

			if(GUI.Button(new Rect(100,0,buttonWidth,buttonHeight),"Buy")){
				buyingStuff(shopType);
			}
			if(GUI.Button(new Rect(100,60,buttonWidth,buttonHeight),"Sell")){
				
			}

		}
	}

	bool TooglePausedScreen(){
		if(Time.timeScale ==0){
			Screen.lockCursor = true;
			Time.timeScale=1;
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
