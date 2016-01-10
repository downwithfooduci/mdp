using UnityEngine;
using System.Collections;

public class LargeIntestGameManager : MonoBehaviour {

	public GameObject PlayerPoo;

	
	public  int WaterValue;

    private float bacteriaTimer;
    private int bacTouched;         //0 = not, 1 = touched

    public float CloseTimer;          //Time to Close suctions

    private poopmeter pm;



    // Use this for initialization
    void Start () {
        pm = FindObjectOfType(typeof(poopmeter))as poopmeter;
		WaterValue = 100;
        bacTouched = 0;
        bacteriaTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(bacTouched == 1)
        {
            bacteriaTimer = bacteriaTimer + Time.deltaTime;
            Debug.Log("Touched, time=");
            Debug.Log(bacteriaTimer);

        }
        if(bacteriaTimer > CloseTimer)
        {
            bacteriaTimer = 0;
            bacTouched = 0;
        }
        pm.setPosition(WaterValue);
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
        bacTouched = 1;
    }

	public int getWaterValue(){
		return WaterValue; 
	}

    public int getBacTouched()
    {
        return bacTouched;
    }




}
