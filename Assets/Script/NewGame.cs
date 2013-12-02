using UnityEngine;
using System.Collections;
using System;

public class NewGame : MonoBehaviour
{
	public PlayerInformation _mainCharacter;
	public float _screenHSize, _screenWsize;
	public Vector3 _center;
	public string welcome = "Welcome Traveler to the start of a new Journey.", Name = "Enter Your Name Below";
	private const int SPACING = 20;
	public GUIStyle fontStyling;
	public int Starting =20;
	
	// Use this for initialization
	void Start ()
	{
		_screenHSize = Screen.height;
		_screenWsize = Screen.width;
		_center.Set (_screenHSize / 2, _screenWsize / 2, 0);
		GUITexture MainCamera = FindObjectOfType (typeof(GUITexture)) as GUITexture;
		if (MainCamera.name == "GameSettings") {
			MainCamera.transform.position = Vector3.zero;
        	MainCamera.transform.localScale = Vector3.zero;
			MainCamera.pixelInset = new Rect (0,0, _screenWsize,_screenHSize);
		}
		
		_mainCharacter = new PlayerInformation ();
		_mainCharacter.Awake ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI ()
	{
		fontStyling.fontSize = 32;
		fontStyling.alignment = TextAnchor.MiddleCenter;
		
		GUI.Label (new Rect (_center.x, 0, 200, 50), welcome, fontStyling);
		GUI.Label (new Rect (_center.x, 60, 200, 50), Name, fontStyling);
		
		TakeNameInput ();
		if (_mainCharacter.Name == "") {
			checkNameFilled ("Enter a Name Please");
		} else {
			checkNameFilled ("Continue");
		}
		
	}
	
	private void TakeNameInput ()
	{
		_mainCharacter.Name = GUI.TextField (new Rect (_center.x, 120, 200, 30), _mainCharacter.Name);
		
		GUI.Button(new Rect(Starting,200,40,40),"A").ToString();
		GUI.Button(new Rect(Starting+50,200,40,40),"b");
		GUI.Button(new Rect(Starting+100,200,40,40),"c");
		GUI.Button(new Rect(Starting+150,200,40,40),"d");
		GUI.Button(new Rect(Starting+200,200,40,40),"e");
		GUI.Button(new Rect(Starting+250,200,40,40),"f");
		GUI.Button(new Rect(Starting+300,200,40,40),"g");
		GUI.Button(new Rect(Starting+350,200,40,40),"h");
		GUI.Button(new Rect(Starting+400,200,40,40),"i");
		GUI.Button(new Rect(Starting+450,200,40,40),"j");
		GUI.Button(new Rect(Starting+500,200,40,40),"k");
		GUI.Button(new Rect(Starting+550,200,40,40),"l");
		GUI.Button(new Rect(Starting+600,200,40,40),"m");
		Starting = 20;
		GUI.Button(new Rect(Starting,300,40,40),"n");
		GUI.Button(new Rect(Starting+50,300,40,40),"o");
		GUI.Button(new Rect(Starting+100,300,40,40),"p");
		GUI.Button(new Rect(Starting+150,300,40,40),"q");
		GUI.Button(new Rect(Starting+200,300,40,40),"r");
		GUI.Button(new Rect(Starting+250,300,40,40),"s");
		GUI.Button(new Rect(Starting+300,300,40,40),"t");
		GUI.Button(new Rect(Starting+350,300,40,40),"u");
		GUI.Button(new Rect(Starting+400,300,40,40),"v");
		GUI.Button(new Rect(Starting+450,300,40,40),"w");
		GUI.Button(new Rect(Starting+500,300,40,40),"x");
		GUI.Button(new Rect(Starting+550,300,40,40),"y");
		GUI.Button(new Rect(Starting+600,300,40,40),"z");
	}
	
	void checkNameFilled (string factor)
	{
		if (factor == "Continue") {
			if (GUI.Button (new Rect (_center.x, (_center.y +150), 200, 30), factor)) {
				Application.LoadLevel ("Game");
				Destroy (this);
			}
		
		} else {
			GUI.Label (new Rect (_center.x, (_center.y +150), 200, 30), factor, "Button");
		}
	}
	
}
