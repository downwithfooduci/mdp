using UnityEngine;
using System.Collections;

public class FoodStuffFinish : MonoBehaviour 
{
	private StomachBar stomachBar;
//	private LostFoodCount lostFoodCount; //UNUSED

	// Use this for initialization
	void Start () 
	{
		GameObject mouthGUI = GameObject.Find("MouthGUI");
		stomachBar = mouthGUI.GetComponent<StomachBar>();
		//lostFoodCount = mouthGUI.GetComponent<LostFoodCount>(); // UNUSED
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
		}
		/***********************
		 * OBSOLETE CODE
		 else if (obj.gameObject.tag == "FallenOutFromMouth")	// check if the food fell out
		{
			OnFoodFallOut();
		}
		*************************/
	}

	void OnEndPointCollision()
	{
		stomachBar.increaseStomachPercent();
		Destroy(this.gameObject);
	}

	/**************
	 * OBSOLETE METHOD
	void OnFoodFallOut()
	{
		lostFoodCount.increaseLostFoodCount ();
		Destroy(this.gameObject);
	}
	* ****************/
}
