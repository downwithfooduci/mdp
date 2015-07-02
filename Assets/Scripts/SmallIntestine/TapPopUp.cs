using UnityEngine;
using System.Collections;

/**
 * script to handle pop up window for the si game
 */
public class TapPopUp : MonoBehaviour
{
	// pop up variables
	private bool popup;							//!< flag to hold whether the pop up windows should show up
	private bool clicked;						//!< flag to check whether the player has clicked
	private Vector3 popUpPosition;				//!< to store the position of the pop up window should appear
	private int oldCount;						//!< to store the number of particles from the last time
	public Texture tapPopUp;					//!< to hold the texture of the pop up for tap

	void Start()
	{
		popup = false;
		clicked = false;
		oldCount = 0;
	}

	void Update()
	{
		// Count how many particles are in this round
		GameObject[] particles = GameObject.FindGameObjectsWithTag ("particle");
		int particlesCount = 0;
		foreach(GameObject particle in particles)
		{
			particlesCount++;
		}

		// If the particle decrease, means the user has clicked to absorb the particles
		if (oldCount > particlesCount)
		{
			clicked = true;
		}

		// If the number of particles are greater than 18 and the player have not clicked to absorb the nutrients, the pop up window should appear
		if (particlesCount > 18 && (!clicked))
		{
			popup = true;

			// Getting the position of the first particles in the array and convert into pixel position 
			GameObject particle = particles[0];
			Camera camera = GetComponent<Camera>();
			popUpPosition = camera.WorldToScreenPoint(particle.transform.position);
			Debug.Log ("x = "+popUpPosition.x+" y = "+popUpPosition.y+" z = "+popUpPosition.z);
		}
		else
		{
			popup = false;
		}

		oldCount = particlesCount;
	}

	void OnGUI()
	{
		if(popup)
		{
			GUI.DrawTexture (new Rect(popUpPosition.x,
			                          Screen.width - popUpPosition.y - 170,
				                      Screen.width * 0.2093359375f, 
				                      Screen.height * 0.300697917f),tapPopUp);
		}
	}
}
