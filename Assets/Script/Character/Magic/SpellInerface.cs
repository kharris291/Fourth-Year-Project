using UnityEngine;

public interface SpellInerface
{
		string name{ get; set; }

		GameObject spellType{ get; set; }

		string description{ get; set; }

		void Cast ();
}