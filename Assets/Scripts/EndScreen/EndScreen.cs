using UnityEngine;
using System.Collections;

/**
 * placeholder for the ending of the game
 */
public class EndScreen : MonoBehaviour 
{
	public Texture background;	//!< background image
	public GUIStyle mainMenu;	//!< main menu button
	public GUIStyle restart;	//!< restart button

    public GUIStyle linkStyle;
    public string privacyLinkName;

    void Start() {
        linkStyle = new GUIStyle();                                   // create a new style
        linkStyle.font = (Font)Resources.Load("Fonts/JandaManateeSolid");     // set the font
        //linkStyle.normal.textColor = Color.white;                              // set the font color
        linkStyle.fontSize = (int)(16f / 768f * Screen.height);

        privacyLinkName = "Privacy Policy";


    }
    void OnGUI()
	{
		// draw the background texture to fill the entire screen.
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);

        /*
        GUI.Label(new Rect(((276f + 20f) / 1024f) * Screen.width, ((141f + 300f) / 768f) * Screen.height, ((340f) / 1024f) * Screen.width,
                    ((29f) / 768f) * Screen.height),
                    privacyLinkName,
                    linkStyle);
                    */                   

        if (GUI.Button(new Rect(((555f) / 1024f) * Screen.width, ((740f) / 768f) * Screen.height, ((340f) / 1024f) * Screen.width,
                    ((29f) / 768f) * Screen.height),
                    privacyLinkName,
                    linkStyle)) 
        {
            Application.OpenURL("https://sites.google.com/view/down-with-food/home#h.p_KGoenpRwSrVc");
        }
        // Get the last rect to display the line
        /*
        GUI.Label(new Rect(((555f) / 1024f) * Screen.width, ((760f) / 768f) * Screen.height, ((340f) / 1024f) * Screen.width,
                    1f), Texture2D.White);
                    */                   



        // draw the main menu button
        if (GUI.Button(new Rect(Screen.width * .89f, 
			Screen.height * 0.01822916f,
			Screen.width * .09f,
			Screen.height * .06f),
		                "", mainMenu))
		{
			// when yoou click on main menu then return to the main menu
			Application.LoadLevel("LevelSelection");
		}

		/*
		// draw the restart button
		if(GUI.Button(new Rect(Screen.width * .55f, .45f * Screen.height, Screen.width * .2f, Screen.height * .1f),
		           "", restart))
		{
			// when you click on restart we currently restart the small intestine game
			// this will need to be changed as the game changes
			Application.LoadLevel("LoadLevelSmallIntestine");
		}
		*/

	}
}
