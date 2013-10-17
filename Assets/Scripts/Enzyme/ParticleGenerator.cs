using UnityEngine;
using System.Collections;

public class ParticleGenerator : MonoBehaviour
{
	
	public GameObject parentCube;
	public GameObject parentSphere;
	public GameObject parentCapsule;
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
		parents = new GameObject[3];
		parents [0] = parentCube;
		parents [1] = parentSphere;
		parents [2] = parentCapsule;
		
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
