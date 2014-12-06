using UnityEngine;
using System.Collections;

public class StomachFoodBlob : MonoBehaviour 
{
	public Sprite[] wholeFood;
	public Sprite[] digestedFood;
	public GameObject parent;

	private Sprite wholeRepresentation;
	private Sprite digestedRepresentation;

	private float spawnLocation;

	int index = 6;

	// Use this for initialization
	void Start () 
	{
		index = Random.Range (0, 4);
		wholeRepresentation = wholeFood [index];
		digestedRepresentation = digestedFood [index];

		spawnLocation = Random.Range (.5f * Screen.width, .85f * Screen.width);
		parent.transform.position = new Vector3 ((spawnLocation * 15f / Screen.width) - 7.5f, 
		                                         11f - (0f * 11f / Screen.height) - 5.5f, -2.0f);
		GetComponent<SpriteRenderer>().sprite = wholeRepresentation;

	}
}
