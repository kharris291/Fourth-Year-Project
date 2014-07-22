/// <summary>
/// Attributes.cs
/// a class for the character attributes
/// 
/// Title: Hack & Slash RPG - A Unity3D Game Engine Tutorial | BurgZerg Arcade. [Online].;
/// Author: Laliberte P. 
/// Date: 2013 October 24. 
/// Available from: http://www.burgzergarcade.com/hack-slash-rpg-unity3d-game-engine-tutorial
/// </summary>
using UnityEngine;
using System.Collections;

public class Attributes : ModifiedStats
{
	new public int StartingExpCost= 22;

	void Start ()
	{
		ExpToLevel = StartingExpCost;
		IncreaseExperienceToLevel =1.5f;
	}

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