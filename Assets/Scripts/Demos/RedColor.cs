using UnityEngine;
using System.Collections;

public class RedColor : MonoBehaviour {
	Color colorRed = Color.red;
	// Use this for initialization
	void Start () {
		this.renderer.material.color = colorRed;
	}
	void Update(){
			this.renderer.material.color = colorRed;
	}
}
