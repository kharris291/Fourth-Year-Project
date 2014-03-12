using UnityEngine;
using System.Collections;

public class EnemyGeneration : MonoBehaviour {

	GameObject[] Enmy;
	public GameObject[] enemylisting;
	// Use this for initialization
	void Start () {
		if(Application.loadedLevelName=="Game")
			Enmy = GameObject.FindGameObjectsWithTag("Enemy");
		if(Application.loadedLevelName=="Battle Simulation")
			Enmy = GameObject.FindGameObjectsWithTag("EnemyBattle");
		Generate();
	}
	GameObject[] positions;
	GameObject ObjPlacement;
	void Generate(){
		positions = new GameObject[Enmy.Length];
		int enemyNumb;
		if(Application.loadedLevelName=="Game"){
			for( int cnt = 0; cnt < Enmy.Length; cnt ++){
				enemyNumb = Random.Range(1,3);

				Enmy[cnt] = Instantiate(enemylisting[enemyNumb-1],Enmy[cnt].transform.position, Quaternion.identity) as GameObject;
			}
		}
		if(Application.loadedLevelName=="Battle Simulation"){
			
			GameObject constVar = GameObject.FindGameObjectWithTag("Constant");
			StoredInformation stored = constVar.GetComponent<StoredInformation>();
			int EnemyAmount = Random.Range(1,3);
			Debug.Log(EnemyAmount);
			for( int cnt = 0; cnt < Enmy.Length; cnt ++){
				enemyNumb = stored.enemyTypeNumber;

				if(cnt < EnemyAmount)
					Enmy[cnt] = Instantiate(enemylisting[enemyNumb],Enmy[cnt].transform.position, Quaternion.identity) as GameObject;
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

}
