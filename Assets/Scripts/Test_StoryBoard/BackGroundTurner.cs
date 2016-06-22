using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BackGroundTurner : MonoBehaviour {

	/***************************************************************/
	public AudioClip[] sounds;			//!< store the storyboard narrations
	private int currPage = 1;			//!< store the current page
	private bool hasPlayed = false;		//!< remember whether the current sound has played
	private bool buttonClicked = false;	//!< holds if the user clicked in the page corner instead of swiping

	DetectStraightSwipe swipeDetection;	//!< to hold a reference to the script that controls swipe detection

	private bool canSkip = false;		//!< check for playthrough

	private AsyncOperation loader;		//!< for preloading the next level

	/***************************************************************/








	public Sprite[] BackGroundImages;
	private Image image;

	public int[] CharacterPage;
	public float[] XCharacterPosition;
	public float[] YCharacterPosition;
	public Sprite[] CharacterImage;



	public List<Pages_Sprites> PageList = new List<Pages_Sprites>();
	private HashSet<int> charSet = new HashSet<int>();



	private StoryCharacter storyChar;
	private bool charAdded;
	private int charTracker;




	public int[] animatedZyme;


	// Use this for initialization
	void Start () {

		image = GetComponent<Image>();
		storyChar = FindObjectOfType (typeof(StoryCharacter)) as StoryCharacter;

		charAdded = false;
		charTracker = 0;



		for (int i = 0; i < CharacterPage.Length; i++) {
			charSet.Add (CharacterPage [i]);
			Debug.Log ("Page " + CharacterPage[i] + " added");
		}

		int tempCharCounter = 0;
		for (int i = 0; i < BackGroundImages.Length; i++) {
			PageList.Add (new Pages_Sprites (BackGroundImages [i], i));
			if (charSet.Contains (i)) {
				Sprite[] tempCharSprite = new Sprite[2];

				tempCharSprite [0] = CharacterImage [tempCharCounter*2];
				tempCharSprite [1] = CharacterImage [tempCharCounter*2 + 1];

				PageList [i].setCharacter (tempCharSprite, XCharacterPosition [tempCharCounter], YCharacterPosition [tempCharCounter]);
				tempCharCounter++;
			}
		}




		/**************************************************************/
		swipeDetection = gameObject.GetComponent<DetectStraightSwipe> ();


		/**************************************************************/


	}



	/**
	 * Starts preloading the next level to avoid delays
	 */
	IEnumerator loadNextLevel() 
	{
		// starts preloading hte next level in the sequence accordingly
		if (Application.loadedLevelName.Equals ("Test_IntroStoryBoard")) {
			loader = Application.LoadLevelAsync("Test_nowEntering");
		}
		else if (Application.loadedLevelName.Equals("IntroStoryboard"))
		{
			loader = Application.LoadLevelAsync("MouthStoryboard");		
		} else if (Application.loadedLevelName.Equals("MouthStoryboard"))
		{
			loader = Application.LoadLevelAsync("LoadLevelMouth");
		} else if (Application.loadedLevelName.Equals("MouthEndStoryboard"))
		{
			loader = Application.LoadLevelAsync("StomachStoryboard");
		} else if (Application.loadedLevelName.Equals("StomachStoryboard"))
		{
			loader = Application.LoadLevelAsync("LoadLevelStomach");
		} else if (Application.loadedLevelName.Equals("StomachEndStoryboard"))
		{
			loader = Application.LoadLevelAsync("SmallIntestineStoryboard");
		} else if (Application.loadedLevelName.Equals("SmallIntestineStoryboard"))
		{
			loader = Application.LoadLevelAsync("LoadLevelSmallIntestine");
		} else if (Application.loadedLevelName.Equals("SmallIntestineEndStoryboard"))
		{
			loader = Application.LoadLevelAsync("LargeIntestineStoryboard");
		} else if (Application.loadedLevelName.Equals("LargeIntestineStoryboard"))
		{
			loader = Application.LoadLevelAsync("LargeIntestine");
		} else if (Application.loadedLevelName.Equals("LargeIntestineEndStoryboard"))
		{
			loader = Application.LoadLevelAsync("EndScreen");
		}




		loader.allowSceneActivation = false;	// set this to mean we don't want the scene to load until we say
		yield return loader;
	}





	// Update is called once per frame
	void Update () {






		/**************************************************************/

		if (!GetComponent<AudioSource>().isPlaying || canSkip)
		{
			if (swipeDetection.getSwipeLeft() || buttonClicked)		// attempt to detect a swipe to the right
			{
				buttonClicked = false;
				swipeDetection.resetSwipe();						// reset the variables to prevent multiple page turns
				currPage++;											// increment the page since we are going forward
				hasPlayed = false;
				charAdded = false;
				
			} else if (swipeDetection.getSwipeRight() == true)			// attempt to detect a swipe to the left
			{
				swipeDetection.resetSwipe();						// reset the varaibel to prevent multiple page turns

				if (currPage - 1 > 0)								// perform bounds checking to make sure we don't go back too far
				{
					currPage--;
					hasPlayed = false;
					charAdded = false;


				}
			}
		} else if (GetComponent<AudioSource>().isPlaying)
		{
			swipeDetection.resetSwipe();							// if we can't change the page yet forget the swipe
		}

		if (!hasPlayed)								// only play the clip once per page
		{
			if (!((currPage - 1) >= PageList.Count))
			{
				GetComponent<AudioSource>().clip = sounds [currPage - 1];		// if we haven't played the sound yet load the new audio clip
				playClip();								// play the clip
				hasPlayed = true;						// mark that we have played the clip
			}
		}




		if ((currPage - 1) == BackGroundImages.Length)					// perform bounds checking to see if we should load the next scene
		{

			if (Application.loadedLevelName.Equals ("Test_IntroStoryBoard")) {
				PlayerPrefs.SetInt("PlayedTestIntroStory", 1);
				Application.LoadLevel ("Test_nowEntering");
			}
			else if (Application.loadedLevelName.Equals("IntroStoryboard"))
			{
				PlayerPrefs.SetInt("PlayedIntroStory", 1);		// if we're ready set that we've heard this story segment
			} else if (Application.loadedLevelName.Equals("MouthStoryboard"))
			{
				PlayerPrefs.SetInt("PlayedMouthStory", 1);
			} else if (Application.loadedLevelName.Equals("MouthEndStoryboard"))
			{
				PlayerPrefs.SetInt("PlayedMouthEndStory", 1);
			} else if (Application.loadedLevelName.Equals("StomachStoryboard"))
			{
				PlayerPrefs.SetInt("PlayedStomachStory", 1);
			} else if (Application.loadedLevelName.Equals("StomachEndStoryboard"))
			{
				PlayerPrefs.SetInt("PlayedStomachEndStory", 1);
			} else if (Application.loadedLevelName.Equals("SmallIntestineStoryboard"))
			{
				PlayerPrefs.SetInt("PlayedSIStory", 1);
			} else if (Application.loadedLevelName.Equals("SmallIntestineEndStoryboard"))
			{
				PlayerPrefs.SetInt("PlayedSIEndStory", 1);
			} else if (Application.loadedLevelName.Equals("LargeIntestineStoryboard"))
			{
				PlayerPrefs.SetInt("PlayedLIStory", 1);
			} else if (Application.loadedLevelName.Equals("LargeIntestineEndStoryboard"))
			{
				PlayerPrefs.SetInt("PlayedLIEndStory", 1);
			}

			PlayerPrefs.Save();
			//loader.allowSceneActivation = true;				// load the next level

			Application.LoadLevel ("Test_nowEntering");

		}


		/**************************************************************/


		int tempPageNum = Mathf.Clamp (currPage - 1, 0, BackGroundImages.Length - 1);
		image.sprite = BackGroundImages [tempPageNum];

		if (charSet.Contains (tempPageNum)) {
			//Debug.Log ("Current Page: " + tempPageNum);
			storyChar.setcharOn ();
		} else {
			storyChar.setcharOff ();
		}
		


	
	}



	private void playClip()
	{
		GetComponent<AudioSource>().Play();
	}

	public int currentPage(){
		return Mathf.Clamp (currPage - 1, 0, BackGroundImages.Length - 1);
	}
	/*
	public Vector2 charPosition(){
		if (charSet.Contains(currentPage())) {
			return new Vector2(PageList [currentPage ()].PageCharacter.posx, PageList[currentPage()].PageCharacter.posy);
		}
		else
			return new Vector2(0,0);
	}
	*/

}


public class Pages_Sprites //: NewPageSytemTest1
{
	public int num;
	public Sprite PageTexture;
	//public Texture[] CharacterTexture;
	public extraCharacters_Sprites PageCharacter;
	//public bool hasChar = false;
	public Pages_Sprites(Sprite pageimage, int n){
		PageTexture = pageimage;
		num = n;
	}
	public void setPage(Sprite pageText){
		this.PageTexture = pageText;

	}
	//public void setCharacter(Texture[] charText, float x, float y){
	public void setCharacter(Sprite[] charText, float x, float y){

		//CharacterTexture = charText;
		PageCharacter = new extraCharacters_Sprites(charText, x, y);
		//hasChar = true;
	}
	public Sprite getTexture(){
		return PageTexture;
	}
		
}

public class extraCharacters_Sprites //: NewPageSytemTest1
{
	//public Texture[] charTexture;
	public Sprite[] charSprite;
	public float posx;
	public float posy;
	public float width;
	public float height;
	//public extraCharacters(Texture[] charImage, float x, float y){
	public extraCharacters_Sprites(Sprite[] charImage, float x, float y){
		//charTexture = charImage;
		charSprite = charImage;
		posx = x;
		posy = y;
		width = charImage[0].bounds.size.x;
		height = charImage [0].bounds.size.y;
	}


}