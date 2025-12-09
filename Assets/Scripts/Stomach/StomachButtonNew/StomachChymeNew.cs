using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StomachChymeNew : MonoBehaviour {

    public float ACIDIC;                    //!< to hold the number to define an acidic environment
    public float BASIC;                     //!< to hold the number to define a basic environment


    private int x = 0;
    private float timer = 0f;                 // accumulates Time.deltaTime
    public float secondsPerFrame = 0.1f;      // seconds between sprite frames (use inspector to tune)
    public int ImSpeed; // kept for compatibility but no longer used for timing

    public Sprite[] AcidChymeImage;
    public Sprite[] BasicChymeImage;
    public Sprite[] NeutralChymeImage;


    
    public RectTransform acidHeight;        //!< reference to the rect transform drawing the acid level bar

    private StomachGameManager gm;          //!< hold a reference to the stomach game manager
    private Image i;                        //!< to hold a reference to the image

    //public Sprite neutralChyme;             //!< holds the texture for the chyme when stomach is "neutral"
    //public Sprite acidicChyme;              //!< holds the texture for the chyme when stomach is "acidic"
    //public Sprite basicChyme;               //!< holds the texture for the chyme when stomach is "basic"

    private float acidityLevel;             //!< to hold the acidity level value


    

    // Use this for initialization
    void Start ()
    {
        i = GetComponent<Image>();
        gm = FindObjectOfType(typeof(StomachGameManager)) as StomachGameManager;

    }
	
	// Update is called once per frame
    void Update () {

        // choose current sprite array based on acid level
        if (gm == null || i == null)
            return;

        Sprite[] currentArray = BasicChymeImage;
        string level = gm.getCurrentAcidLevel();
        if (level == "acidic")
        {
            currentArray = AcidChymeImage;
        }
        else if (level == "neutral")
        {
            currentArray = NeutralChymeImage;
        }

        int len = (currentArray != null) ? currentArray.Length : 0;
        if (len > 0)
        {
            // set current sprite (clamped by array length)
            i.sprite = currentArray[x % len];

            // advance timer using deltaTime so animation speed is platform-independent
            timer += Time.deltaTime;
            if (timer >= secondsPerFrame)
            {
                timer -= secondsPerFrame;
                x = (x + 1) % len;
            }
        }

    }
}
