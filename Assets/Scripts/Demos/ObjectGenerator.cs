using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour {
	
	public int toGenerate;
	
	public Transform prefabSquare;
	public Transform prefabCircle;
	public Transform prefabCapsule;
	//private Transform[] prefabChoice = {prefabSquare, prefabCircle, prefabCapsule};
	private int prefabIndex;
	
	private Vector3 initialPosition;
	
	private TestMover[] particles;
	//private Wall[] walls;
	
	//random radius and color
	private int colorIndex;
	private Color[] colorChoice = {Color.green, Color.white, Color.yellow, Color.blue, Color.red};
	
	//GameObject is scripts parent.
	
	// Use this for initialization
	void Start ()
	{
		
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
		
		
		
	
}


