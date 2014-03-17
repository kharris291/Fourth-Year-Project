using UnityEngine;
using System.Collections;

public class BattleAttackDisplay : MonoBehaviour {

	BattleTimeScript battle;
	GameObject[] desiredPlayer;
	public Texture2D[] buttonProperty = new Texture2D[4];
	public Texture2D[] UpDown = new Texture2D[2];
	private int buttonWidth=200,
	buttonHeight = 50,
	groupWidth = 200,
	groupHeight = 230;
	int buttonPressedCheck;
	string[] trying = new string[4];
	StoredInformation stored;
	GameObject constVar;
	int attackDisplay =0;
	// Use this for initialization
	void Awake () {
		trying[0] = "Attack";
		trying[1] = "Magic";
		trying[2] = "Items";
		trying[3] = "Run";
		buttonPressedCheck =0;
	}

	void Start(){
		desiredPlayer  =GameObject.FindGameObjectsWithTag("Player2");
		battle = desiredPlayer[0].GetComponent<BattleTimeScript>();
		constVar  =GameObject.FindGameObjectWithTag("Constant");
		stored = constVar.GetComponent<StoredInformation>();
	}

	int counter =0;
	int flag =0;
	bool flagCheck = false;
	// Update is called once per frame
	void Update () {
		if((battle.timeToAttack>99)&&(counter!=1)){
			counter =1;
		}

		if(counter==1){

			
			if((Input.GetKeyUp("joystick button 0"))&&(flag!=1)&&(!flagCheck)){
				flag =1;
				flagCheck=true;
			}
			if((Input.GetKeyUp("joystick button 1"))&&(flag!=2)&&(!flagCheck)){
				Debug.Log("U");
				flag=2;
				flagCheck=true;
			}
			if((Input.GetKeyUp("joystick button 2"))&&(flag!=3)&&(!flagCheck)){
				Debug.Log("U");
				flag=3;
				flagCheck=true;
			}
			if((Input.GetKeyUp("joystick button 3"))&&(flag!=4)&&(!flagCheck)){
				flag =4;
				if(buttonPressedCheck==0){
					Debug.Log("A");
				}
				else{
					buttonPressedCheck=0;
				}
			}
			
			if(flag==1){
				//Attack();
				for(int cnt =0; cnt < trying.Length; cnt ++){
					if((attackDisplay+cnt)>stored._attack.Length){
						attackDisplay--;
					}
					if((attackDisplay+cnt)<stored._attack.Length){
						trying[cnt] = stored._attack[cnt+attackDisplay];
					}
					if(Input.GetKeyUp("joystick button 8")){
						attackDisplay--;
						if(attackDisplay < 0)
							attackDisplay =0;
					}
					if(Input.GetKeyUp("joystick button 9")){
						attackDisplay++;
					}
					if(cnt == trying.Length-1){
						trying[3] = "Back";
					}
					if(Input.GetKeyUp("joystick button 3")){
						Debug.Log(trying[3]);
						flag =0;
						trying[0] = "Attack";
						trying[1] = "Magic";
						trying[2] = "Items";
						trying[3] = "Run";
						attackDisplay=0;
						flagCheck = false;
					}
				}
				if(Input.GetKeyUp("joystick button 0")){
					Debug.Log(trying[0]);
				}
				if(Input.GetKeyUp("joystick button 1")){
					Debug.Log(trying[1]);
				}
				if(Input.GetKeyUp("joystick button 2")){
					Debug.Log(trying[2]);
				}
			}
			if(flag==2){
				//Magic();
				for(int cnt =0; cnt < trying.Length; cnt ++){
					if((attackDisplay+cnt)>stored._mana.Length){
						attackDisplay--;
					}
					if((attackDisplay+cnt)<stored._mana.Length){
						trying[cnt] = stored._mana[cnt+attackDisplay];
					}
					if(Input.GetKeyUp("joystick button 8")){
						attackDisplay--;
						if(attackDisplay < 0)
							attackDisplay =0;
					}
					if(Input.GetKeyUp("joystick button 9")){
						attackDisplay++;
					}
					if(cnt == trying.Length-1){
						trying[3] = "Back";
					}
				}
				if(Input.GetKeyUp("joystick button 0")){
					Debug.Log(trying[0]);
				}
				if(Input.GetKeyUp("joystick button 1")){
					Debug.Log(trying[1]);
				}
				if(Input.GetKeyUp("joystick button 2")){
					Debug.Log(trying[2]);
				}
				if(Input.GetKeyUp("joystick button 3")){
					Debug.Log(trying[3]);
					flag =0;
					trying[0] = "Attack";
					trying[1] = "Magic";
					trying[2] = "Items";
					trying[3] = "Run";
					attackDisplay=0;
					flagCheck=false;
				}
			}
			if(flag==3){
//				Items();
				for(int cnt =0; cnt < trying.Length; cnt ++){
					if((attackDisplay+cnt)>stored.items.Length){
						attackDisplay--;
					}
					if(((attackDisplay+cnt)<stored.items.Length)&&((stored.items.Length)>(cnt+attackDisplay))){
						trying[cnt] = stored.items[cnt+attackDisplay];
					}else{
						trying[cnt] = "";
					}
					if(Input.GetKeyUp("joystick button 8")){
						attackDisplay--;
						if(attackDisplay < 0)
							attackDisplay =0;
					}
					if(Input.GetKeyUp("joystick button 9")){
						attackDisplay++;
					}
					if(cnt == trying.Length-1){
						trying[3] = "Back";
					}
				}
				if(Input.GetKeyUp("joystick button 0")){
					Debug.Log(trying[0]);
				}
				if(Input.GetKeyUp("joystick button 1")){
					Debug.Log(trying[1]);
				}
				if(Input.GetKeyUp("joystick button 2")){
					Debug.Log(trying[2]);
				}
				if(Input.GetKeyUp("joystick button 3")){
					Debug.Log(trying[3]);
					flag =0;
					trying[0] = "Attack";
					trying[1] = "Magic";
					trying[2] = "Items";
					trying[3] = "Run";
					attackDisplay=0;
					flagCheck=false;
				}
			}
			if(flag==4){
				Run();
			}

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
		
			GUI.Label(new Rect(0,0,buttonWidth/1.5f,height),trying[0],sty);
			GUI.enabled = false;
			GUI.Label(new Rect(buttonWidth/1.5f,0,buttonWidth/3,height),"",placement);

			placement.normal.background = buttonProperty[1];
			count = groupHeight/6;
			GUI.enabled = true;
			GUI.Label(new Rect(0,count,buttonWidth/1.5f,height),trying[1],sty);
			GUI.enabled = false;
			GUI.Label(new Rect(buttonWidth/1.5f,count,buttonWidth/3,height),"",placement);

			count += groupHeight/6;
			placement.normal.background = buttonProperty[2];
			GUI.enabled = true;
			GUI.Label(new Rect(0,count,buttonWidth/1.5f,height),trying[2],sty);
			GUI.enabled = false;
			GUI.Label(new Rect(buttonWidth/1.5f,count,buttonWidth/3,height),"",placement);

			count += groupHeight/6;
			placement.normal.background = buttonProperty[3];
			GUI.enabled = true;
			GUI.Label(new Rect(0,count,buttonWidth/1.5f,height),trying[3],sty);
			GUI.enabled = false;
			GUI.Label(new Rect(buttonWidth/1.5f,count,buttonWidth/3,height),"",placement);

			GUI.EndGroup();
			if((flag==1)||(flag==2)||(flag==3)){
				GUI.Label(new Rect(0,
				                   ((Screen.height)-(groupHeight/1.5f)-50),
				                   50, 
				                   50),UpDown[0]);
				GUI.Label(new Rect(60,
				                   ((Screen.height)-(groupHeight/1.5f)-50),
				                   50, 
				                   50),UpDown[1]);
			}
		}else{

		}
	}

	void Run(){
		Application.LoadLevel("Game");
	}
}
