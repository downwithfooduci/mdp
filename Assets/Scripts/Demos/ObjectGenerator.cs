using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour {
	
	public int toGenerate;
	
	public Transform prefabSquare;
	public Transform prefabCircle;
	public Transform prefabCapsule;
	
	public Transform[] prefabChoice;
	
	private int prefabIndex;
	public float TimePass;
	
	private Vector3 initialPosition;
	
	public static TestMover[] particles;
	//private Wall[] walls;
	
	//For GUI
	public static int totalCounter;
	public static int playerScore = 0;
	/*public UILabel scoreText;
	public UILabel particleText;
	public UILabel collisionText;
	
	void UpdateGUI) {
		scoreText.text = "" + playerScore;
		particleText.text = "" + totalCounter;
		collisionText.text = "" + Particle.collisionConter;
	}
	*/
	
	//random radius and color
	private int colorIndex;
	private Color[] colorChoice = {Color.green, Color.white, Color.yellow, Color.blue, Color.red};
	
	//GameObject is scripts parent.
	
	//this parts for buttons
	public GameObject ColorPrefeb;
	public static bool EnzymesExist = false;
	
	// Use this for initialization
	void Start ()
	{
		totalCounter = toGenerate;
		
		for(int i = 0; i < toGenerate; i++)
		{
			initialPosition = new Vector3(Random.Range (-10,18),0,Random.Range (-7,7));
			prefabIndex = Random.Range (0,3);
			switch(prefabIndex)
			{
				case 0:
				{
					Instantiate(prefabSquare, initialPosition, new Quaternion(0,0,0,0));
					break;
				}
				case 1:
				{
					Instantiate(prefabCircle, initialPosition, new Quaternion(0,0,0,0));
					break;
				}
				case 2:
				{
					Instantiate(prefabCapsule, initialPosition, new Quaternion(0,0,0,0));
					break;
				}
			}
			
		}
		particles = Object.FindObjectsOfType(typeof(TestMover)) as TestMover[];
		
		//walls = Object.FindObjectsOfType(typeof(Wall)) as Wall[];

		//code for random radius and color
		for(int j = 0; j < particles.Length; j++) 
		{
			colorIndex = Random.Range(0, 5);
			particles[j].renderer.material.color = colorChoice[colorIndex];
		}
		
	}
	
	void startCheck()
	{}
	
	
	// Update is called once per frame
	void Update ()
	{}
	
	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width - 120,Screen.height -50 ,100,40), "Generator")){
			//Instantiate(prefabChoice[Random.Range(0,3)], transform.position, transform.rotation);
			//particles = Object.FindObjectsOfType(typeof(Particle)) as TestMover[];
			//particles[0].renderer.material.color = Color.green;	
			Instantiate(prefabCapsule, initialPosition, new Quaternion(0,0,0,0));
			particles = Object.FindObjectsOfType(typeof(TestMover)) as TestMover[];
			colorIndex = Random.Range(0, 5);
			particles[0].renderer.material.color = colorChoice[colorIndex];
		}
		
		if (GUI.Button(new Rect(Screen.width - 120,Screen.height -100 ,100,40), "RedEnzyme")) {
			if(!EnzymesExist){
			 	Instantiate(prefabChoice[0], transform.position, transform.rotation);
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 120,Screen.height -150 ,100,40), "GreenEnzyme")) {
			if(!EnzymesExist){
			 	Instantiate(prefabChoice[1], transform.position, transform.rotation);
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 120,Screen.height -200 ,100,40), "BlueEnzyme")) {
			if(!EnzymesExist){
			 	Instantiate(prefabChoice[2], transform.position, transform.rotation);
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 120,Screen.height -250 ,100,40), "YellowEnzyme")) {
			if(!EnzymesExist){
			 	Instantiate(prefabChoice[3], transform.position, transform.rotation);
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 120,Screen.height -300 ,100,40), "WhiteEnzyme")) {
			if(!EnzymesExist){
			 	Instantiate(prefabChoice[4], transform.position, transform.rotation);
				EnzymesExist = true;
			}
		}
		
	}
		
	
}


