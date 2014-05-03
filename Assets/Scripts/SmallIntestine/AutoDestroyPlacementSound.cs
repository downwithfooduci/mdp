using UnityEngine;
using System.Collections;

/*
 * For destroying the object holding the tower placement sound
 * */
public class AutoDestroyPlacementSound : MonoBehaviour 
{

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
