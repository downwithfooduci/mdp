using UnityEngine;
using System.Collections;

public class StomachFoodBlob : MonoBehaviour 
{
	public Texture[] wholeFood;
	public Texture[] digestedFood;

	private Texture wholeRepresentation;
	private Texture digestedRepresentation;

	private float spawnLocation;
	private float yLocation = 0f;

	int index = 6;

	// Use this for initialization
	void Start () 
	{
		index = Random.Range (0, 4);
		Debug.Log (index);
		wholeRepresentation = wholeFood [index];
		digestedRepresentation = digestedFood [index];

		spawnLocation = Random.Range (.4f * Screen.width, .85f * Screen.width);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (yLocation < .9f * Screen.height)
		{
			yLocation += Time.deltaTime * 50;
		}
	}

	void OnGUI()
	{
		GUI.depth -= 30;
		GUI.DrawTexture (new Rect (spawnLocation, Mathf.Min(yLocation, .75f * Screen.height), 
		                           .1875f * Screen.width, .255f * Screen.height), wholeRepresentation);
	}
}
