using UnityEngine;
using System.Collections;

public class Casting : Spell,CastingInterface {
	#region CastingInterface implementation

	public float maxDmg {
		get;set;
	}

	public float dmgVariance {
		get;set;
	}

	public Vector3 enemyPosition {
		get;set;
	}

	#endregion

	public Casting(){
		maxDmg=0;
		dmgVariance=0.2f;
		enemyPosition= new Vector3(100,5,300);
	}
}
