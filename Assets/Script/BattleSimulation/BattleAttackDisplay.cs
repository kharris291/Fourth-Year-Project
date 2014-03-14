using UnityEngine;
using System.Collections;

public class BattleAttackDisplay : MonoBehaviour {

	BattleTimeScript battle;
	GameObject[] desiredPlayer;
	public Texture2D[] buttonProperty = new Texture2D[4];
	private int buttonWidth=200,
	buttonHeight = 50,
	groupWidth = 200,
	groupHeight = 230;
	// Use this for initialization
	void Awake () {

	}

	void Start(){
		desiredPlayer  =GameObject.FindGameObjectsWithTag("Player2");
		battle = desiredPlayer[0].GetComponent<BattleTimeScript>();
	}
	int counter =0;
	// Update is called once per frame
	void Update () {
		if((battle.timeToAttack>99)&&(counter!=1)){
			counter =1;
		}
	}
	int count =0;
	public GUIStyle sty,placement;
	void OnGUI(){
		if(counter==1){
			GUI.BeginGroup(new Rect((0),
			                        ((Screen.height)-(groupHeight/1.5f)),
			                        groupWidth, groupHeight));
			//GUI.enabled =false;
			int height = groupHeight/6;
			sty.normal.textColor = new Color(0,0,0);
			sty.alignment = TextAnchor.MiddleLeft;
			placement.normal.background = buttonProperty[0];

			GUI.Button(new Rect(0,0,buttonWidth,buttonHeight),"",sty);
		
			GUI.Label(new Rect(0,0,buttonWidth/1.5f,height),"Attack",sty);
			GUI.enabled = false;
			GUI.Label(new Rect(buttonWidth/1.5f,0,buttonWidth/3,height),"",placement);

			placement.normal.background = buttonProperty[1];
			count = groupHeight/6;
			GUI.enabled = true;
			GUI.Label(new Rect(0,count,buttonWidth/1.5f,height),"Magic",sty);
			GUI.enabled = false;
			GUI.Label(new Rect(buttonWidth/1.5f,count,buttonWidth/3,height),"",placement);

			count += groupHeight/6;
			placement.normal.background = buttonProperty[2];
			GUI.enabled = true;
			GUI.Label(new Rect(0,count,buttonWidth/1.5f,height),"Items",sty);
			GUI.enabled = false;
			GUI.Label(new Rect(buttonWidth/1.5f,count,buttonWidth/3,height),"",placement);

			count += groupHeight/6;
			placement.normal.background = buttonProperty[3];
			GUI.enabled = true;
			GUI.Label(new Rect(0,count,buttonWidth/1.5f,height),"Run",sty);
			GUI.enabled = false;
			GUI.Label(new Rect(buttonWidth/1.5f,count,buttonWidth/3,height),"",placement);

			GUI.EndGroup();
		}else{

		}
	}
}
