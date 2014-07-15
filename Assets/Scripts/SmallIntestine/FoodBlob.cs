// Container class for a food blob.
// Blob itself has no physical form but
// contains nutrients as children

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodBlob : MonoBehaviour 
{
	public float Velocity;
	public float RotationSpeed;

    public GameObject Nutrient;
	public int NumNutrients;
	
	private ushort m_FoodLife;	
	private GameObject m_EndPoint;

    private NutrientManager m_NutrientManager;
    private IntestineGameManager m_GameManager;

	// for sounds
	public GameObject nutrientLostSound;
	
	public void GenerateEnzymes(int minNutrients, int maxNutrients, Color[] availableColors)
	{
		NumNutrients = Random.Range (minNutrients,maxNutrients + 1);
		
        m_NutrientManager = FindObjectOfType(typeof(NutrientManager)) as NutrientManager;
        m_GameManager = FindObjectOfType(typeof(IntestineGameManager)) as IntestineGameManager;

		for(int i = 0; i < NumNutrients; i++)
        {
			float radius = .4f;							// choose .5f as a radius to start with
			float angle = ((2 * Mathf.PI)/NumNutrients)*i;	// divide the circle into the right number of angle chunks in rads
			float xPos = radius * Mathf.Cos(angle);		// find the x position as radius*cos(theta)
			float zPos = radius * Mathf.Sin (angle);	// find the y position as radius*sin(theta)
			
			Vector3 position = transform.position;		// 3 dimensional vector for position
			position.x += xPos;							// set the x position of the vector
			position.z += zPos;							// set the z position of the vector
			position.y = .5f; 							// set the y position of the vector

			// when we choose the random color index, we put -1 because we DO NOT want it to choose white
            int randomIndex = MDPUtility.RandomInt(availableColors.Length);
			Nutrient nutrient = m_NutrientManager.InstantiateNutrient(availableColors[randomIndex], position);
			nutrient.intestineGameManager = m_GameManager;
			
			// Attach new enzyme as a child object
			nutrient.transform.parent = gameObject.transform;
			((Behaviour)nutrient.GetComponent("Halo")).enabled = false;
		}
	}

    void OnTriggerEnter(UnityEngine.Collider obj)
    {
        if (obj.gameObject.tag == "Finish")
        {
            OnEndPointCollision();
        }
    }
	
	private void OnEndPointCollision()
	{	
		int numNutrientsAlive = 0;
		
        foreach (Transform child in transform)
        {
			if (child.name.StartsWith("EffectPartle"))		// we want to destroy the effect particles so they don't interfere
			{
				Destroy(child.gameObject);
			} else 
			{
				Nutrient n = child.GetComponent<Nutrient>();
				if (!n.isDead)								// flag if any of the nutrients are still alive
				{
					numNutrientsAlive++;
					Instantiate(nutrientLostSound);
				}
            	m_NutrientManager.RemoveNutrient(child.GetComponent<Nutrient>());
			}
        }
		Destroy(this.gameObject);
		m_GameManager.OnFoodBlobFinish(numNutrientsAlive); 
	}
	
	virtual public void TakeHit()
	{
		m_FoodLife--;
	}
	
	void OnMouseDown()
	{
        GetComponent<FollowITweenPath>().enabled = false;
	}
	
	void OnMouseUp()
	{
        GetComponent<FollowITweenPath>().enabled = true;
	}
}
