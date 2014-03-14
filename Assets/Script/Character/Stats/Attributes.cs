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