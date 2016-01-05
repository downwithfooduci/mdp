using UnityEngine;
using System.Collections;

public class backgroundMove : MonoBehaviour {
	public Rigidbody2D rb;
	private float x;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
//		Debug.Log (rb.position.x);
	}
	
	// Update is called once per frame
	void Update () {
		x = rb.position.x;
//		Debug.Log (rb.position);
		if (x > 239.4f)
			rb.velocity = new Vector2 (-3, 0);
		else {
			rb.position = new Vector2(rb.position.x+30.715f*2,rb.position.y);
			Debug.Log (rb.position);
		}
	}
}
