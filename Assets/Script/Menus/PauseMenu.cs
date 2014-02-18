using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		Time.timeScale=1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("joystick button 2")){
			Debug.Log("hello");
		}
	}
}
