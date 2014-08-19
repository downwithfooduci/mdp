using UnityEngine;
using System.Collections;

// script that is attached to glow segments that makes them appear to glow
public class GlowSegment : MonoBehaviour 
{
	public GameObject cube;					// holds a cube object to attach a texture to
	private GameObject instantiatedCube;	// temporarily holds the cube when instantiated with a texture on it

	// use to get the name of the current segment to find the correct material
	// segments are named using a formula that is predictable and can therefore be easily parsed by the code
	private string segmentName;
	private string segmentCode;

	public float dieTime;			// the amount of time a segment should glow
	private float elapsedTime;		// to keep track of how long has passed

	// Use this for initialization
	void Start () 
	{
		segmentName = transform.gameObject.name;							// get the entire name of the glow segment
		segmentCode = segmentName.Substring (segmentName.Length - 3, 3);	// the code is the last 3 characters
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (instantiatedCube != null)					// if there is a cube instantiated
		{
			elapsedTime += Time.deltaTime;				// count the time elapsed
			if (elapsedTime > dieTime)					// if the time elapsed is greater than the glow time
			{
				Destroy(instantiatedCube.gameObject);	// destroy the cube
				elapsedTime = 0f;						// reset the elapsed time counter
			}
		}
	}

	// this function reads the texture from the hard drive asynchronously to avoid lag
	public IEnumerator onTouch()
	{
		Material glowMaterial = null;			// initialize the glow material to null

		if (instantiatedCube == null)			// if there is not a cube instantiated
		{
			instantiatedCube = (GameObject)Instantiate (cube);	// instantiate one

			// load the proper texture from the hard drive onto the cube
			// we load the texture asynchronously because the time to read off the hard drive is SLOW
			// if we do not do this asynchronously there is a HUGE performance degradation
			if (Application.loadedLevelName.Contains("Odd"))
			{
				glowMaterial = (Material)Resources.Load ("Glow/Odd/OddSIGlowMask" + segmentCode, typeof(Material));
				yield return glowMaterial;
			} else if (Application.loadedLevelName.Contains("Even"))
			{
				glowMaterial = (Material)Resources.Load ("Glow/Even/EvenSIGlowMask" + segmentCode, typeof(Material));
				yield return glowMaterial;
			} else if (Application.loadedLevelName.Contains("Tutorial"))
			{
				glowMaterial = (Material)Resources.Load ("Glow/Tutorial/TutorialSIGlowMask" + segmentCode, typeof(Material));
				yield return glowMaterial;
			}

			instantiatedCube.renderer.material = glowMaterial;	// attach the material onto the cube
		} else 		// if the segment is already glowing and clicked on again, refresh the timer
		{
			elapsedTime = 0f;
		}
	}
}
