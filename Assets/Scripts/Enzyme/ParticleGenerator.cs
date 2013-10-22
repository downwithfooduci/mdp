using UnityEngine;
using System.Collections;

public class ParticleGenerator : MonoBehaviour
{
	
	public GameObject parentCylCyl;
	public GameObject parentCylCap;
	public GameObject parentCylSphere;
	public GameObject parentSphereSphere;
	public GameObject parentSphereCyl;
	public GameObject parentSphereCap;
	public GameObject parentCapCap;
	public GameObject parentCapCyl;
	public GameObject parentCapSphere;
	
	public int numSpawn;
	Color[] colors;
	GameObject[] parents;

	// Use this for initialization
	void Start ()
	{
		colors = new Color[5];
		colors [0] = Color.red;
		colors [1] = Color.blue;
		colors [2] = Color.yellow;
		colors [3] = Color.green;
		colors [4] = Color.white;
		parents = new GameObject[9];
		parents[0] = parentCylCyl;
		parents[1] = parentCylCap;
		parents[2] = parentCylSphere;
		parents[3] = parentSphereSphere;
		parents[4] = parentSphereCyl;
		parents[5] = parentSphereCap;
		parents[6] = parentCapCap;
		parents[7] = parentCapCyl;
		parents[8] = parentCapSphere;
		
		for (int i = 0; i<numSpawn; i++) {
			GameObject spawn = (GameObject)Instantiate (parents [Random.Range (0, parents.Length)], new Vector3 (Random.Range (-10f, 10f), Random.Range (-6f, 6f), 0), Quaternion.identity);
			MeshRenderer[] renderers = spawn.GetComponentsInChildren<MeshRenderer> ();
			Color color = colors [Random.Range (0, 5)];
			for (int j = 0; j < renderers.Length; j++) {
				renderers [j].material.color = color;
			}
		}
	}
	
	public void SpawnParticle ()
	{
		GameObject spawn = (GameObject)Instantiate (parents [Random.Range (0, parents.Length)], new Vector3 (Random.Range (-10f, 10f), Random.Range (-6f, 6f), 0), Quaternion.identity);
		MeshRenderer[] renderers = spawn.GetComponentsInChildren<MeshRenderer> ();
		Color color = colors [Random.Range (0, 5)];
		for (int j = 0; j < renderers.Length; j++) {
			renderers [j].material.color = color;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
