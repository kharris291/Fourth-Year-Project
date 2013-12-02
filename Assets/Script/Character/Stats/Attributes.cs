/// <summary>
/// Attributes.cs
/// a class for the character attributes
/// author : Kevin Harris
/// 22 october 2013
/// </summary>
using UnityEngine;
using System.Collections;

public class Attributes : ModifiedStats
{
	new public int StartingExpCost= 22;
	// Use this for initialization
	void Start ()
	{
		ExpToLevel = StartingExpCost;
		IncreaseExperienceToLevel =1.5f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

public enum AttributeName
{
	Strength,
	Constitution,
	Speed,
	ManaPower,
	ManaForce,
	Concentration
}