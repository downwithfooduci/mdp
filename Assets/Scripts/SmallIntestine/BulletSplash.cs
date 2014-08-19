using UnityEngine;
using System.Collections;

// class that just handles cleanup of the bullet splash
public class BulletSplash : MonoBehaviour 
{
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () 
	{
        Destroy(gameObject);
	}
}
