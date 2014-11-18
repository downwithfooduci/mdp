using UnityEngine;
using System.Collections;

public class StomachFoodBlob : MonoBehaviour 
{
	public Texture[] wholeFood;
	public Texture[] digestedFood;
	public GameObject parent;

	private Texture wholeRepresentation;
	private Texture digestedRepresentation;

	private float spawnLocation;
	private float yLocation = 0f;
	private bool move = true;

	int index = 6;

	// Use this for initialization
	void Start () 
	{
				index = Random.Range (0, 4);
		wholeRepresentation = wholeFood [index];
		digestedRepresentation = digestedFood [index];

		spawnLocation = Random.Range (.4f * Screen.width, .85f * Screen.width);
		parent.transform.position = new Vector3 ((spawnLocation * 15f / Screen.width) - 7.5f, 
		                                         11f - (yLocation * 11f / Screen.height) - 5.5f, 0f);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log ("stuff");
		move = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (move && yLocation < .9f * Screen.height)
		{
			yLocation += Time.deltaTime * 50;
			parent.transform.position = new Vector3 ((spawnLocation * 15f / Screen.width) - 7.5f, 
			                                         11f - (yLocation * 11f / Screen.height) - 5.5f, 0f);
		}
	}

	void OnGUI()
	{
		GUI.depth -= 30;
		GUI.DrawTexture (new Rect (spawnLocation, Mathf.Min(yLocation, .75f * Screen.height), 
		                           .1875f * Screen.width, .255f * Screen.height), wholeRepresentation);
	}
}
