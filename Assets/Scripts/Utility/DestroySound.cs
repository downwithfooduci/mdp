using UnityEngine;
using System.Collections;

/**
 * attach to a sound prefab to destroy it once it's done playing
 */
public class DestroySound : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		if (!audio.isPlaying) 
		{
			Destroy(this.gameObject);
		}
	}
}
