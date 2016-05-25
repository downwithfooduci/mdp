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

	private StomachFoodBlob currentlyDigesting;

	private float digestDelay = 1.0f;
	private float elapsedTime;

	private const float MIN_DIGESTION_DISTANCE = 1;

	public float attackTime;
	private float attackTimer;
	private bool enzymeAttacking;

	private Vector2 zymePosition;
	private Quaternion zymeRotation;


	/**
	 * Use this for initialization
	 */
	void Start () 
	{
		/*get references*/
		i = GetComponent<Image> ();
		gm = FindObjectOfType (typeof(StomachGameManager)) as StomachGameManager;
		fm = FindObjectOfType (typeof(StomachFoodManager)) as StomachFoodManager;
		attackTimer = 0f;
		enzymeAttacking = false;
		zymePosition = new Vector2 (-(1024-200)*0.0651f,-(768-100)*0.0651f);
		zymeRotation = Quaternion.Euler(0, 0, 135f);
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

			if(fm.noFoodBlobs())
			{
				float step = speed * Time.deltaTime;
				Vector2 origin = Vector2.zero;
				if (enzymeAttacking == false) {
					transform.position = Vector2.MoveTowards (transform.position, origin, step);
				} else {
					transform.position = Vector2.MoveTowards (transform.position, zymePosition, step/2);
					transform.rotation = Quaternion.RotateTowards(transform.rotation, zymeRotation, step*10);
				}
				attackTimer = attackTimer + Time.deltaTime;
				if (attackTimer >= attackTime) {
					enzymeAttacking = true;
				}


			}
			else
			{
				elapsedTime += Time.deltaTime;
				if (elapsedTime > digestDelay)
				{
					float step = speed*Time.deltaTime;
					currentlyDigesting = fm.getNextFoodBlobToDigest();
					Vector2 foodLocation = currentlyDigesting.transform.position;
					Vector2 offset = currentlyDigesting.transform.rotation * new Vector3(0, -12, 0);
					foodLocation = foodLocation + offset;

					transform.position = Vector2.MoveTowards(transform.position, foodLocation, step);
					transform.rotation = Quaternion.RotateTowards(transform.rotation, currentlyDigesting.transform.rotation, step*10);

					if (!currentlyDigesting.IsDigesting && Vector2.Distance(transform.position, foodLocation) < MIN_DIGESTION_DISTANCE)
						currentlyDigesting.IsDigesting = true;
				}

				attackTimer = 0;
				enzymeAttacking = false;

			}
		} else
		{
			i.sprite = deactivatedTexture;
			float step = speed*Time.deltaTime;
			Vector2 origin = Vector2.zero;
			transform.position = Vector2.MoveTowards(transform.position, origin, step);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), step*10);


			attackTimer = 0;
			enzymeAttacking = false;
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

	public void setElapsedTime()
	{
		elapsedTime = 0f;
	}
	public bool isAttacking(){
		return enzymeAttacking;
	}
}