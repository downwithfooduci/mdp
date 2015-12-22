using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlowImageControl : MonoBehaviour {


    private bool isClicked = false;
    private Image i;
    public Sprite[] FlowStateImages;
    private int counter = 0;
    public int ImSpeed;

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
            i.sprite = FlowStateImages[0];
            return;
        }
        if (isClicked == true)
        {
            if (counter < ImSpeed)
            {
                i.sprite = FlowStateImages[1];
                counter++;
                return;
            }
            else
            {
                i.sprite = FlowStateImages[2];
                counter ++;
                if (counter == ImSpeed*2)
                    counter = 0;
                return;
            }
        }
    }
}
