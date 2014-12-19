using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StomachReturnButton : MonoBehaviour 
{
	public Canvas ui;
	public RectTransform r;		//!< the rect transform to change the size and scale of the ui
	public RectTransform yes;
	public RectTransform no;


	void Start()
	{
		ui.enabled = false;
	}

	public void setEnable()
	{
		Time.timeScale = 0f;
		ui.enabled = true;
		r.localScale = new Vector3 (1f, 1f, 1f);
		yes.localScale = new Vector3 (1f, 1f, 1f);
		no.localScale = new Vector3 (1f, 1f, 1f);
	}

	public void returnToMain()
	{
		Application.LoadLevel ("MainMenu");
	}

	public void cancel()
	{
		Time.timeScale = 1f;
		ui.enabled = false;
	}
}
