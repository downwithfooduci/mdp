using UnityEngine;
using System.Collections;

public class BulletSplash : MonoBehaviour {

    public float Radius;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject);
	}
}
