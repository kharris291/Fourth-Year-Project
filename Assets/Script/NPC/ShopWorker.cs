using UnityEngine;
using System.Collections;

public class ShopWorker : MonoBehaviour {
	
	private bool ShopMenu;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		animation.Play("idle");


		if ((Input.GetKeyUp("Fire1"))&&(ShopMenu==true)){
			Debug.Log("hello");
//			paused = TooglePausedScreen();
		}
	}

	void OnTriggerEnter (Collider playerInRange)
	{
		if (playerInRange.gameObject.tag == "Player") {
			ShopMenu = true;
		}
	}
	
	void OnTriggerExit (Collider playerNotInRange)
	{
		if (playerNotInRange.gameObject.tag == "Player") {
			ShopMenu = false;
		}
	}
}
