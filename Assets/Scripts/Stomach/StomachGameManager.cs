using UnityEngine;
using System.Collections;

// script to handle managing general game function coordination for the stomach game
public class StomachGameManager : MonoBehaviour 
{
	public GameObject stomachCellPrefab;

	private GameObject cell1;				// temp to hold one of the cells

	// Use this for initialization
	void Start () 
	{
		cell1 = (GameObject)Instantiate (stomachCellPrefab);
		cell1.GetComponent<StomachEnzyme> ().setActivated (false);
		cell1.GetComponent<StomachEnzyme> ().setDrawLocation (700f, 600f);
	}
	
	// Update is called once per frame
	void Update () {}
}
