using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour
{	
	void Awake(){
		DontDestroyOnLoad(this);	
	}
	
	public void SaveData(){
		GameObject playerPrefab = GameObject.Find("player");
		
		PlayerInformation player = playerPrefab.GetComponent<PlayerInformation>();
		PlayerPrefs.SetString("Player Name", player.Name);
		Debug.Log(player.Name);
		
	}
}

