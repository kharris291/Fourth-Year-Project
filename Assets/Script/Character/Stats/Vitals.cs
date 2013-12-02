/// <summary>
/// Vitals.
/// a class that will be used to hold the characters vitals
/// author : Kevin Harris
/// 22 october 2013
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