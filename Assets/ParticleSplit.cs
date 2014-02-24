using UnityEngine;
using System.Collections;

public class ParticleSplit : MonoBehaviour {
	public GameObject child1;
	public GameObject child2;
	private bool isSplit;
	// Use this for initialization
	void Start () {
		isSplit = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Split()
	{
		if(!isSplit)
		{
			isSplit = true;
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
}
