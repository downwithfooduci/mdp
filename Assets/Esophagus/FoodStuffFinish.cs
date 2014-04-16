using UnityEngine;
using System.Collections;

public class FoodStuffFinish : MonoBehaviour 
{
	private StomachBar stomachBar;
	private LostFoodCount lostFoodCount;

	// Use this for initialization
	void Start () 
	{
		GameObject esophagusGUI = GameObject.Find("EsophagusGUI");
		stomachBar = esophagusGUI.GetComponent<StomachBar>();
		lostFoodCount = esophagusGUI.GetComponent<LostFoodCount>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(UnityEngine.Collider obj)
	{
		// check if we got the food through the mouth
		if (obj.gameObject.tag == "MouthEnd")
		{
			OnEndPointCollision();
		} else if (obj.gameObject.tag == "FallenOutFromMouth")	// check if the food fell out
		{
			OnFoodFallOut();
		}
	}

	void OnEndPointCollision()
	{
		stomachBar.increaseStomachPercent();
		Destroy(this.gameObject);
	}

	void OnFoodFallOut()
	{
		lostFoodCount.increaseLostFoodCount ();
		Destroy(this.gameObject);
	}
}
