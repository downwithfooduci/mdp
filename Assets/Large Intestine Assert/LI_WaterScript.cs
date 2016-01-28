using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LI_WaterScript : MonoBehaviour {

    private LargeIntestGameManager lgm;
    public int rounds;

    public Sprite[] Waterlist;
    private Image i;
    private float counter;

    private int imagestatment;

    // Use this for initialization
    void Start () {
        i = GetComponent<Image>();
        imagestatment = 3;
        counter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        i.sprite = Waterlist[imagestatment];
        if (imagestatment <2)
        {
            counter = counter + Time.deltaTime;
            if (counter > 0.2)
            {
                imagestatment++;
                
               
                counter = 0;

            }
        }
        
	}

    public void subStart()
    {
        imagestatment = 0;
        counter = 0;
    }
}
