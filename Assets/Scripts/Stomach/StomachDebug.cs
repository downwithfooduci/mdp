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
	public UnityEngine.UI.InputField timeForBurnNoSlimeInput;
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
	private float timeToBurnFromNorm;
	private float timeForSlimeDecay;
	private float timeToRevive;
	private float timeToBurnWithSlime;
	private int maxCellDeaths;
	private int acidity;
	private int basic;
	private float acidGainSpeed;
	private float baseGainSpeed;
	private float idleDecaySpeed;
	private bool useDebugger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onSubmit()
	{
		useDebugger = useDebuggerToggle.isOn;

		if (useDebugger)
		{
			maxFood = int.Parse(maxFoodInput.GetComponent<Text>().text);
			timeToBurnFromNorm = float.Parse(timeForBurnNoSlimeInput.GetComponent<Text>().text);
		}
	}
}
