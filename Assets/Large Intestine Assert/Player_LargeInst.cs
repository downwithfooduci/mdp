using UnityEngine;
using System.Collections;

public class Player_LargeInst : MonoBehaviour {

	public int GameLoopFlag;

	public Vector2 speed = new Vector2(50f, 50f);
	
	// 2 - Store the movement
	private Vector2 movement;
	public Rigidbody2D rb;

	public int PlayerWater;
	private LargeIntestGameManager lgm;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

		GameLoopFlag = 0;

		lgm = FindObjectOfType (typeof(LargeIntestGameManager)) as LargeIntestGameManager;

		PlayerWater = 100;

	}
	
	// Update is called once per frame
	void Update () {
		rb.position.x.Equals (0f);
		PlayerWater = lgm.getWaterValue ();
	}

	void FixedUpdate()
	{


		// 5 - Move the game object
		//transform.position= Vector2.MoveTowards.;

		float inputY = Input.GetAxis("Vertical");

		if (Input.GetKey ("up")) {
			
			//rb.AddForce(Vector2.up * inputY* 50f);
			rb.MovePosition (rb.position + speed);

			
			movement = new Vector2 (
				0f,
				speed.y * 10f);	

			if(GameLoopFlag == 0){
				GameLoopFlag = 1;
			}

		}

	}

	public void MoveUp(){
		//rb.AddForce(Vector2.up * inputY* 50f);

		Debug.Log("Entered");

		//rb.MovePosition (rb.position + speed);
		rb.velocity = new Vector2 (0, speed.y * 30f);
		movement = new Vector2 (
			0f,
			speed.y * 100f);	
		
		if(GameLoopFlag == 0){
			GameLoopFlag = 1;
		}
	}



}

