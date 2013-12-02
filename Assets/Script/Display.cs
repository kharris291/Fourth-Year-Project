using UnityEngine;
using System.Collections;
using System;

public class Display : MonoBehaviour
{
	//retrieve the
	public float _screenHSize, _screenWsize;
	public Vector3 _center;
	public GUIStyle Continue, StartUP;
	
	
	
	// Use this for initialization
	void Start ()
	{
        _screenHSize = Screen.height;
		_screenWsize = Screen.width;
		_center.Set (_screenHSize / 2, _screenWsize / 2, 0);
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
		StartNewGame();
		
		ContinueGame();
		
	}
	
	private void StartNewGame(){
		if(GUI.Button (new Rect (_center.x, _center.y, 100, 38), "Start New Game", StartUP))
			Application.LoadLevel("NewGame");
	}
	
	
	private void ContinueGame(){
		GUI.Button (new Rect (_center.x, _center.y + 50, 100, 38), "Continue", Continue);
	}
}
