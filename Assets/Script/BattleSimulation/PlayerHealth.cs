using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour
{
	public int maxHealth = 100;
	public int curHealth = 100;
	private Texture3D bgImage;
	private Texture3D fgImage;
	private float healthBarLength,healthBarLength1;

	// Use this for initialization
	void Start ()
	{   
		healthBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update ()
	{
		AddjustCurrentHealth (0);
	}
	
	void OnGUI ()
	{
		GUI.Box(new Rect(Screen.width/2+150,Screen.height-100,healthBarLength,20),"");
		GUI.Box(new Rect(Screen.width/2+150,Screen.height-100,healthBarLength1,20),curHealth+"/"+maxHealth);
	}
	
	public void AddjustCurrentHealth (int adj)
	{
		
		curHealth += adj;
		
		if (curHealth < 0)
			curHealth = 0;
		
		if (curHealth > maxHealth)
			curHealth = maxHealth;
		
		if (maxHealth < 1)
			maxHealth = 1;
		
		healthBarLength = (Screen.width / 4) * (curHealth / (float)maxHealth);
		healthBarLength1 = (Screen.width / 4);
	}
}