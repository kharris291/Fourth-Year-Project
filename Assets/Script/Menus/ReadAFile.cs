using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System;

public class ReadAFile : MonoBehaviour {

	private string line;
	private string[] entries;

	GameObject[] ga;
	GameObject ga2;

	private int counter=0, size = 0;
	private float distance = 10000;
	
	private int buttonWidth=200,
	buttonHeight = 50,
	groupWidth = 400,
	groupHeight = 230;
	
	public string[] _name,_id,_price;
	int strsize=6;
	void Awake(){
		_name =  new string[strsize];
		_id =  new string[strsize];
		_price = new string[strsize];

	}


	public bool Load(string fileName, string tag)
	{
		checkedtag(fileName);

		ga = GameObject.FindGameObjectsWithTag(tag);
		ga2 = GameObject.FindGameObjectWithTag("Player");
		int i = 0;

		do{
			if(Vector3.Distance(ga[i].transform.position,ga2.transform.position)<distance){
				distance = Vector3.Distance(ga[i].transform.position,ga2.transform.position);

				counter = i;
			}
			i++;
		}while(i < ga.Length);

		try
		{
			
			StreamReader theReader = new StreamReader(Application.dataPath + "/" + fileName, Encoding.Default);
			using (theReader)
			{
				do
				{
					line = theReader.ReadLine();

					if (line!=null)
					{
						entries = line.Split(',');
						if (entries.Length > 0){

							Additions(entries);
							//ga[counter].GetComponent<ReadAFile>().entries =line.Split(',');

							size++;
						}
					}
				}
				while (line != null);
				theReader.Close();
				return true;
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("{0}\n", e.Message);
			return false;
		}
	}

	void Additions(string[] arry){
		ga[counter].GetComponent<ReadAFile>()._name[size] = arry[0].ToString();
		ga[counter].GetComponent<ReadAFile>()._id[size] = arry[1].ToString();
		ga[counter].GetComponent<ReadAFile>()._price[size] = arry[2].ToString();

	}
	
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
