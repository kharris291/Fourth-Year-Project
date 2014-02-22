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
	public int StartingLeft =20, StartingTop =200;
	public string CharacterName="";
	bool shift=false;
	
	private GameObject storeInfo, obtain;
	// Use this for initialization
	void Start ()
	{
		
		storeInfo = GameObject.FindGameObjectWithTag ("Constant");

		_screenHSize = Screen.height;
		_screenWsize = Screen.width;
		_center.Set ( _screenWsize/ 2, _screenHSize / 2, 0);
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
		fontStyling.fontSize = Screen.width/23;
		fontStyling.alignment = TextAnchor.MiddleCenter;

		GUI.Label (new Rect (_center.x, 40, Screen.height/23, Screen.width/20), welcome, fontStyling);
		GUI.Label (new Rect (_center.x, 100, 200, Screen.width/20), Name, fontStyling);
		
		if (_mainCharacter.Name == "") {
			checkNameFilled ("Enter a Name Please");
		} else{
			checkNameFilled ("Continue");
		}
		_mainCharacter.Name = GUI.TextField (new Rect (_center.x, 200, 200, 30), _mainCharacter.Name);
		
	}


	void checkNameFilled (string factor)
	{
		if (factor == "Continue") {
			if (GUI.Button (new Rect (_center.x, (_center.y +150), 200, 30), factor)) {
				CharacterName = _mainCharacter.Name;
				storeInfo.GetComponent<StoredInformation>().CharacterName(_mainCharacter.Name);
				Application.LoadLevel ("Game");
				Destroy (this);
			}
		
		} else {
			GUI.Label (new Rect (_center.x, (_center.y +150), 200, 30), factor, "Button");
		}
	}
	
}
