/// <summary>
/// Vitals.
/// a class that will be used to hold the characters vitals
/// 
/// Title: Hack & Slash RPG - A Unity3D Game Engine Tutorial | BurgZerg Arcade. [Online].;
/// Author: Laliberte P. 
/// Date: 2013 October 24. 
/// Available from: http://www.burgzergarcade.com/hack-slash-rpg-unity3d-game-engine-tutorial
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vitals : ModifiedStats
{
	private int _curValue;
	private Vitals[] vit;
	private Attributes attrib;
	private float val;
	public Vitals(){
		_curValue =0;
		ExpToLevel = 40;
		increaseExperienceToLevel = 1.1f;
		
		
	}
	
}

public enum VitalName{
	Health,
	Energy,
	Mana
}