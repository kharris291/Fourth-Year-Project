using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour {
	public Vector3 position;
	// Use this for initialization
	GameObject player;

	public void Awake(){
		DontDestroyOnLoad(this);
	}
	string current,previos;

	void OnLevelWasLoaded(){

		if(Application.loadedLevelName == "NewGame"){
			current = Application.loadedLevelName;
		}
		Debug.Log(current);
		if(Application.loadedLevelName=="Game"){
			GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");

			StoredInformation st = objGame.GetComponent<StoredInformation>();
			if(previos=="NewGame"){
				position.x=1133.947f;
				position.y=377.0055f;
				position.z=3224.786f;
			}
			else if((st.positionOnScreen.x!=0)
			   &&(st.positionOnScreen.y!=0)
			   &&(st.positionOnScreen.z!=0)){
				position = st.positionOnScreen;
			}
			else{
				position.x=1133.947f;
				position.y=377.0055f;
				position.z=3224.786f;
			}
			SetCharacterPosition();
		}
	}

	public void SetPosition(Vector3 lol){
		position.x = lol.x;
		position.y = lol.y;
		position.z = lol.z;
	}

	void SetCharacterPosition(){
		
		GameObject objGame = GameObject.FindGameObjectWithTag ("Player");

		objGame.transform.position = position;
	}
}
