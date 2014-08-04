using UnityEngine;
using System.Collections;

public class GlowSegment : MonoBehaviour 
{
	public GameObject cube;
	private GameObject instantiatedCube;

	// use to get the name of the current segment to find the correct material
	private string segmentName;
	private string segmentCode;

	public float dieTime;
	private float elapsedTime;

	// Use this for initialization
	void Start () 
	{
		Debug.Log (gameObject.transform.position);
		segmentName = transform.gameObject.name;
		segmentCode = segmentName.Substring (segmentName.Length - 3, 3);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (instantiatedCube != null)
		{
			elapsedTime += Time.deltaTime;
			if (elapsedTime > dieTime)
			{
				Destroy(instantiatedCube.gameObject);
				elapsedTime = 0f;
			}
		}
	}

	public IEnumerator onTouch()
	{
		Material glowMaterial = null;

		if (instantiatedCube == null)
		{
			instantiatedCube = (GameObject)Instantiate (cube);

			if (Application.loadedLevelName.Contains("Odd"))
			{
				glowMaterial = (Material)Resources.Load ("Glow/Odd/OddSIGlowMask" + segmentCode, typeof(Material));
				yield return glowMaterial;
			} else if (Application.loadedLevelName.Contains("Even"))
			{
				glowMaterial = (Material)Resources.Load ("Glow/Even/EvenSIGlowMask" + segmentCode, typeof(Material));
				yield return glowMaterial;
			}

			instantiatedCube.renderer.material = glowMaterial;
		}
	}
}
