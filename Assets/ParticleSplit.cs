using UnityEngine;
using System.Collections;

public class ParticleSplit : MonoBehaviour {
	public GameObject child1;
	public GameObject child2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Split()
	{
		Debug.Log("SPLITTING");
		foreach(Transform child in transform)
		{
			GameObject toCreate = child.gameObject.name == child1.gameObject.name ? child1 : child2;
			GameObject created = (GameObject)Instantiate(toCreate, 
				transform.position,
				transform.rotation);
			created.renderer.material.color = child.gameObject.renderer.material.color;
			created.rigidbody.velocity = Vector3.zero;
			created.rigidbody.AddForce(created.transform.right * (10 * child.position.x), ForceMode.Impulse);
		}
	}
}
