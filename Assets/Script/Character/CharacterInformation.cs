/// <summary>
/// Character information.cs
/// 
/// Title: Hack & Slash RPG - A Unity3D Game Engine Tutorial | BurgZerg Arcade. [Online].;
/// Author: Laliberte P. 
/// Date: 2013 October 24. 
/// Available from: http://www.burgzergarcade.com/hack-slash-rpg-unity3d-game-engine-tutorial
/// </summary>
using UnityEngine;
using System.Collections;
using System;

public class CharacterInformation : MonoBehaviour
{
	private string _name;
	private int _level;
	private uint _experience;
	public Attributes[] _primaryAttribute;
	public Vitals[] _vital;
	public Mana[] _mana;
	public Attack[] _attack;
	public Defence[] _defence;
	
	// Use this for initialization
	public void Awake ()
	{

		DontDestroyOnLoad(this);	
		
		_name = string.Empty;
		_level = 0;
		_experience = 0;

		_primaryAttribute = new Attributes[Enum.GetValues (typeof(AttributeName)).Length];
		_vital = new Vitals[Enum.GetValues(typeof(VitalName)).Length];
		_mana = new Mana[Enum.GetValues(typeof(ManaName)).Length];
		_attack=new Attack[Enum.GetValues(typeof(AttackName)).Length];
		_defence= new Defence[Enum.GetValues(typeof(DefenceName)).Length];
		
		
		SetupPrimaryAttributes();
		SetupVitals ();
		SetupMana ();
		SetupAttack ();
		SetupDefence ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public string Name {
		get{ return _name;}
		set{ _name = value;}
	}

	public int Level {
		get{ return _level;}
		set{ _level = value;}
	}
	
	public uint Experience {
		get{ return _experience;}
		set{ _experience = value;}
	}
	
	public void AddExp (uint exp)
	{
		_experience += exp;
		
	}
	
	private void SetupPrimaryAttributes ()
	{
		for (int cnt = 0; cnt <_primaryAttribute.Length; cnt++) {
			_primaryAttribute [cnt] = new Attributes ();
			_primaryAttribute [cnt].Name = ((AttributeName)cnt).ToString ();
		}
	}

	public void SetupVitals ()
	{
		for (int cnt = 0; cnt <_vital.Length; cnt++) {
			_vital [cnt] = new Vitals ();
			_vital[cnt].Name = ((VitalName)cnt).ToString();
		}
		
		SetupVitalsModifiers ();
	}

	private void SetupMana ()
	{
		for (int cnt = 0; cnt <_mana.Length; cnt++) {
			_mana [cnt] = new Mana ();
			_mana[cnt].Name = ((ManaName)cnt).ToString();
		}
		
		SetupManaModifier ();
	}

	private void SetupAttack ()
	{
		for (int cnt = 0; cnt <_attack.Length; cnt++) {
			_attack [cnt] = new Attack ();
			_attack [cnt].Name = ((AttackName)cnt).ToString();
		}
		
		SetupAttackModifier ();
	}

	private void SetupDefence ()
	{
		for (int cnt = 0; cnt <_defence.Length; cnt++) {
			_defence [cnt] = new Defence ();
			_defence [cnt].Name = ((DefenceName)cnt).ToString();
		}
		
		SetupDefenceModifier ();
	}
	
	public Attributes GetPrimaryAttribute (int index)
	{
		return _primaryAttribute [index];	
	}
	
	public Vitals GetVitals (int index)
	{
		return _vital [index];	
	}
	
	public Attack GetAttack (int index)
	{
		return _attack [index];	
	}

	public Mana GetMana (int index)
	{
		return _mana [index];	
	}

	public Defence GetDefence (int index)
	{
		return _defence [index];	
	}
	
	public void SetupVitalsModifiers ()
	{
		//health
		GetVitals ((int)VitalName.Health).AddModifier (new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Constitution), 10.5f));
		
		//energy
		GetVitals ((int)VitalName.Energy).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Constitution), 1.5f));
		
		//mana
		GetVitals ((int)VitalName.Mana).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.ManaPower), 2.5f));
		
	}
	
	public void SetupAttackModifier ()
	{
		//	Attack,
		GetAttack((int)AttackName.Attack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Strength), 1.5f*((int)AttributeName.Constitution)));
		//FireAttack,
		GetAttack((int)AttackName.FireAttack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Strength), 1*((int)AttributeName.Constitution)));
		GetAttack((int)AttackName.FireAttack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower), 1*((int)AttributeName.Constitution)));
		//IceAttack,
		
		GetAttack((int)AttackName.IceAttack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Strength), 1*((int)AttributeName.Constitution)));
		GetAttack((int)AttackName.IceAttack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower), 1f*((int)AttributeName.Constitution)));
		//LightningAttack
		
		GetAttack((int)AttackName.LightningAttack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Strength), 1.5f*((int)AttributeName.Constitution)));
		GetAttack((int)AttackName.LightningAttack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower), 1.5f*((int)AttributeName.Constitution)));
		
	}


	public void AddModifier(Attributes attrib, float numb){

	}
	
	
	public void SetupManaModifier ()
	{
		GetMana((int)ManaName.Fire).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower),.33f*(int)AttributeName.ManaPower));
		GetMana((int)ManaName.Fire).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaForce),.33f*(int)AttributeName.ManaPower));
		
		
		GetMana((int)ManaName.Ice).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower),.33f*(int)AttributeName.ManaPower));
		GetMana((int)ManaName.Ice).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaForce),.33f*(int)AttributeName.ManaPower));
		
		GetMana((int)ManaName.Lightning).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower),.33f*(int)AttributeName.ManaPower));
			GetMana((int)ManaName.Lightning).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaForce),.33f*(int)AttributeName.ManaPower));
		
		GetMana((int)ManaName.Water).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower),.33f*(int)AttributeName.ManaPower));
		GetMana((int)ManaName.Water).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaForce),.33f*(int)AttributeName.ManaPower));
		
		GetMana((int)ManaName.Wind).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower),.33f*(int)AttributeName.ManaPower));
		GetMana((int)ManaName.Wind).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaForce),.33f*(int)AttributeName.ManaPower));
		
	}
	
	public void SetupDefenceModifier ()
	{
		GetDefence((int)DefenceName.AttackDefence).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Strength),.33f*(int)VitalName.Energy));
		GetDefence((int)DefenceName.AttackDefence).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Concentration),.33f*(int)VitalName.Energy));
		
		GetDefence((int)DefenceName.ManaDefence).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower),.33f*(int)VitalName.Energy));
		GetDefence((int)DefenceName.ManaDefence).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Concentration),.33f*(int)VitalName.Energy));
	}
	
	public void StatUpdate ()
	{
		for (int cnt = 0; cnt < _vital.Length; cnt ++) {
			_vital [cnt].Update ();
		}
		for (int cnt = 0; cnt < _attack.Length; cnt ++) {
			_attack [cnt].Update ();
			
		}
		for (int cnt = 0; cnt < _defence.Length; cnt ++) {
			_defence [cnt].Update ();
			
		}
		for (int cnt = 0; cnt < _mana.Length; cnt ++) {
			_mana [cnt].Update ();
			
		}
		
	}
	
	public int[] VitalUpdate ()
	{
		int[] numb = new int[_vital.Length];
		for (int cnt = 0; cnt < _vital.Length; cnt ++) {
			_vital [cnt].Update ();
			numb[cnt]=_vital [cnt].AdjustedBaseValue;
		}
		return numb;
	}
	
	public int[] AttackUpdate ()
	{
		int[] numb = new int[_attack.Length];
		for (int cnt = 0; cnt < _attack.Length; cnt ++) {
			_attack [cnt].Update ();
			numb[cnt]=_attack [cnt].AdjustedBaseValue;
		}
		return numb;
	}
	
	public int[] DefenceUpdate ()
	{
		int[] numb = new int[_defence.Length];
		for (int cnt = 0; cnt < _defence.Length; cnt ++) {
			_defence [cnt].Update ();
			numb[cnt]=_defence [cnt].AdjustedBaseValue;
		}
		return numb;
	}
	
	public int[] ManaUpdate ()
	{
		int[] numb = new int[_mana.Length];
		for (int cnt = 0; cnt < _mana.Length; cnt ++) {
			_mana [cnt].Update ();
			numb[cnt]=_mana [cnt].AdjustedBaseValue;
		}
		return numb;
		
	}


	
	private void CalculateModifiedBaseValue ()
	{
		
	}
}