using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour {
	
	public int toGenerate;
	
	public Transform[] prefabLargeEnzyme;
	public Transform[] foodParticles;
	
	private int prefabIndex;
	public float TimePass;
	
	private Vector3 initialPosition;
	
	public static TestMover[] particles;
	
	//For GUI
	public static int totalCounter;
	public static int playerScore = 0;
	
	//random color
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
			Instantiate(foodParticles[prefabIndex], initialPosition, new Quaternion(0,0,0,0));	
		}
		particles = Object.FindObjectsOfType(typeof(TestMover)) as TestMover[];
		
		//code for random color
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
		if(GUI.Button(new Rect(Screen.width - 120,Screen.height -50 ,100,40), "Generator"))
		{	
			prefabIndex = Random.Range (0,3);
			colorIndex = Random.Range(0, 5);
			Instantiate(foodParticles[prefabIndex], initialPosition, new Quaternion(0,0,0,0));
			particles = Object.FindObjectsOfType(typeof(TestMover)) as TestMover[];
			particles[0].renderer.material.color = colorChoice[colorIndex];
		}
		
		if (GUI.Button(new Rect(Screen.width - 120,Screen.height -100 ,100,40), "RedEnzyme")) 
		{
			if(!EnzymesExist)
			{
			 	Instantiate(prefabLargeEnzyme[0], transform.position, transform.rotation);
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 120,Screen.height -150 ,100,40), "GreenEnzyme")) 
		{
			if(!EnzymesExist)
			{
			 	Instantiate(prefabLargeEnzyme[1], transform.position, transform.rotation);
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 120,Screen.height -200 ,100,40), "BlueEnzyme")) 
		{
			if(!EnzymesExist)
			{
			 	Instantiate(prefabLargeEnzyme[2], transform.position, transform.rotation);
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 120,Screen.height -250 ,100,40), "YellowEnzyme")) 
		{
			if(!EnzymesExist)
			{
			 	Instantiate(prefabLargeEnzyme[3], transform.position, transform.rotation);
				EnzymesExist = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 120,Screen.height -300 ,100,40), "WhiteEnzyme")) 
		{
			if(!EnzymesExist){
			 	Instantiate(prefabLargeEnzyme[4], transform.position, transform.rotation);
				EnzymesExist = true;
			}
		}
		
	}
		
	
}


