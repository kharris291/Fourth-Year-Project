/// <summary>
/// Display.cs
/// </summary>
using UnityEngine;
using System.Collections;
using System;

public class Display : MonoBehaviour
{
	//retrieve the
	public Vector3 _center;
	public GUIStyle Continue, StartUP;
	
	private int widthOfButton=200,
	heightOfButton = 50,
	buttonGroupWidth = 200,
	buttonGroupHeight = 120;
	
	// Use this for initialization
	void Start ()
	{
		/// <summary>
		/// Display.cs
		/// 
		/// Title: Hack & Slash RPG - A Unity3D Game Engine Tutorial | BurgZerg Arcade. [Online].;
		/// Author: Laliberte P. 
		/// Date: 2013 October 24. 
		/// Available from: http://www.burgzergarcade.com/hack-slash-rpg-unity3d-game-engine-tutorial
		/// </summary>
		GUITexture mainCameraSearch = FindObjectOfType (typeof(GUITexture)) as GUITexture;
		if (mainCameraSearch.name == "Main Camera") {
			mainCameraSearch.transform.position = Vector3.zero;
        	mainCameraSearch.transform.localScale = Vector3.zero;
			mainCameraSearch.pixelInset =new Rect(0,0,Screen.width,Screen.height);
		}
	}

	void Update ()
	{
	
	}
	
	void OnGUI ()
	{
		GUI.BeginGroup(new Rect(((Screen.width/2)-(buttonGroupWidth/2)),
		                        ((Screen.height/2)-(buttonGroupHeight/2)),
		                        buttonGroupWidth, buttonGroupHeight));
		
		if(GUI.Button(new Rect(0,0,widthOfButton,heightOfButton),"New Game")){
			StartNewGame();
		}
		if(GUI.Button(new Rect(0,heightOfButton+10,widthOfButton,heightOfButton),"Continue")){
			ContinueGame();
		}
		GUI.EndGroup();		
	}
	
	private void StartNewGame(){
		Application.LoadLevel("NewGame");
	}

	private void ContinueGame(){
		Application.LoadLevel("Game");
	}
}
