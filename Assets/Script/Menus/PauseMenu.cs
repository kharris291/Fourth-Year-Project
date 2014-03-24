/// <summary>
/// Pause menu.cs
/// Author: Harris Kevin
/// </summary>
using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private int widthOfButton=200,
	heightOfButton = 50,
	buttonGroupWidth = 200,
	buttonGroupHeight = 320;
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
			
			GUI.BeginGroup(new Rect(((Screen.width/2)-(buttonGroupWidth/2)),
			                         ((Screen.height/2)-(buttonGroupHeight/2)),
			                         buttonGroupWidth, buttonGroupHeight));
			
			if(GUI.Button(new Rect(0,0,widthOfButton,heightOfButton),"Resume")){
				paused = TooglePausedScreen();
			}
			
			if(GUI.Button(new Rect(0,60,widthOfButton,heightOfButton),"Main Menu")){
				Application.LoadLevel("Main Menu");
				Destroy(con);
				Destroy(player);
			}
			if(GUI.Button(new Rect(0,120,widthOfButton,heightOfButton),"Save Game")){
				StoredInformation st = con.GetComponent<StoredInformation>();

				info.SaveData();
			}
			if(GUI.Button(new Rect(0,180,widthOfButton,heightOfButton),"Load Game")){
				if(Application.loadedLevelName=="Game"){
					Destroy(player);
					//Destroy(this);
					Application.LoadLevel("Game");
				}
				info.LoadData();

			}
			if(GUI.Button(new Rect(0,240,widthOfButton,heightOfButton),"Quit Game")){
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