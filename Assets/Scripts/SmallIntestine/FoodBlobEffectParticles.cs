using UnityEngine;
using System.Collections;

public class FoodBlobEffectParticles : MonoBehaviour 
{
	public GameObject effectParticle;
	public int numParticlesMin;
	public int numParticlesMax;
	private int numAliveChildren;
	private Color particleColor;
	private GameObject[] instantiatedEffectParticles;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	public void createParticles(Color color)
	{
		if (Random.value > .5f)
		{
			instantiatedEffectParticles = new GameObject[numParticlesMin];
			numAliveChildren = numParticlesMin;
		} else
		{
			instantiatedEffectParticles = new GameObject[numParticlesMax];
			numAliveChildren = numParticlesMax;
		}

		particleColor = color;

		// spawn 5 particles in a "cloud"
		for (int i = 0; i < instantiatedEffectParticles.Length; i++)
		{
			instantiatedEffectParticles[i] = (GameObject)Instantiate(effectParticle);
			instantiatedEffectParticles[i].renderer.material.color = particleColor;
			instantiatedEffectParticles[i].transform.parent = gameObject.transform;
			if (Random.Range (0,2) == 1)
			{
				instantiatedEffectParticles[i].GetComponent<EffectParticle>().setDesiredLocation
					(instantiatedEffectParticles[i].transform.position + 
						new Vector3(Random.Range(-2.5f, -1.5f), 0f, Random.Range (-2f, 2f)));
			} else
			{
				instantiatedEffectParticles[i].GetComponent<EffectParticle>().setDesiredLocation
					(instantiatedEffectParticles[i].transform.position + 
					 new Vector3(Random.Range(2.5f, 1.5f), 0f, Random.Range (-2f, 2f)));
			}
		}
	}

	public void setPathPosition(float position)
	{
		FollowITweenPath path = gameObject.GetComponent<FollowITweenPath> ();
		path.pathPosition = position;
	}

	// destroy when the end of the path is reached
	void OnTriggerEnter(UnityEngine.Collider obj)
	{
		if (obj.gameObject.tag == "Finish")
		{
			Destroy(this.gameObject);
		}
	}

	public void decreaseAliveChildren()
	{
		numAliveChildren--;
		if (numAliveChildren == 0)
		{
			Destroy(this.gameObject);
		}
	}
}
