/// <summary>
/// Battle attack display.cs
/// Author: Harris Kevin
/// </summary>
using UnityEngine;
using System.Collections;

public class BattleAttackDisplay : MonoBehaviour {

	BattleTimeScript battle;
	GameObject[] desiredPlayer;
	public Texture2D[] buttonProperty = new Texture2D[4];
	public Texture2D[] DPad = new Texture2D[4];
	private int widthOfButton=200,
	heigthOfButton = 50,
	buttonGroupWidth = 200,
	buttonGroupHeight = 230;
	int buttonPressedCheck;
	string[] optionsToSelect = new string[4];
	StoredInformation stored;
	GameObject constVar;
	bool secondCheck=false;
	PlayerAttack attacking;
	
	MagicAttack attackingWithMagic;
	public float waitingPeriod=0;
	int attackDisplay =0;
	public int EnemyNumber=0;
	public string attackType;
	// Use this for initialization
	void Awake () {
		optionsToSelect[0] = "Attack";
		optionsToSelect[1] = "Magic";
		optionsToSelect[2] = "Items";
		optionsToSelect[3] = "Run";
		buttonPressedCheck =0;
	}

	void Start(){
		desiredPlayer  =GameObject.FindGameObjectsWithTag("Player2");
		battle = desiredPlayer[0].GetComponent<BattleTimeScript>();
		constVar  =GameObject.FindGameObjectWithTag("Constant");
		stored = constVar.GetComponent<StoredInformation>();
		attacking = new PlayerAttack();
		attackingWithMagic = new MagicAttack();
	}

	int counter =0;
	int flag =0;
	bool flagCheck = false;
	// Update is called once per frame
	void Update () {
		GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy2");
		if(enemyObjects.Length!=0){
			if((battle.timeToAttack>99)&&(counter!=1)){
				counter =1;
			}
			if((battle.timeToAttack<99)&&(counter==1)){
				counter =0;
				optionsToSelect[0] = "Attack";
				optionsToSelect[1] = "Magic";
				optionsToSelect[2] = "Items";
				optionsToSelect[3] = "Run";
				flag=0;
				flagCheck=false;
			}

			if(counter==1){

			
				if((Input.GetKeyUp("joystick button 0"))&&(flag!=1)&&(!flagCheck)){
					flag =1;
					flagCheck=true;
				}
				if((Input.GetKeyUp("joystick button 1"))&&(flag!=2)&&(!flagCheck)){

					flag=2;
					flagCheck=true;
				}
				if((Input.GetKeyUp("joystick button 2"))&&(flag!=3)&&(!flagCheck)){
					flag=3;
					flagCheck=true;
				}
				if((Input.GetKeyUp("joystick button 3"))&&(flag!=4)&&(!flagCheck)){
					flag =4;
					if(buttonPressedCheck==0){
						
					}
					else{
						buttonPressedCheck=0;
					}
				}
			
				if(flag==1){
					//Attack();
					GameObject[] game = GameObject.FindGameObjectsWithTag("Enemy2");
					if(Input.GetKeyUp("joystick button 10")){
						EnemyNumber--;
						if(EnemyNumber < 0)
							EnemyNumber =0;
					}
					if(Input.GetKeyUp("joystick button 11")){
						EnemyNumber++;
						if(EnemyNumber > game.Length-1){
							EnemyNumber =game.Length-1;
						}
					}

					for(int cnt =0; cnt < optionsToSelect.Length; cnt ++){
						if((attackDisplay+cnt)>stored._attack.Length){
							attackDisplay--;
						}
						if((attackDisplay+cnt)<stored._attack.Length){
							optionsToSelect[cnt] = stored._attack[cnt+attackDisplay];
						}
						if(Input.GetKeyUp("joystick button 8")){
							attackDisplay--;
							if(attackDisplay < 0)
								attackDisplay =0;
						}
						if(Input.GetKeyUp("joystick button 9")){
							attackDisplay++;
						}
						if(cnt == optionsToSelect.Length-1){
							optionsToSelect[3] = "Back";
						}
						if(Input.GetKeyUp("joystick button 3")){
							flag =0;
							optionsToSelect[0] = "Attack";
							optionsToSelect[1] = "Magic";
							optionsToSelect[2] = "Items";
							optionsToSelect[3] = "Run";
							attackDisplay=0;
							flagCheck = false;
						}

						if((Input.GetKeyUp("joystick button 0"))&&(secondCheck==true)){
							waitingPeriod+=0.1f;
							if(waitingPeriod>0.6f){
								if(optionsToSelect[0]=="Attack"){
									attacking = new PlayerAttack();
									attackType = "Attack";
									attacking.Start();
									attacking.retrieveEnemies(EnemyNumber);
									attacking.AttackEnemy();
									secondCheck = false;
									waitingPeriod=0;
								}
								if(optionsToSelect[0] =="FireAttack"){
									attacking = new PlayerAttack();
									attackType = "FireAttack";
									attacking.Start();
									attacking.retrieveEnemies(EnemyNumber);
									attacking.FireAttackEnemy();
									secondCheck = false;
									waitingPeriod=0;
								}
								
							}
						}
						
						if/*(Input.GetKeyUp("joystick button 2"))*/
						((Input.GetKeyUp("joystick button 1"))&&(secondCheck)){
							waitingPeriod+=0.1f;
							if(waitingPeriod>0.6f){
								if(optionsToSelect[1]=="FireAttack"){
									attacking = new PlayerAttack();
									attackType = "FireAttack";
									attacking.Start();
									attacking.retrieveEnemies(EnemyNumber);
									attacking.FireAttackEnemy();
									secondCheck = false;
									waitingPeriod=0;
								}
								if(optionsToSelect[1] =="IceAttack"){
									attacking = new PlayerAttack();
									attackType = "IceAttack";
									attacking.Start();
									attacking.retrieveEnemies(EnemyNumber);
									attacking.IceAttackEnemy();
									secondCheck = false;
									waitingPeriod=0;
								}
								
							}
						}
						if(Input.GetKeyUp("joystick button 2"))/*(Input.GetKeyUp("joystick button 3")){*/
						{
							waitingPeriod+=0.1f;
							if(waitingPeriod>0.6f){
								if(optionsToSelect[2]=="IceAttack"){
									attacking = new PlayerAttack();
									attackType = "IceAttack";
									attacking.Start();
									attacking.retrieveEnemies(EnemyNumber);
									attacking.IceAttackEnemy();
									secondCheck = false;
									waitingPeriod=0;
								}
								if(optionsToSelect[2] =="LightningAttack"){
									attacking = new PlayerAttack();
									attackType = "LightningAttack";
									attacking.Start();
									attacking.retrieveEnemies(EnemyNumber);
									attacking.LightningAttackEnemy();
									secondCheck = false;
									waitingPeriod=0;
								}
								
							}
						}
						if(Input.GetKeyUp("joystick button 3"))/*(Input.GetKeyUp("joystick button 1")){*/{

						}
					}

					
					if((flag==1)&&
					   (((Input.GetKeyUp("joystick button 0")))||
					   ((Input.GetKeyUp("joystick button 1")))||
					   ((Input.GetKeyUp("joystick button 2")))
					   )&&(secondCheck==false)){
						secondCheck=true;
					}
				}
				if(flag==2){
					//Magic();

					for(int cnt =0; cnt < optionsToSelect.Length; cnt ++){
						if((attackDisplay+cnt)>stored._mana.Length){
							attackDisplay--;
						}
						if((attackDisplay+cnt)<stored._mana.Length){
							optionsToSelect[cnt] = stored._mana[cnt+attackDisplay];
						}
						if(Input.GetKeyUp("joystick button 8")){
							attackDisplay--;
							if(attackDisplay < 0)
								attackDisplay =0;
						}
						if(Input.GetKeyUp("joystick button 9")){
							attackDisplay++;
						}
						if(cnt == optionsToSelect.Length-1){
							optionsToSelect[3] = "Back";
						}
					}
					GameObject[] game = GameObject.FindGameObjectsWithTag("Enemy2");
					if(Input.GetKeyUp("joystick button 10")){
						EnemyNumber--;
						if(EnemyNumber < 0)
							EnemyNumber =0;
					}
					if(Input.GetKeyUp("joystick button 11")){
						EnemyNumber++;
						if(EnemyNumber > game.Length-1){
							EnemyNumber =game.Length-1;
						}
					}
					if(Input.GetKeyUp("joystick button 3")){/*(Input.GetKeyUp("joystick button 1")){*/
						flag =0;
						optionsToSelect[0] = "Attack";
						optionsToSelect[1] = "Magic";
						optionsToSelect[2] = "Items";
						optionsToSelect[3] = "Run";
						attackDisplay=0;
						flagCheck=false;
					}

					if((Input.GetKeyUp("joystick button 0"))&&(secondCheck==true)){
						waitingPeriod+=0.3f;
						Debug.Log(waitingPeriod);
						if(waitingPeriod>0.7f){
							if(optionsToSelect[0]=="Fire"){
								attackingWithMagic = new MagicAttack();
								attackType = optionsToSelect[0];
								attackingWithMagic.Start();
								attackingWithMagic.retrieveEnemies(EnemyNumber);
								attackingWithMagic.FireAttackEnemy();
								secondCheck = false;
							//	flag =0;
								waitingPeriod=0;
							}
							if(optionsToSelect[0] =="Water"){
								attackingWithMagic = new MagicAttack();
								attackType = optionsToSelect[0];
								attackingWithMagic.Start();
								attackingWithMagic.retrieveEnemies(EnemyNumber);
								attackingWithMagic.FireAttackEnemy();
								secondCheck = false;
								//flag =0;
								waitingPeriod=0;
							}
							
						}
					}
					
					if/*(Input.GetKeyUp("joystick button 2"))*/
					((Input.GetKeyUp("joystick button 1"))&&(secondCheck)){
						waitingPeriod+=0.3f;
						
						Debug.Log(waitingPeriod);
						if(waitingPeriod>0.7f){
							if(optionsToSelect[1] =="Wind"){
								attackingWithMagic = new MagicAttack();
								attackType = "Wind";
								attackingWithMagic.Start();
								attackingWithMagic.retrieveEnemies(EnemyNumber);
								attackingWithMagic.FireAttackEnemy();
								secondCheck = false;
								//flag =0;
								waitingPeriod=0;
							}
							if(optionsToSelect[1] =="Ice"){
								attackingWithMagic = new MagicAttack();
								attackType = "Ice";
								attackingWithMagic.Start();
								attackingWithMagic.retrieveEnemies(EnemyNumber);
								attackingWithMagic.IceAttackEnemy();
								secondCheck = false;
								//flag =0;
								waitingPeriod=0;
							}
							
						}
					}
					if(Input.GetKeyUp("joystick button 2"))/*(Input.GetKeyUp("joystick button 3")){*/
					{
						waitingPeriod+=0.3f;
						Debug.Log(waitingPeriod);
						if(waitingPeriod>0.7f){

							if(optionsToSelect[2] =="Water"){
								attackingWithMagic = new MagicAttack();
								attackType = "Water";
								attackingWithMagic.Start();
								attackingWithMagic.retrieveEnemies(EnemyNumber);
								attackingWithMagic.FireAttackEnemy();
								secondCheck = false;
								//flag =0;
								waitingPeriod=0;
							}
							if(optionsToSelect[2] =="Lightning"){
								attackingWithMagic = new MagicAttack();
								attackType = "Lightning";
								attackingWithMagic.Start();
								attackingWithMagic.retrieveEnemies(EnemyNumber);
								attackingWithMagic.LightningAttackEnemy();
								secondCheck = false;
								//flag =0;
								waitingPeriod=0;
							}
							
						}
					}
					if(Input.GetKeyUp("joystick button 3"))/*(Input.GetKeyUp("joystick button 1")){*/{
						
					}
					if((flag==2)&&
					   (((Input.GetKeyUp("joystick button 0")))||
					 ((Input.GetKeyUp("joystick button 1")))||
					 ((Input.GetKeyUp("joystick button 2")))
					 )&&(secondCheck==false)){
						secondCheck=true;
						waitingPeriod+=0.1f;
					}
					

				}
				if(flag==3){
	//				Items();
					for(int cnt =0; cnt < optionsToSelect.Length; cnt ++){
						/*if((attackDisplay+cnt)>stored.items.Length){
							attackDisplay--;
						}*/

						if(((attackDisplay+cnt)<stored.items.Length)
						   &&(cnt < stored.items.Length)){
							optionsToSelect[cnt] = stored.items[cnt+attackDisplay];
						}else{
							optionsToSelect[cnt] = "";
						}

						if(Input.GetKeyUp("joystick button 8")){
							attackDisplay--;
							if(attackDisplay < 0)
								attackDisplay =0;
						}
						if(Input.GetKeyUp("joystick button 9")){
							attackDisplay++;
						}
						if(cnt == optionsToSelect.Length-1){
							optionsToSelect[3] = "Back";
						}
					}
					if(Input.GetKeyUp("joystick button 0")){
					}
					if/*(Input.GetKeyUp("joystick button 2"))*/
					(Input.GetKeyUp("joystick button 1")){
					}
					if(Input.GetKeyUp("joystick button 2"))/*(Input.GetKeyUp("joystick button 3"))*/
					{
					}
					if(Input.GetKeyUp("joystick button 3")){/*(Input.GetKeyUp("joystick button 1")){*/
					
						flag =0;
						optionsToSelect[0] = "Attack";
						optionsToSelect[1] = "Magic";
						optionsToSelect[2] = "Items";
						optionsToSelect[3] = "Run";
						attackDisplay=0;
						flagCheck=false;
					}
				}
				if(flag==4){
					Run();
				}

			}
		}
	}

	int count =0;
	public GUIStyle sty,placement;
	void OnGUI(){
		GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy2");
		if(enemyObjects.Length!=0){
			if(counter==1){
				GUI.BeginGroup(new Rect((0),
				                        ((Screen.height)-(buttonGroupHeight/1.5f)),
				                        buttonGroupWidth, buttonGroupHeight));
				//GUI.enabled =false;
				int height = buttonGroupHeight/6;
				sty.normal.textColor = new Color(0,0,0);
				sty.alignment = TextAnchor.MiddleLeft;
				placement.normal.background = buttonProperty[0];

				GUI.Button(new Rect(0,0,widthOfButton,heigthOfButton),"",sty);
			
				GUI.Label(new Rect(0,0,widthOfButton/1.5f,height),optionsToSelect[0],sty);
				GUI.enabled = false;
				GUI.Label(new Rect(widthOfButton/1.5f,0,widthOfButton/3,height),"",placement);

				placement.normal.background = buttonProperty[1];
				count = buttonGroupHeight/6;
				GUI.enabled = true;
				GUI.Label(new Rect(0,count,widthOfButton/1.5f,height),optionsToSelect[1],sty);
				GUI.enabled = false;
				GUI.Label(new Rect(widthOfButton/1.5f,count,widthOfButton/3,height),"",placement);

				count += buttonGroupHeight/6;
				placement.normal.background = buttonProperty[2];
				GUI.enabled = true;
				GUI.Label(new Rect(0,count,widthOfButton/1.5f,height),optionsToSelect[2],sty);
				GUI.enabled = false;
				GUI.Label(new Rect(widthOfButton/1.5f,count,widthOfButton/3,height),"",placement);

				count += buttonGroupHeight/6;
				placement.normal.background = buttonProperty[3];
				GUI.enabled = true;
				GUI.Label(new Rect(0,count,widthOfButton/1.5f,height),optionsToSelect[3],sty);
				GUI.enabled = false;
				GUI.Label(new Rect(widthOfButton/1.5f,count,widthOfButton/3,height),"",placement);

				GUI.EndGroup();
				
				if((flag==1)||(flag==2)||(flag==3)){
					GUI.Label(new Rect(0,
					                   ((Screen.height)-(buttonGroupHeight/1.5f)-50),
					                   50, 
					                   50),DPad[0]);
					GUI.Label(new Rect(70,
					                   ((Screen.height)-(buttonGroupHeight/1.5f)-50),
					                   50, 
					                   50),DPad[1]);

					GUIStyle ok = new GUIStyle();
					ok.alignment = TextAnchor.MiddleCenter;
					ok.fontSize = 24;
					GUI.Label(new Rect(30,
					                   ((Screen.height)-(buttonGroupHeight/1.5f)-100),
					                   50, 
					                   50),(1+EnemyNumber).ToString(),ok);

					GUI.Label(new Rect(0,
					                   ((Screen.height)-(buttonGroupHeight/1.5f)-100),
					                   50, 
					                   50),DPad[2]);

					GUI.Label(new Rect(70,
					                   ((Screen.height)-(buttonGroupHeight/1.5f)-100),
					                   50, 
					                   50),DPad[3]);
				}
			}else{

			}
		}
	}

	void Run(){
		Application.LoadLevel("Game");
	}
}
