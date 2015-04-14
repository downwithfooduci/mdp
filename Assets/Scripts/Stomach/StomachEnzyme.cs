using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Script for the stomach enzyme
 */
public class StomachEnzyme : MonoBehaviour 
{
	private Image i;							//!< reference to the image
	public Sprite activatedTexture;				//!< to hold the texture of an activated cell
	public Sprite deactivatedTexture;			//!< to hold the texture of a deactivated cell
	
	public StomachTextBoxes textboxes;			//!< reference to the stomach text boxes script
	private StomachGameManager gm;				//!< reference to the stomach game manager

	
	private StomachFoodManager fm;				//!< reference to the food manager
	public float speed;							//!< reference to the speed the enzyme moves
	
	/**
	 * Use this for initialization
	 */
	void Start () 
	{
		/*get references*/
		i = GetComponent<Image> ();
		gm = FindObjectOfType (typeof(StomachGameManager)) as StomachGameManager;
		fm = FindObjectOfType (typeof(StomachFoodManager)) as StomachFoodManager;
	}
	
	/**
	 * Update is called once per frame
	 */
	void Update () 
	{
		/* Draw the proper activated or deactivated texture based on acid level*/
		if (gm.getCurrentAcidLevel() == "acidic")
		{
			i.sprite = activatedTexture;
			if(fm.noFoodBlobs()){
				
				float step = speed*Time.deltaTime;
				Vector2 origin = Vector2.zero;
				transform.position = Vector2.MoveTowards(transform.position, origin, step);
				Debug.Log("No food detected");
				Debug.Log("Total Count:"+fm.getNumFoodBlobs());
				Debug.Log("Current Food Count:"+fm.getFoodFlag());
				
			}
			else{
				float step = speed*Time.deltaTime;
				Vector2 movement = fm.locFirstFoodBolb();
				transform.position = Vector2.MoveTowards(transform.position, movement, step);
				Debug.Log("Food detected");
			}

		} else
		{
			i.sprite = deactivatedTexture;
			float step = speed*Time.deltaTime;
			Vector2 origin = Vector2.zero;
			transform.position = Vector2.MoveTowards(transform.position, origin, step);
		}
	}
	
	/**
	 * Called when the enzyme is clicked on
	 */
	private void clickOnEnzyme()
	{
		if (gm.getCurrentAcidLevel() != "acidic")
		{
			textboxes.setTextbox(5);
		}
	}
}