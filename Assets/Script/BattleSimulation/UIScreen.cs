using UnityEngine;
using System.Collections;

public class UIScreen : MonoBehaviour {

	PlayerHealth playerH;
	public int maxHealth = 100;
	public int curHealth = 100;
	private Texture3D bgImage;
	private Texture3D fgImage;
	private float healthBarLength,healthBarLength1;
	CharacterInformation playerInfo;

	BattleTimeScript script;

	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

	}
}
