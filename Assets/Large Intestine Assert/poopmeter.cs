using UnityEngine;
using System.Collections;

public class poopmeter : MonoBehaviour {

    private float xposition;
    private float yposition;

    public float speed;

	// Use this for initialization
	void Start () {
        xposition = transform.position.x;
        yposition = transform.position.y;
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void setPosition(int water)
    {
        float step = speed * Time.deltaTime;
        xposition = water * 10;
        Vector2 newposition = new Vector2(xposition, yposition);
        transform.position = Vector2.MoveTowards(transform.position, newposition, step);
    }
}
