/// <summary>
/// Attack.
/// a list of available attacks
/// author : Kevin Harris
/// 22 october 2013
/// </summary>
using UnityEngine;
using System.Collections;

public class Attack : ModifiedStats
{
	new public int StartingExpCost= 22;
	// Use this for initialization
	public Attack()
	{
		ExpToLevel = StartingExpCost;
		IncreaseExperienceToLevel =1.5f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

public enum AttackName{
	Attack,
	FireAttack,
	IceAttack,
	LightningAttack
}
