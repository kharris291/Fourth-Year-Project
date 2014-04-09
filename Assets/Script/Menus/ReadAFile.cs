/// <summary>
/// Read A file.cs
/// Author: Harris Kevin 
/// Date: 2013 October 24. 
/// Read a file into location. makes sure what Shop keeper is being targeted
/// </summary>
using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System;

public class ReadAFile : MonoBehaviour {
	
	private string lineFromFile;
	private string[] partsFromFile;
	
	GameObject[] targetObject;
	GameObject playerObject;
	
	private int counter=0, size = 0;
	private float distance = 10000;
	
	private int buttonWidth=200,
	buttonHeight = 50,
	groupWidth = 400,
	groupHeight = 230;
	string[] items;
	public string[] _name,_id,_price;
	int strsize=6;
	void Awake(){
		_name =  new string[strsize];
		_id =  new string[strsize];
		_price = new string[strsize];
		
	}
	
	int check =0;
	/// <summary>
	/// Load the specified fileName 
	 /// tag hecks for the correct shop keeper.
	/// </summary>
	/// <param name="fileName">File name.</param>
	/// <param name="tag">Tag.</param>
	public bool Load(string fileName, string tag)
	{
		checkedtag(fileName);
		
		targetObject = GameObject.FindGameObjectsWithTag(tag);
		playerObject = GameObject.FindGameObjectWithTag("Player");
		int i = 0;
		
		do{
			if(Vector3.Distance(targetObject[i].transform.position,playerObject.transform.position)<distance){
				distance = Vector3.Distance(targetObject[i].transform.position,playerObject.transform.position);
				counter = i;
			}
			i++;
		}while(i < targetObject.Length);
		
		try
		{
			/// <summary>
			/// author: Matthias Worch
			/// source: http://answers.unity3d.com/questions/279750/loading-data-from-a-txt-file-c.html
			/// idea seen and modified for a different form of use
			/// </summary>
			Debug.Log(fileName);
			StreamReader fileReader = new StreamReader(Application.dataPath + "/" + fileName, Encoding.Default);
			using (fileReader)
			{
				do
				{
					lineFromFile = fileReader.ReadLine();
					
					if (lineFromFile!=null)
					{
						partsFromFile = lineFromFile.Split(',');
						if (partsFromFile.Length > 0){
							
							Additions(partsFromFile);
							
							size++;
						}
					}
				}
				while (lineFromFile != null);
				fileReader.Close();
				check=0;
				return true;
				
			}
			
		}
		catch (Exception e)
		{
			
			
			if(fileName =="magic.txt"){
				items = new string[3];
				items[0] = "key,Key To boss,20000";
				items[1] = "teleport,Brings you to Hometown ,500";
				items[2] = "escape,Escape a battle,1000";
				File.Create(Application.dataPath + "/" + fileName);
				
				
				File.WriteAllLines(Application.dataPath+"/"+fileName, items);
				for(int count =0; count <= items.Length; count ++){
					string[] addCheck = items[count].Split(',');
					if(count >0){
						size++;
					}
					Additions(addCheck);	
				}
				return true;
				//Load(fileName, tag);
			}
			if(fileName =="items.txt"){
				items = new string[4];
				items[0] = "potion,100,200";
				items[1] = "hi-potion,200,500";
				items[2] = "revive,50,1000";
				items[3] = "super-revive,200,3000";
				File.Create(Application.dataPath + "/" + fileName);
				
				File.WriteAllLines(Application.dataPath+"/"+fileName, items);
				check = 1;
				for(int count =0; count <= items.Length; count ++){
					string[] addCheck = items[count].Split(',');
					if(count >0){
						size++;
					}
					Additions(addCheck);	
				}
				return true;
			}
			if(fileName =="weapons.txt"){
				items = new string[6];
				items[0] = "knife,100,100";
				items[1] = "hunting-knife,100,150";
				items[2] = "sword,200,500";
				items[3] = "ripper,50,1000";
				items[4] = "bone-sword,200,3000";
				items[5] = "animal-sword,100,3000";
				File.Create(Application.dataPath + "/" + fileName);
				
				File.WriteAllLines(Application.dataPath+"/"+fileName, items);
				for(int count =0; count <= items.Length; count ++){
					string[] addCheck = items[count].Split(',');
					if(count >0){
						size++;
					}
					Additions(addCheck);	
				}
				return true;
			}
			
			return false;
		}
	}
	
	void Additions(string[] arry){
		targetObject[counter].GetComponent<ReadAFile>()._name[size] = arry[0].ToString();
		targetObject[counter].GetComponent<ReadAFile>()._id[size] = arry[1].ToString();
		targetObject[counter].GetComponent<ReadAFile>()._price[size] = arry[2].ToString();
		
	}
	/// <summary>
	/// Checkedtag the specified fileNameCheck.
	/// </summary>
	/// <param name="fileNameCheck">File name check.</param>
	void checkedtag(string fileNameCheck){
		if(fileNameCheck=="items.txt"){
			strsize=4;
		}
		
		if(fileNameCheck=="magic.txt"){
			strsize=3;
		}
		if(fileNameCheck=="weapons.txt"){
			strsize=6;
		}
		_name =  new string[strsize];
		_id =  new string[strsize];
		_price = new string[strsize];
	}
	
}
