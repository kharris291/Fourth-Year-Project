using UnityEngine;
using System.Collections;

public class UIScreen : MonoBehaviour {

	PlayerHealth playerH;
	public int maxHealth = 100;
	public int curHealth = 100;
	private Texture3D bgImage;
	private Texture3D fgImage;
	private float healthBarLength,healthBarLength1;
	CharacterInformation playerInfo;

	BattleTimeScript script;

	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		
//		playerH.OnGUI();
		/*GameObject constVar = GameObject.FindGameObjectWithTag("Constant");
		StoredInformation stored = constVar.GetComponent<StoredInformation>();
		
		if(stored.playerNumber>=1){
			GUI.Box(new Rect(Screen.width/2+200,Screen.height-70,healthBarLength/2-10,20),"");
			GUI.Box(new Rect(Screen.width/2+200,Screen.height-70,healthBarLength/2-10,20),curHealth+"/"+maxHealth);
			GUI.Box(new Rect(Screen.width/2-50,Screen.height-70,healthBarLength/2-10,20),"");
			GUI.Box(new Rect(Screen.width/2-50,Screen.height-70,healthBarLength/2-10,20),"");
		}
		if(stored.playerNumber>=2){
			GUI.Box(new Rect(Screen.width/2+200,Screen.height-100,healthBarLength,20),"");
			//GUI.Box(new Rect(Screen.width/2+200,Screen.height-100,healthBarLength1,20),curHealth+"/"+maxHealth);
			GUI.Box(new Rect(Screen.width/2-50,Screen.height-100,healthBarLength,20),"");
			//GUI.Box(new Rect(Screen.width/2-50,Screen.height-100,healthBarLength1,20),curHealth+"/"+maxHealth);
		}
		if(stored.playerNumber>=3){
			GUI.Box(new Rect(Screen.width/2+200,Screen.height-130,healthBarLength,20),"");
			GUI.Box(new Rect(Screen.width/2+200,Screen.height-130,healthBarLength1,20),curHealth+"/"+maxHealth);
			GUI.Box(new Rect(Screen.width/2-50,Screen.height-130,healthBarLength,20),"");
			GUI.Box(new Rect(Screen.width/2-50,Screen.height-130,healthBarLength1,20),curHealth+"/"+maxHealth);
		}*/
		//script.OnGUI();
	}
}
