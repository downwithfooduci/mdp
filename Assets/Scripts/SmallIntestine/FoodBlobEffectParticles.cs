using UnityEngine;
using System.Collections;

public class FoodBlobEffectParticles : MonoBehaviour 
{
	public GameObject effectParticle;
	public int numParticles;
	private Color particleColor;
	private GameObject[] instantiatedEffectParticles;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void createParticles(Color color)
	{
		instantiatedEffectParticles = new GameObject[numParticles];

		particleColor = color;

		// spawn 5 particles in a "cloud"
		for (int i = 0; i < numParticles; i++)
		{
			instantiatedEffectParticles[i] = (GameObject)Instantiate(effectParticle);
			instantiatedEffectParticles[i].renderer.material.color = particleColor;
			instantiatedEffectParticles[i].transform.parent = gameObject.transform;
			instantiatedEffectParticles[i].transform.position += 
				new Vector3(Random.Range(-2f, 2f), 0f, Random.Range (-2f, 2f));
		}
	}

	public void setPathPosition(float position)
	{
		FollowITweenPath path = gameObject.GetComponent<FollowITweenPath> ();
		path.pathPosition = position;
	}
}
