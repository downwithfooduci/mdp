using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PipiImageControl : MonoBehaviour {

    private bool isClicked = false;
    private Image i;
    public Sprite[] ButtonStateImages;

    public void ButtonToggle()
    {
        if (isClicked)
        {
            isClicked = false;
            //swap texture to OFF
        }
        else
        {
            isClicked = true;
            //swap texture to ON
        }
    }

    // Use this for initialization
    void Start () {
        i = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isClicked == false)
        {
            i.sprite = ButtonStateImages[0];
            return;
        }
        if (isClicked == true)
        {
            i.sprite = ButtonStateImages[1];
            return;
        }

    }
}
