using UnityEngine;
using System.Collections;

public class EsophagusDebugConfigGUI : MonoBehaviour 
{
	EsophagusDebugConfig debugConfig;
	string foodSpawnDelay;
	string oxygenDeplete;
	string oxygenGain;
	//string stomachDeplete;	// TODO: UNUSED
	//string stomachGain;		// TODO: UNUSED
	//string maxLostFoodAmount;	// TODO: UNUSED
	bool debugActive;
	bool showGUI = false;

	// Use this for initialization
	void Start () {
		debugConfig = gameObject.GetComponent<EsophagusDebugConfig>();
		foodSpawnDelay = "" + debugConfig.foodSpawnDelay;
		oxygenDeplete = "" + debugConfig.oxygenDeplete;
		oxygenGain = "" + debugConfig.oxygenGain;
		//stomachDeplete = "" + debugConfig.stomachDeplete;			// TODO: UNUSED
		//stomachGain = "" + debugConfig.stomachGain;				// TODO: UNUSED
		//maxLostFoodAmount = "" + debugConfig.maxLostFoodAmount;	// TODO: UNUSED
		debugActive = debugConfig.debugActive;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width  - (Screen.width * .25f), 
		                           Screen.height - (Screen.height * .06f),
		                           Screen.width * .12f,
		                           Screen.height * .06f), "Debug"))
		{
			showGUI = !showGUI;
			Time.timeScale = showGUI ? 0 : 1;
		}

		if(showGUI)
		{
			GUI.Label(new Rect(100, 10, 100, 50), "Food Spawn Delay");
			foodSpawnDelay = GUI.TextField(new Rect(200, 10, 100, 50),
			                               foodSpawnDelay);
			float foodSpawnDelayOut;
			if(float.TryParse(foodSpawnDelay, out foodSpawnDelayOut))
			{
				debugConfig.foodSpawnDelay = foodSpawnDelayOut;
			}
			
			GUI.Label(new Rect(100, 60, 100, 50), "Oxygen Depletion Rate");
			oxygenDeplete = GUI.TextField(new Rect(200, 60, 100, 50),
			                              oxygenDeplete);
			float oxygenDepleteOut;
			if(float.TryParse(oxygenDeplete, out oxygenDepleteOut))
			{
				debugConfig.oxygenDeplete = oxygenDepleteOut;
			}
			
			GUI.Label(new Rect(100, 110, 100, 50), "Oxygen Gain Rate");
			oxygenGain = GUI.TextField(new Rect(200, 110, 100, 50),
			                           oxygenGain);
			float oxygenGainOut;
			if(float.TryParse(oxygenGain, out oxygenGainOut))
			{
				debugConfig.oxygenGain = oxygenGainOut;
			}
			/*******************
			 * // TODO: UNUSED OBSOLETE STUFF
			GUI.Label(new Rect(100, 160, 100, 50), "Stomach Depletion Rate");
			stomachDeplete = GUI.TextField(new Rect(200, 160, 100, 50),
			                           stomachDeplete);
			float stomachDepleteOut;
			if(float.TryParse(stomachDeplete, out stomachDepleteOut))
			{
				debugConfig.stomachDeplete = stomachDepleteOut;
			}

			GUI.Label(new Rect(100, 210, 100, 50), "Stomach Gain Rate");
			stomachGain = GUI.TextField(new Rect(200, 210, 100, 50),
			                               stomachGain);
			float stomachGainOut;
			if(float.TryParse(stomachGain, out stomachGainOut))
			{
				debugConfig.stomachGain = stomachGainOut;
			}

			GUI.Label(new Rect(100, 260, 100, 50), "Max Lost Food");
			maxLostFoodAmount = GUI.TextField(new Rect(200, 260, 100, 50),
			                                  maxLostFoodAmount);
			int maxLostFoodAmountOut;

			if(int.TryParse(maxLostFoodAmount, out maxLostFoodAmountOut))
			{
				debugConfig.maxLostFoodAmount = maxLostFoodAmountOut;
			}
	****************************************************/

			debugActive = GUI.Toggle(new Rect(100, 310, 100, 20), debugActive, "Debug Active");
			if (debugActive)
			{
				debugConfig.debugActive = true;
			} else
			{
				debugConfig.debugActive = false;
			}
		}
	}
}
