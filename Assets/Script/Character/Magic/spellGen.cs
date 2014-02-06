using UnityEngine;
using System.Collections;

public class spellGen : MonoBehaviour {
	
	Spell spell = new Spell();
	Casting cast;
	GameObject[] obj;
	GameObject Enemy;
	int counter=0;
	Vector3 positions;
	// Use this for initialization
	void Start () {
		//Spell spell = CreateSpell();
		//Debug.Log(spell.name);
		//Debug.Log(spell.spellType);
		//Debug.Log(spell.description);
		obj = GameObject.FindGameObjectsWithTag ("Enemy");

		Enemy = obj[counter];
		/*
		Debug.Log(obj[0]);
		Debug.Log(obj[1]);
		Debug.Log(obj[2].transform.position);

		for(int i =0; i>=obj.Length;i++){
			positions[i] = obj[i].transform.position;
		}
		Debug.Log(positions.Length);
		Debug.Log(positions[0]);
		Debug.Log(positions[1]);
		Debug.Log(positions[2]);
		*/
	}

	public void Update(){
		

	}

	public Spell CreateSpell(){

		/*spell.name = "Water";
	//	spell.spellType="liquid";
		spell.description="wet stuff";
*/
		if( spell is Buffer){
			Debug.Log("Buff");
			
		}else if( spell is Casting){
			Debug.Log("Casting");

		}

		return spell;
	}
}
