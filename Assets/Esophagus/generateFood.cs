using UnityEngine;
using System.Collections;

public class generateFood : MonoBehaviour {
	public GameObject food;
	public Vector3 position;
	// Use this for initialization
	void Start () {
		position = new Vector3 (-4.691603f, 3.695416f, -.5f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(Screen.width  - (Screen.width * .12f), 
		                        Screen.height - (Screen.height * .06f),
		                        Screen.width * .12f,
		                        Screen.height * .06f), "Make Food"))
		{
			Instantiate(food, position, Quaternion.identity);
		}
	}
}
