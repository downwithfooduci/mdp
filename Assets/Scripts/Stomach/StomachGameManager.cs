using UnityEngine;
using System.Collections;

// script to handle managing general game function coordination for the stomach game
public class StomachGameManager : MonoBehaviour 
{
	public GameObject stomachCellPrefab;

	private GameObject cell1;				// temp to hold one of the cells
	private GameObject cell2;				// tempt to hold the script to the second cell

	// Use this for initialization
	void Start () 
	{
		cell1 = (GameObject)Instantiate (stomachCellPrefab);
		cell1.GetComponent<StomachEnzyme> ().setActivated (true);
		cell1.GetComponent<StomachEnzyme> ().setDrawLocation (516f, 212f);

		cell2 = (GameObject)Instantiate (stomachCellPrefab);
		cell2.GetComponent<StomachEnzyme> ().setActivated (false);
		cell2.GetComponent<StomachEnzyme> ().setDrawLocation (759f, 195f);
	}
	
	// Update is called once per frame
	void Update () {}
}
