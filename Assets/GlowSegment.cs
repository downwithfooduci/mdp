using UnityEngine;
using System.Collections;

public class GlowSegment : MonoBehaviour 
{
	public GameObject cube;
	public Material glowMask;
	private GameObject instantiatedCube;

	public float dieTime;
	private float elapsedTime;

	// Use this for initialization
	void Start () 
	{
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

	public void onTouch()
	{
		if (instantiatedCube == null)
		{
			instantiatedCube = (GameObject)Instantiate (cube);
			instantiatedCube.renderer.material = glowMask;
		}
	}
}
