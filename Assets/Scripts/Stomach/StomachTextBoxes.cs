using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StomachTextBoxes : MonoBehaviour 
{
	public Image textbox;
	public Sprite[] textboxes;

	private float timeToHoldTextBox = 5.0f;
	private float elapsedTime;
	private bool refreshImageTimer = false;

	void Update()
	{
		Debug.Log (elapsedTime);
		// check if we should refresh the image hold timer
		if (refreshImageTimer)
		{
			elapsedTime = 0f;
			refreshImageTimer = false;
		}
		
		// if the text box is up and has been up fro the max time, remove it
		if (elapsedTime >= timeToHoldTextBox)
		{
			setTextbox (0);
		}
		
		// increment elapsed time
		elapsedTime += Time.deltaTime;
	}

	public void setTextbox(int index)
	{
		refreshImageTimer = true;
		textbox.sprite = textboxes [index];
	}
}
