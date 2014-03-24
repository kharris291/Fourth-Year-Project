/// <summary>
/// Open door.cs
/// Author: Harris Kevin
/// Date: 2013 October 24. 
/// Opens the Gate to the village.
/// </summary>
using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour
{
	private Vector3 startingPos, rotationAngle;
	private int doorOpenCheck, rangeCheck;
	private bool opendoor;
	// Use this for initialization
	void Start ()
	{
		this.startingPos = Vector3.zero;
		this.rotationAngle = new Vector3 (startingPos.x, startingPos.y + 90, startingPos.z);
		this.doorOpenCheck = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if ((Input.GetButtonDown ("Fire1"))&&(opendoor))  {
			this.animation.Play ("openDoor");
			doorOpenCheck = 1;
		}
		
		if ((Input.GetButtonDown ("Fire1"))&&(!opendoor)) {
			if((rangeCheck==1)&&(doorOpenCheck==1)){
				this.animation.Play ("closeDoor");
				doorOpenCheck = 0;
			}
		}
		
		if ((Input.GetButtonDown ("Fire1"))&&(rangeCheck == 1)) {
			if (doorOpenCheck == 0) {
				opendoor = true;
			} else {
				opendoor = false;
			}
		}
		
	}
	
	void OnGUI(){
		if(rangeCheck==1){
			if(opendoor==true){
				GUI.Label(new Rect(0,0, 200,30),"Press O to open");
			}
			
			if(opendoor==false){
				GUI.Label(new Rect(0,0, 200,30),"Press O to close");
			}
		}else{
			GUI.Label(new Rect(0,0, 20,10),"");
		}
	}
	
	void OnTriggerEnter(Collider playerInRange){
		if(playerInRange.gameObject.tag=="Player"){
			this.opendoor = true;
			if(doorOpenCheck==1){
				this.opendoor = true;
			}
			rangeCheck = 1;	
		}
	}
	void OnTriggerExit(Collider playerNotInRange){
		if(playerNotInRange.gameObject.tag=="Player"){
			rangeCheck = 0;	
		}
	}

}