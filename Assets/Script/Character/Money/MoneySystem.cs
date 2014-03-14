using UnityEngine;
using System.Collections;

public class MoneySystem : MonoBehaviour {

	public int StartingMoney = 200;

	public int moneyAddition;
	public bool test;

	public MoneySystem(){
		moneyAddition = 200;
	}

	public void processMoney(string posNeg, int amount){

		if(posNeg =="plus"){
			moneyAddition +=amount;
			test =true;
		}
		if(posNeg =="minus"){
			moneyAddition -=amount;
			test =true;
			if(moneyAddition < -1){
				moneyAddition += amount;
				test = false;
			}
		}


	}

	public int StarterMoney(){
		return StartingMoney;
	}
}