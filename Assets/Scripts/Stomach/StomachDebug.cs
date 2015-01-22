using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StomachDebug : MonoBehaviour 
{
	/**
	 * Debugger items to pull values from
	 */
	public UnityEngine.UI.InputField maxFoodInput;
	public UnityEngine.UI.InputField timeToBurnInput;
	public UnityEngine.UI.InputField timeForSlimeDecayInput;
	public UnityEngine.UI.InputField timeToReviveInput;
	public UnityEngine.UI.InputField timeToBurnNoSlimeInput;
	public UnityEngine.UI.InputField maxCellDeathsInput;
	public UnityEngine.UI.InputField acidityThresholdInput;
	public UnityEngine.UI.InputField basicThresholdInput;
	public UnityEngine.UI.InputField acidSpeedInput;
	public UnityEngine.UI.InputField baseSpeedInput;
	public UnityEngine.UI.InputField idleDecaySpeedInput;
	public UnityEngine.UI.Toggle useDebuggerToggle;

	/**
	 * Actual variables holding the values we are using
	 * parsed from the debugger
	 */
	private int maxFood;
	private float timeToBurn;
	private float timeForSlimeDecay;
	private float timeToRevive;
	private float timeToBurnNoSlime;
	private int maxCellDeaths;
	private int acidityThreshold;
	private int basicThreshold;
	private float acidSpeed;
	private float baseSpeed;
	private float idleDecaySpeed;
	private bool useDebugger;

	/**
	 * Function that describes what happens when the debug menu is submitted
	 */
	public void onSubmit()
	{
		useDebugger = useDebuggerToggle.isOn;

		if (useDebugger)
		{
			maxFood = int.Parse(maxFoodInput.GetComponent<Text>().text);
			timeToBurn = float.Parse(timeToBurnInput.GetComponent<Text>().text);
			timeForSlimeDecay = float.Parse(timeForSlimeDecayInput.GetComponent<Text>().text);
			timeToRevive = float.Parse(timeToReviveInput.GetComponent<Text>().text);
			timeToBurnNoSlime = float.Parse(timeToBurnNoSlimeInput.GetComponent<Text>().text);
			maxCellDeaths = int.Parse(maxCellDeathsInput.GetComponent<Text>().text);
			acidityThreshold = int.Parse(acidityThresholdInput.GetComponent<Text>().text);
			basicThreshold = int.Parse(basicThresholdInput.GetComponent<Text>().text);
			acidSpeed = float.Parse(acidSpeedInput.GetComponent<Text>().text);
			baseSpeed = float.Parse(baseSpeedInput.GetComponent<Text>().text);
			idleDecaySpeed = float.Parse(idleDecaySpeedInput.GetComponent<Text>().text);
		}
	}
}
