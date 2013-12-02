/// <summary>
/// Basic stats.
///  a class for gereral stats for use on all characters.
///  this will house getters and setters for values that will be
///  used throughout the project
/// author : Kevin Harris
/// 22 october 2013
/// </summary>
using UnityEngine;
using System.Collections;

public class BasicStats : MonoBehaviour
{
	
	/* 
	 * a class for gereral stats for use on all characters.
	 * this will house getters and setters for values that will be
	 * used throughout the project
	 * 
	 * 
	 */
	public const int StartingExpCost = 100;
	
	private int baseValue,buffValue,expToLevel;
	public float increaseExperienceToLevel;
	
	private string name;
	
	// Use this for initialization
	void Start ()
	{
		baseValue=0;
		buffValue=0;
		expToLevel =StartingExpCost;
		increaseExperienceToLevel=1.4f;
		name = string.Empty;
	}
	
	// Update is called once per frame
	public void Update ()
	{
	
	}

	public int BaseValue {
		get {
			return this.baseValue;
		}
		set {
			baseValue = value;
		}
	}

	public int BuffValue {
		get {
			return this.buffValue;
		}
		set {
			buffValue = value;
		}
	}
	public int ExpToLevel {
		get {
			return this.expToLevel;
		}
		set {
			expToLevel = value;
		}
	}

	public float IncreaseExperienceToLevel {
		get {
			return this.increaseExperienceToLevel;
		}
		set {
			increaseExperienceToLevel = value;
		}
	}

	public string Name {
		get {
			return this.name;
		}
		set {
			name = value;
		}
	}
	
	public int CalculateExperienceForLevelUp(){
		return	(int)(expToLevel *increaseExperienceToLevel);
	}
	
	public void CharacterLevelUp(){
		CalculateExperienceForLevelUp();
		
		baseValue++;
	}
	
	public int AdjustedBaseValue {
		get {
			return BaseValue + buffValue;	
		}
	}
}

