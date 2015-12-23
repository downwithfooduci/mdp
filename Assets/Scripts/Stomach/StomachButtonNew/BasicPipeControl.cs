using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BasicPipeControl : MonoBehaviour
{

    private bool isClicked = false;
    private Image i;
    public Sprite[] ButtonStateImages;


    private PhBar PhB;
    private BasicFlowControl BFC;

    public void ButtonToggle()
    {
        BFC.ButtonToggle();
        if (isClicked)
        {
            isClicked = false;
            //swap texture to OFF
        }
        else
        {
            isClicked = true;
            //swap texture to ON

            PhB.addBase();
        }
    }

    public bool getClick()
    {
        return isClicked;
    }

    // Use this for initialization
    void Start()
    {
        PhB = FindObjectOfType(typeof(PhBar)) as PhBar;
        BFC = FindObjectOfType(typeof(BasicFlowControl)) as BasicFlowControl;
        i = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
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
