using UnityEngine;
using System.Collections;

public class StomachCell : MonoBehaviour 
{
	public Texture[] cellStateImages;
	public Texture[] cellFaces;

	CellButtons menu;

	// Use this for initialization
	void Start () 
	{
		menu.initializeMenu ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
