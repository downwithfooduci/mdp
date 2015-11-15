using UnityEngine;
using System.Collections;

public class LagreInstSub : MonoBehaviour {

	public LargeIntestGameManager lgm;
	public int WaterSubValue = 10;
	public bool subFlag;

	// Use this for initialization
	void Start () {
		lgm = FindObjectOfType (typeof(LargeIntestGameManager)) as LargeIntestGameManager;
		subFlag = false;
	}
	
	// Update is called once per frame

	/*
	void Update () {
	
	}
	*/

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("Entered");
		lgm.subwater (WaterSubValue);	

	}




}
