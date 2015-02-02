using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Script for stomach return button functionality
 */
public class StomachReturnButton : MonoBehaviour 
{
	public Canvas ui;					//!< hold a reference to the return popup canvas
	public Canvas main;					//!< hold a reference to the main canvas

	/**
	 * Initialization
	 */
	void Start()
	{
		ui.enabled = false;
	}

	/**
	 * to enable the return popup
	 */
	public void setEnable()
	{
		Time.timeScale = 0f;
		ui.enabled = true;
		main.enabled = false;
	}

	/**
	 * to load the main menu
	 */
	public void returnToMain()
	{
		Application.LoadLevel ("MainMenu");
	}

	/**
	 * When the cancel button is pressed
	 */
	public void cancel()
	{
		Time.timeScale = 1f;
		ui.enabled = false;
		main.enabled = true;
	}
}
