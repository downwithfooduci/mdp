using UnityEngine;
using System.Collections;

public class LargeIntestGameManager : MonoBehaviour {

	public GameObject PlayerPoo;

	
	public  int WaterValue;




	// Use this for initialization
	void Start () {
		WaterValue = 100;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SubPlayerWater(){

	}

	public void subwater(int a){
		WaterValue = WaterValue - a;
	}
	
	public void addwater(int a){
		WaterValue = WaterValue + a;
	}
	
	public void fillwater(){
		WaterValue = 100;
	}

	public int getWaterValue(){
		return WaterValue; 
	}



}
