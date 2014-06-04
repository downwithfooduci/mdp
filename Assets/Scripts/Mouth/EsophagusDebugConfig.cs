﻿using UnityEngine;
using System.Collections;

public class EsophagusDebugConfig : MonoBehaviour 
{
	public float oxygenDeplete = .05f;
	public float oxygenGain = .05f;
	//	public float stomachDeplete = .005f; 	// TODO: UNUSED
	//	public float stomachGain = .075f; 		// TODO: UNUSED
	//	public int maxLostFoodAmount = 10; 		// TODO: UNUSED
	public bool debugActive = false;
	public float foodSpawnInterval = .5f;
	public float waveDelay = 1f;
	public float waveTime = 5f;
	public float foodSpeed = 3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
