using UnityEngine;
using System.Collections;

public class EsophagusDebugConfigGUI : MonoBehaviour 
{
	EsophagusDebugConfig debugConfig;
	string foodSpawnInterval;
	string waveDelay;
	string waveTime;
	string foodSpeed;
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
		foodSpawnInterval = "" + debugConfig.foodSpawnInterval;
		waveDelay = "" + debugConfig.waveDelay;
		waveTime = "" + debugConfig.waveTime;
		foodSpeed = "" + debugConfig.foodSpeed;
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
		GUIStyle style = GUI.skin.label;
		style.normal.textColor = Color.black;
		GUI.depth -= 5;
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
			GUI.Label(new Rect(100, 10, 100, 50), "Food Spawn Interval", style);
			foodSpawnInterval = GUI.TextField(new Rect(200, 10, 100, 50),
			                                  foodSpawnInterval);
			float foodSpawnIntervalOut;
			if(float.TryParse(foodSpawnInterval, out foodSpawnIntervalOut))
			{
				debugConfig.foodSpawnInterval = foodSpawnIntervalOut;
			}
			
			GUI.Label(new Rect(100, 60, 100, 50), "Oxygen Depletion Rate",style);
			oxygenDeplete = GUI.TextField(new Rect(200, 60, 100, 50),
			                              oxygenDeplete);
			float oxygenDepleteOut;
			if(float.TryParse(oxygenDeplete, out oxygenDepleteOut))
			{
				debugConfig.oxygenDeplete = oxygenDepleteOut;
			}
			
			GUI.Label(new Rect(100, 110, 100, 50), "Oxygen Gain Rate",style);
			oxygenGain = GUI.TextField(new Rect(200, 110, 100, 50),
			                           oxygenGain);
			float oxygenGainOut;
			if(float.TryParse(oxygenGain, out oxygenGainOut))
			{
				debugConfig.oxygenGain = oxygenGainOut;
			}

			GUI.Label(new Rect(100, 160, 100, 50), "Wave Delay",style);
			waveDelay = GUI.TextField(new Rect(200, 160, 100, 50),
			                          waveDelay);
			float waveDelayOut;
			if(float.TryParse(waveDelay, out waveDelayOut))
			{
				debugConfig.waveDelay = waveDelayOut;
			}

			GUI.Label(new Rect(350, 0, 100, 50), "Wave Time",style);
			waveTime = GUI.TextField(new Rect(450, 0, 100, 50),
			                         waveTime);
			float waveTimeOut;
			if(float.TryParse(waveTime, out waveTimeOut))
			{
				debugConfig.waveTime = waveTimeOut;
			}

			GUI.Label(new Rect(350, 50, 100, 50), "Food Speed",style);
			foodSpeed = GUI.TextField(new Rect(450, 50, 100, 50),
			                          foodSpeed);
			float foodSpeedOut;
			if(float.TryParse(foodSpeed, out foodSpeedOut))
			{
				debugConfig.foodSpeed = foodSpeedOut;
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
