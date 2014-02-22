using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private int buttonWidth=200,
	buttonHeight = 50,
	groupWidth = 200,
	groupHeight = 230;
	bool paused = false;
	StoredInformation info;

	// Use this for initialization
	void Start () {
		info = new StoredInformation();
		Screen.lockCursor = true;
		Time.timeScale=1;
	}

	void OnGUI(){
		if(paused){
			GUI.BeginGroup(new Rect(((Screen.width/2)-(groupWidth/2)),
			                         ((Screen.height/2)-(groupHeight/2)),
			                         groupWidth, groupHeight));

			if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight),"Main Menu")){
				Application.LoadLevel("Main Menu");
			}
			if(GUI.Button(new Rect(0,60,buttonWidth,buttonHeight),"Save Game")){
				info.SaveData();
			}
			if(GUI.Button(new Rect(0,120,buttonWidth,buttonHeight),"Load Game")){
				info.LoadData();
			}
			if(GUI.Button(new Rect(0,180,buttonWidth,buttonHeight),"Quit Game")){
				
			}
			GUI.EndGroup();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("joystick button 2")){
			Debug.Log("hello");
			paused = TooglePausedScreen();
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























