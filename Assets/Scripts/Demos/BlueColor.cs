using UnityEngine;
using System.Collections;

public class BlueColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.renderer.material.color = Color.blue;
	}
	void Update(){
		this.renderer.material.color = Color.blue;
	}
}
