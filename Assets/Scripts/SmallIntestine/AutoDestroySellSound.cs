using UnityEngine;
using System.Collections;

/*
 * Destroy a sell sound object after it is finished playing
 * */
public class AutoDestroySellSound : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
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
