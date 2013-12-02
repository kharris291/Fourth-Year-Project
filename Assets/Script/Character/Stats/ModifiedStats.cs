/// <summary>
/// Modified stat.cs
/// 3rd oct
/// Kevin
/// 
/// base class for all stats being modified by attribs
/// </summary>
using System.Collections.Generic;					// added to use a List<>

public class ModifiedStats : BasicStats
{
	private List<ModifyingAttribute> _mods;			// a list of attribs that modify this stat
	private int _modValue;							// the amount added to the base value of the modifiers
	
	/// <summary>
	/// Initializes a new instance of the <see cref="ModifiedStats"/> class.
	/// </summary>
	public ModifiedStats ()
	{
		_mods = new List<ModifyingAttribute> ();
		_modValue = 0;
	}
	/// <summary>
	/// Adds the modifier to the mods list.
	/// </summary>
	/// <param name='mod'>
	/// Mod.
	/// </param>
	public void AddModifier (ModifyingAttribute mod)
	{
		_mods.Add (mod);
		
	}
	/// <summary>
	/// Calculates the mod value.
	/// </summary>
	private void CalculateModValue ()
	{
		_modValue = 0;
		
		if (_mods.Count > 0) {
			foreach (ModifyingAttribute att in _mods) {
				_modValue += (int)(att.attribute.AdjustedBaseValue * att.ratio);	
			}
		}
	}
	/// <summary>
	/// Gets the adjusted base value.
	/// </summary>
	/// <value>
	/// The adjusted base value.
	/// </value>
	public new int AdjustedBaseValue {
		get {
			return BaseValue + BuffValue + _modValue;	
		}
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update ()
	{
		CalculateModValue ();
	}
	/// <summary>
	/// Gets the modifying attribute string.
	/// </summary>
	/// <returns>
	/// The modifying attribute string.
	/// </returns>
	public string GetModifyingAttributeString ()
	{
		string temp="";
		
		//itterate through the list
		for (int it =0; it <_mods.Count; it ++) {
			temp+= _mods [it].attribute.Name+"_"+_mods [it].ratio;
			
			if(it < _mods.Count-1){
				temp+="|";	
			}
		}
		return temp;
	}
}
/// <summary>
/// Modifying attribute.
/// </summary>
public struct ModifyingAttribute
{
	public Attributes attribute;
	public float ratio;
	/// <summary>
	/// Initializes a new instance of the <see cref="ModifyingAttribute"/> struct.
	/// </summary>
	/// <param name='att'>
	/// Att.
	/// </param>
	/// <param name='rat'>
	/// Rat.
	/// </param>
	public ModifyingAttribute (Attributes att, float rat)
	{
		attribute = att;
		ratio = rat;
	}
}
