/// <summary>
/// Mana.
/// a list of available magic powers
/// 
/// Title: Hack & Slash RPG - A Unity3D Game Engine Tutorial | BurgZerg Arcade. [Online].;
/// Author: Laliberte P. 
/// Date: 2013 October 24. 
/// Available from: http://www.burgzergarcade.com/hack-slash-rpg-unity3d-game-engine-tutorial
/// </summary>
using UnityEngine;
using System.Collections;
using System;
public class Mana : ModifiedStats
{
	// create a new instance of the starting exp cost.
	//sets up the starting strength
	new public const int StartingExpCost = 20;
	
	/// <summary>
	/// Start this instance.
	// used to increase the strength of the characters magic
	//when leveled up
	/// </summary>
	void Start ()
	{
		ExpToLevel = StartingExpCost;
		IncreaseExperienceToLevel = 1.1f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
/// <summary>
/// Mana name.
/// list of all the different types of magic that can be used
/// </summary>
public enum ManaName{
	Fire,
	Wind,
	Water,
	Ice,
	Lightning

}

