using UnityEngine;
using System.Collections;
using System;

public class Display : MonoBehaviour
{
	//retrieve the
	public float _screenHSize, _screenWsize;
	public Vector3 _center;
	public GUIStyle Continue, StartUP;
	
	private int buttonWidth=200,
	buttonHeight = 50,
	groupWidth = 200,
	groupHeight = 120;
	
	// Use this for initialization
	void Start ()
	{
        _screenHSize = Screen.height;
		_screenWsize = Screen.width;
		_center.Set (_screenWsize / 2, _screenHSize / 2, 0);
		GUITexture mainCameraSearch = FindObjectOfType (typeof(GUITexture)) as GUITexture;
		if (mainCameraSearch.name == "Main Camera") {
			mainCameraSearch.transform.position = Vector3.zero;
        	mainCameraSearch.transform.localScale = Vector3.zero;
			mainCameraSearch.pixelInset =new Rect(0,0,_screenWsize,_screenHSize);
		}
	}
	
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnGUI ()
	{

		GUI.BeginGroup(new Rect(((_screenWsize/2)-(groupWidth/2)),
		                        ((_screenHSize/2)-(groupHeight/2)),
		                        groupWidth, groupHeight));
		
		if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight),"New Game")){
			StartNewGame();
		}
		if(GUI.Button(new Rect(0,60,buttonWidth,buttonHeight),"Continue")){
			ContinueGame();
		}
		GUI.EndGroup();
			
	}
	
	private void StartNewGame(){
		Application.LoadLevel("NewGame");
	}
	
	StoredInformation stIn;
	private void ContinueGame(){
		//stIn = new StoredInformation();
		//stIn.LoadData();
		Application.LoadLevel("Game");
		//stIn.Start();

	}
}
