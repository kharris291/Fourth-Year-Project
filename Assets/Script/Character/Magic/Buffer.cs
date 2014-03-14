using UnityEngine;
using System.Collections;

public class Buffer : Spell, BufferInterface {
	#region BufferInterface implementation

	public int buffVal {
		get; set;
	}

	public float buffTimer {
		get; set;
	}
	
	public float buffTimerRemaining{get;private set;}

	public Buffer(){
		buffVal=0;
		buffTimer=120;
		buffTimerRemaining=0;
	}

	#endregion



}
