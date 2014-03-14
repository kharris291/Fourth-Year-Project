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
			GameObject con = GameObject.FindGameObjectWithTag("Constant");
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			
			GUI.BeginGroup(new Rect(((Screen.width/2)-(groupWidth/2)),
			                         ((Screen.height/2)-(groupHeight/2)),
			                         groupWidth, groupHeight));

			if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight),"Main Menu")){
				Application.LoadLevel("Main Menu");
				Destroy(con);
				Destroy(player);
			}
			if(GUI.Button(new Rect(0,60,buttonWidth,buttonHeight),"Save Game")){
				StoredInformation st = con.GetComponent<StoredInformation>();

				info.SaveData();
			}
			if(GUI.Button(new Rect(0,120,buttonWidth,buttonHeight),"Load Game")){
				if(Application.loadedLevelName=="Game"){
					Destroy(player);
					//Destroy(this);
					Application.LoadLevel("Game");
				}
				info.LoadData();

			}
			if(GUI.Button(new Rect(0,180,buttonWidth,buttonHeight),"Quit Game")){
				Application.Quit();
			}
			GUI.EndGroup();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("joystick button 2")){
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























