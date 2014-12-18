using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StomachTextBoxes : MonoBehaviour 
{
	public Image textbox;
	public Sprite[] textboxes;

	public void setTextbox(int index)
	{
		textbox.sprite = textboxes [index];
	}
}
