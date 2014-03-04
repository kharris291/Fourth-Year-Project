using UnityEngine;
using System.Collections;

public class ItemMenu : ShopWorker {
	private int buttonWidth=200,
	buttonHeight = 50,
	groupWidth = 200,
	groupHeight = 230;
	bool paused = false;
	StoredInformation info;
	bool checkedOff = false;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		Time.timeScale=1;
	}

	void Update(){
		if(checkedOff){
			paused = TooglePausedScreen();
		}
	}

	// Update is called once per frame
	public void Check (bool ch) {
		checkedOff = ch;

	}

	public void OnGUI(){
		if(paused){
			GUI.BeginGroup(new Rect(((Screen.width/3)-(groupWidth/2)),
			                        ((Screen.height/3)-(groupHeight/2)),
			                        groupWidth, groupHeight));
			
			if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight),"Buy")){

			}
			if(GUI.Button(new Rect(0,60,buttonWidth,buttonHeight),"Sell")){

			}
			GUI.EndGroup();
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
}
