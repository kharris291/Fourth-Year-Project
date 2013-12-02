using UnityEngine;
using System.Collections;

public class Defence : ModifiedStats
{

	new public int StartingExpCost= 22;
	// Use this for initialization
	public Defence ()
	{
		ExpToLevel = StartingExpCost;
		IncreaseExperienceToLevel =1.5f;	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

public enum DefenceName{
	AttackDefence,
	ManaDefence
}