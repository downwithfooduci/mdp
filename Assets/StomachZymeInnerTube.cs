using UnityEngine;
using System.Collections;

public class StomachZymeInnerTube : MonoBehaviour 
{
	private SpriteRenderer sr;

	// Use this for initialization
	void Start () 
	{
		sr = GetComponent<SpriteRenderer> ();

		sr.transform.position= new Vector3 (((282f / 1024f * Screen.width) * 15f / Screen.width) - 7.5f, 
		                                    (88f / 768f * Screen.height) - 5.5f, -2.0f);
	}
}
