using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
	ParticleSystem ps;
	void Start () {
		ps = this.particleSystem;
	}
	
	void Update () {
		if(ps)
		{
			if(!ps.IsAlive())
			{
				Destroy(this.gameObject);
			}
		}
	}
}
