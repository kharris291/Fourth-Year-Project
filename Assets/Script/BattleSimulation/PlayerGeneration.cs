using UnityEngine;
using System.Collections;

public class PlayerGeneration : MonoBehaviour {

	GameObject[] Players;
	public GameObject[] playerlisting;
	// Use this for initialization
	void Start () {
		Players = GameObject.FindGameObjectsWithTag("PlayerBattle");
		Generate();
	}
	GameObject ObjPlacement;
	void Generate(){
		int playerNumb;
			
		GameObject constVar = GameObject.FindGameObjectWithTag("Constant");
		StoredInformation stored = constVar.GetComponent<StoredInformation>();
		int playerAmount = Random.Range(1,3);

		for( int cnt = 0; cnt < Players.Length; cnt ++){
			playerNumb = stored.playerNumber;
			
			if(cnt < playerAmount-1){
				Players[cnt] = Instantiate(playerlisting[cnt],Players[cnt].transform.position, Quaternion.AngleAxis(37.47f,new Vector3(0,1,0))) as GameObject;
				Players[cnt].name = stored.characterName;
				Players[cnt].tag = "Player2";
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
