using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour {
	public Vector3 position;
	// Use this for initialization
	GameObject player;

	public void Awake(){
		DontDestroyOnLoad(this);
	}

	void OnLevelWasLoaded(){
		if(Application.loadedLevelName=="Game"){
			//StoredInformation storeInfo;
			//storeInfo = new StoredInformation();
			//storeInfo.Start();
			//storeInfo.initiliseConstantVariables();
		//	storeInfo.LoadData();
			GameObject objGame = GameObject.FindGameObjectWithTag ("Constant");
			
			StoredInformation st = objGame.GetComponent<StoredInformation>();
			Debug.Log(st.positionOnScreen);
			if((st.positionOnScreen.x!=0)
			   &&(st.positionOnScreen.y!=0)
			   &&(st.positionOnScreen.z!=0)){
				position = st.positionOnScreen;
			}else{
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
		Debug.Log(objGame.transform.position);
	}
}
