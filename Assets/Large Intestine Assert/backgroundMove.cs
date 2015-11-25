using UnityEngine;
using System.Collections;

public class backgroundMove : MonoBehaviour {
	public Rigidbody2D rb;
	private float x;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		x = rb.position.x;
		if (x > (182.5f-30.8425f))
			rb.velocity = new Vector2 (-3, 0);
		else
			rb.position = new Vector2 ((182.5f+30.8425f), 137f);
	}
}
