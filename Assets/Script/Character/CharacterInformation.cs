/// <summary>
/// General information.
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
		}
		
		SetupVitalsModifiers ();
	}

	private void SetupMana ()
	{
		for (int cnt = 0; cnt <_mana.Length; cnt++) {
			_mana [cnt] = new Mana ();
		}
		
		SetupManaModifier ();
	}

	private void SetupAttack ()
	{
		for (int cnt = 0; cnt <_attack.Length; cnt++) {
			_attack [cnt] = new Attack ();
		}
		
		SetupAttackModifier ();
	}

	private void SetupDefence ()
	{
		for (int cnt = 0; cnt <_defence.Length; cnt++) {
			_defence [cnt] = new Defence ();
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
		GetVitals ((int)VitalName.Health).AddModifier (new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Constitution), .5f));
		
		//energy
		GetVitals ((int)VitalName.Energy).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Constitution), 1));
		
		//mana
		GetVitals ((int)VitalName.Mana).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.ManaPower), 1));
		
	}
	
	private void SetupAttackModifier ()
	{
		//	Attack,
		GetAttack((int)AttackName.Attack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Strength), .5f));
		//FireAttack,
		GetAttack((int)AttackName.FireAttack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Strength), .5f));
		GetAttack((int)AttackName.FireAttack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower), .5f));
		//IceAttack,
		
		GetAttack((int)AttackName.IceAttack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Strength), .5f));
		GetAttack((int)AttackName.IceAttack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower), .5f));
		//LightningAttack
		
		GetAttack((int)AttackName.LightningAttack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Strength), .5f));
		GetAttack((int)AttackName.LightningAttack).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower), .5f));
		
	}
	/*
	
	public void AddModifier(Attributes attrib, float numb){
		Debug.Log(attrib + "|" +numb);
	}*/
	
	
	private void SetupManaModifier ()
	{
		GetMana((int)ManaName.Fire).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower),.33f));
		GetMana((int)ManaName.Fire).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaForce),.33f));
		
		
		GetMana((int)ManaName.Ice).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower),.33f));
		GetMana((int)ManaName.Ice).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaForce),.33f));
		
		GetMana((int)ManaName.Lightning).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower),.33f));
		GetMana((int)ManaName.Lightning).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaForce),.33f));
		
		GetMana((int)ManaName.Water).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower),.33f));
		GetMana((int)ManaName.Water).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaForce),.33f));
		
		GetMana((int)ManaName.Wind).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower),.33f));
		GetMana((int)ManaName.Wind).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaForce),.33f));
		
	}
	
	public void SetupDefenceModifier ()
	{
		GetDefence((int)DefenceName.AttackDefence).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Strength),.33f));
		GetDefence((int)DefenceName.AttackDefence).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Concentration),.33f));
		
		GetDefence((int)DefenceName.ManaDefence).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.ManaPower),.33f));
		GetDefence((int)DefenceName.ManaDefence).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Concentration),.33f));
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
		
		Debug.Log (_vital.Length + "|" + _attack.Length + "|" + _defence.Length + "|" + _mana.Length);
	}
	
	private void CalculateModifiedBaseValue ()
	{
		
	}
}