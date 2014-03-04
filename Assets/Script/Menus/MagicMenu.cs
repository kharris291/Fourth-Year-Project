using UnityEngine;
using System.Collections;

public class MagicMenu : MonoBehaviour {
	
	private int buttonWidth=200,
	buttonHeight = 50,
	groupWidth = 200,
	groupHeight = 230;
	bool paused = false;
	StoredInformation info;
	bool checkedOff = false;
	
	// Use this for initialization
	void Start () {
	}
	
	
	public void Update(){

	}
	
	// Update is called once per frame
	public void Check (bool ch) {
		checkedOff = ch;
		Debug.Log(checkedOff);
		
	}
	
	public void addition(){
		//Debug.Log(checkedOff);
		//if(checkedOff){
			GUI.BeginGroup(new Rect(((Screen.width/3)-(groupWidth/2)),
			                        ((Screen.height/3)-(groupHeight/2)),
			                        groupWidth, groupHeight));
		Debug.Log("here");
			if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight),"Buy")){
				
			}
			if(GUI.Button(new Rect(0,60,buttonWidth,buttonHeight),"Sell")){
				
			}
			GUI.EndGroup();
		//}
	}


}
