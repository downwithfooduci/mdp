using UnityEngine;
using System.Collections;

// script to handle managing general game function coordination for the stomach game
public class EnzymeManager : MonoBehaviour 
{
	public GameObject stomachEnzymePrefab;

	private GameObject enzyme;				// temp to hold one of the cells

	// Use this for initialization
	void Start () 
	{
		enzyme = (GameObject)Instantiate (stomachEnzymePrefab);
		enzyme.GetComponent<StomachEnzyme> ().setActivated (false);
		enzyme.GetComponent<StomachEnzyme> ().setDrawLocation (700f, 600f);
	}
	
	// Update is called once per frame
	void Update () {}
}
