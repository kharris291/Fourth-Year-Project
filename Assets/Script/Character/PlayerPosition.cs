/// <summary>
/// Player position.cs
/// Author: Harris Kevin
/// checks for the characters position and for changes in it between continuing and a new game
/// also sets the position after coming out of a battle
/// </summary>
using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour {
	public Vector3 position;
	// Use this for initialization
	GameObject player;

	public void Awake(){
		DontDestroyOnLoad(this);
	}
	string current;

	public string previos;
	void OnLevelWasLoaded(){

		if(Application.loadedLevelName == "NewGame"){
			current = Application.loadedLevelName;
		}

		if(Application.loadedLevelName=="Game"){
			GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");

			StoredInformation storedIn = objGame.GetComponent<StoredInformation>();
			if((Application.loadedLevelName=="NewGame")||(previos=="NewGame")){
				position.x=1133.947f;
				position.y=377.0055f;
				position.z=3224.786f;
				storedIn.positionOnScreen= position;
			}
			else if((storedIn.positionOnScreen.x!=0)
			   &&(storedIn.positionOnScreen.y!=0)
			   &&(storedIn.positionOnScreen.z!=0)){
				position = storedIn.positionOnScreen;
			}
			else{
				position.x=1133.947f;
				position.y=377.0055f;
				position.z=3224.786f;
				storedIn.positionOnScreen = position;
			}
			SetCharacterPosition();
		}
	}

	public void SetPosition(Vector3 playerPosition,string prev){
		previos = prev;
		position.x = playerPosition.x;
		position.y = playerPosition.y;
		position.z = playerPosition.z;
	}

	void SetCharacterPosition(){
		
		GameObject objGame = GameObject.FindGameObjectWithTag ("Player");

		objGame.transform.position = position;
	}
}
