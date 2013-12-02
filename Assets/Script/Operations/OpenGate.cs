using UnityEngine;
using System.Collections;

public class OpenGate : MonoBehaviour
{

	private Vector3 startingPos, rotationAngle;
	private int gateStatusCheck, rangeCheck;
	private bool openGate, playOnce;
	// Use this for initialization
	void Start ()
	{
		startingPos = Vector3.zero;
		rotationAngle = new Vector3 (startingPos.x, startingPos.y + 90, startingPos.z);
		gateStatusCheck = 1;
		playOnce = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if ((Input.GetButtonDown ("Fire1")) && (openGate)) {
			if (rangeCheck == 1) {
				animation.Play ("openGate");
				gateStatusCheck = 1;
			}
		}
		if ((Input.GetButtonDown ("Fire1")) && (!openGate)) {
			if((rangeCheck==1)&&(gateStatusCheck==1)){
				animation.Play ("closeGate");
				gateStatusCheck = 0;
				
			}
			
		}
		if ((Input.GetButtonDown ("Fire1")) && (rangeCheck == 1)) {
			if (gateStatusCheck == 0) {
				openGate = true;
			}
		}
		
		if ((Input.GetButtonDown ("Fire1")) && (rangeCheck == 1)) {
			if (gateStatusCheck == 1) {
				
				openGate = false;
			}
		}
		
	}
	
	void OnGUI(){
		//GUIText open;		
		if(rangeCheck==1){
			if(openGate==true){
				GUI.Label(new Rect(0,0, 200,30),"Press O to open");
			}
			
			if(openGate==false){
				GUI.Label(new Rect(0,0, 200,30),"Press O to close");
			}
		}else{
			GUI.Label(new Rect(0,0, 20,10),"");
		}
	}
	
	void OnTriggerEnter (Collider playerInRange)
	{
		if (playerInRange.gameObject.tag == "Player") {
			this.openGate = true;
			if(gateStatusCheck==1){
				this.openGate = true;
			}
			rangeCheck = 1;	
		}
	}

	void OnTriggerExit (Collider playerNotInRange)
	{
		if (playerNotInRange.gameObject.tag == "Player") {
			rangeCheck = 0;	
			if(!playOnce){
				animation.Play ("closeGate");
				playOnce=true;
			}
			
		}
	}

}
