/// <summary>
/// Battle ending.cs
/// Author: Harris Kevin
/// iunstantiated when a battle has been won
/// this is used to display the amount of money and exp you've won
/// also keeps a record for double checking money and stats have been updated
/// </summary>
using UnityEngine;
using System.Collections;

public class BattleEnding : MonoBehaviour {

	private int widthOfButton=200,
	heightOfButton = 50;
	float buttonGroupWidth = Screen.width/1.5f,
	buttonGroupHeight = Screen.height/1.5f;
	int enemyExperience=0;
	public int myexp, oldLevel,levelUp,moneyGained;
	public bool addFlag = true;
	public Texture2D text;
	// Use this for initialization
	void Start () {
		GameObject constantStorage = GameObject.FindGameObjectWithTag("Constant");
		StoredInformation obj = constantStorage.GetComponent<StoredInformation>();
		levelUp = obj.level;
	}
	public bool flag =false;
	// Update is called once per frame
	void Update () {
		GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy2");
		GameObject constantStorage = GameObject.FindGameObjectWithTag("Constant");
		StoredInformation obj = constantStorage.GetComponent<StoredInformation>();

		if((enemyObjects.Length==0)&&(!flag)){
		
			if(obj.enemyTypeNumber == 0){
				enemyExperience = 25;
				moneyGained = 25;
			}
			if(obj.enemyTypeNumber == 1){
				enemyExperience = 20;
				moneyGained = 20;
			}
			if(obj.enemyTypeNumber == 2){
				enemyExperience = 15;
				moneyGained = 15;
			}
			for( int cnt =0; cnt < obj.level; cnt ++){
				enemyExperience = (int)(enemyExperience*1.01f);
				moneyGained = (int)(moneyGained*1.2f);
			}
			if(obj.experience==0){
				obj.experience=100;
			}

			if(addFlag){
				myexp = obj.experience + enemyExperience;
				obj.moneyTotal += moneyGained;
				obj.check = myexp;
				oldLevel = obj.nextLevel;
				addFlag = false;
				flag=true;
				
			}
			Debug.Log(myexp);

		}
		if(flag){
			if (Input.GetKeyUp("joystick button 3")){
				Application.LoadLevel("Game");
				addFlag = true;
				flag=false;
			}
		}

	}

	public GUIStyle place,labels, sty;
	void OnGUI(){
		GameObject constantStorage = GameObject.FindGameObjectWithTag("Constant");
		StoredInformation obj = constantStorage.GetComponent<StoredInformation>();
		GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy2");
		if(enemyObjects.Length==0){
			GUI.BeginGroup(new Rect(((Screen.width/2)-(buttonGroupWidth/2)),
			                        ((Screen.height/2)-(buttonGroupHeight/2)),
			                        buttonGroupWidth,
			                        buttonGroupHeight));
			GUI.enabled =false;

			int height = (int)buttonGroupHeight/6;
			GUI.Label(new Rect(0,0,buttonGroupWidth,buttonGroupHeight),"",place);
			labels.alignment = TextAnchor.MiddleCenter;
			labels.fontSize = 24;
			labels.normal.textColor = new Color(255,255,255);
			int count = 0;
			GUI.Label(new Rect(0,count,buttonGroupWidth/1.5f,heightOfButton),"Current Experience",labels);
			GUI.Label(new Rect(buttonGroupWidth/1.5f,count,buttonGroupWidth/3,heightOfButton),myexp.ToString(),labels);
			count+= heightOfButton;
			GUI.Label(new Rect(0,count,buttonGroupWidth/1.5f,heightOfButton),"Experience Gained",labels);
			GUI.Label(new Rect(buttonGroupWidth/1.5f,count,buttonGroupWidth/3,heightOfButton),enemyExperience.ToString(),labels);
			if(levelUp < obj.level){
				count+= heightOfButton;
				GUI.Label(new Rect(0,count,buttonGroupWidth/1.5f,heightOfButton),"Level up!!",labels);
				GUI.Label(new Rect(buttonGroupWidth/1.5f,count,buttonGroupWidth/3,heightOfButton),obj.level.ToString(),labels);
			}
			count+= heightOfButton;
			GUI.Label(new Rect(0,count,buttonGroupWidth/1.5f,heightOfButton),"Money Gained",labels);
			GUI.Label(new Rect(buttonGroupWidth/1.5f,count,buttonGroupWidth/3,heightOfButton),moneyGained.ToString(),labels);
			count+= heightOfButton;
			GUI.Label(new Rect(0,count,buttonGroupWidth/1.5f,heightOfButton),"CurrentMoney",labels);
			GUI.Label(new Rect(buttonGroupWidth/1.5f,count,buttonGroupWidth/3,heightOfButton),obj.moneyTotal.ToString(),labels);
			
			GUI.Button(new Rect(buttonGroupWidth/6,buttonGroupHeight-heightOfButton,buttonGroupWidth/1.5f,heightOfButton),"To continue press",labels);

			sty.alignment = TextAnchor.MiddleRight;
			GUI.Button(new Rect(buttonGroupWidth/6,buttonGroupHeight-heightOfButton,buttonGroupWidth/1.5f,heightOfButton),text,sty);

			GUI.EndGroup();
		}
	}
}
