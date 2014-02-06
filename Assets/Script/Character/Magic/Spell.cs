using UnityEngine;
using System.Collections;

public class Spell : SpellInerface
{
	#region SpellInerface implementation


		public Spell ()
		{
				name = "name";
				//GameObject spellType;
				description = "description";
		}

		public void Cast ()
		{
				throw new System.NotImplementedException ();
		}

		public string name {
		
				get;
				set;
		}

		public GameObject spellType {
				get;
				set;
		}

		public string description {
				get;
				set;
		}

	#endregion


}
