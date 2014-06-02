using UnityEngine;
using System.Collections;

public class FoodStuffFinish : MonoBehaviour 
{
	private StomachBar stomachBar;
	SpawnFood foodSpawner;
	//	private LostFoodCount lostFoodCount; // TODO: UNUSED

	// Use this for initialization
	void Start () 
	{
		GameObject mouthGUI = GameObject.Find("MouthGUI");
		stomachBar = mouthGUI.GetComponent<StomachBar>();
		foodSpawner = GameObject.Find("FoodSpawner").GetComponent<SpawnFood>();
		//lostFoodCount = mouthGUI.GetComponent<LostFoodCount>(); // TODO: UNUSED
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
		 * // TODO: UNUSED OBSOLETE CODE
		 else if (obj.gameObject.tag == "FallenOutFromMouth")	// check if the food fell out
		{
			OnFoodFallOut();
		}
		*************************/
	}

	void OnEndPointCollision()
	{
		// stomachBar.increaseStomachPercent(); //TODO: UNUSED
		//TODO: Make Different Levels and Transition Between Them
		GameObject[] foodstuff = GameObject.FindGameObjectsWithTag("MouthFood");
		if(foodstuff.Length == 1 && foodSpawner.end)
			Application.LoadLevel("EndScreen");
		else
			Destroy(this.gameObject);
	}

	/**************
	 * // TODO: UNUSED OBSOLETE METHOD
	void OnFoodFallOut()
	{
		lostFoodCount.increaseLostFoodCount ();
		Destroy(this.gameObject);
	}
	* ****************/
}
