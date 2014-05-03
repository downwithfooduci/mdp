using UnityEngine;
using System.Collections;

/*
 * For destroying the object with the nutrient lost sound
 * */
public class AutoDestroyNutrientLostSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!audio.isPlaying)
		{
			Destroy (this.gameObject);
		}
	}
}
