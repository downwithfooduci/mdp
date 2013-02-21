// Container class for a food blob.
// Blob itself has no physical form but
// contains enzymes as children

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodBlob : MonoBehaviour {

	public float Velocity;
	public float RotationSpeed;

    public GameObject Enzyme;
	public int NumEnzymes;
	
	private ushort m_FoodLife;	
	private GameObject m_EndPoint;

    private static Color[] s_AvailableColors = { Color.red, Color.white, Color.yellow, Color.green };
		
	// Use this for initialization
	void Start () {
        // End-point object here
       // m_EndPoint = GameObject.Find("End");
		
		GenerateEnzymes();
	}
	
	private void GenerateEnzymes()
	{
        EnzymeManager manager = FindObjectOfType(typeof(EnzymeManager)) as EnzymeManager;

		for(int i = 0; i < NumEnzymes; i++)
        {
            // Place enzyme generation code here
            Vector3 position = transform.position;
            position.x += i * 0.9f;

            int randomIndex = MDPUtility.RandomInt(s_AvailableColors.Length);
			Enzyme enzyme = manager.InstantiateEnzyme(s_AvailableColors[randomIndex], position);
			
			// Attach new enzyme as a child object
			enzyme.transform.parent = gameObject.transform;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
    //protected override void CheckCollisions()
    //{
    //    if (m_EndPoint && Collider.CollidesWith(m_EndPoint))
    //    {
    //        OnEndPointCollision();
    //    }
    //}
	
	private void OnEndPointCollision()
	{
        //if(m_FoodLife > 0)
        //{
        //    SmallIntestineGUI.health--;
        //}
        //if(transform.gameObject.layer == 16)
        //    SmallIntestineGUI.health--;
		Destroy(gameObject);
	}
	
	public void TakeHit()
	{
		m_FoodLife--;
	}
	
	void OnMouseDown()
	{
        GetComponent<FollowITweenPath>().enabled = false;
	}
	
	void OnMouseUp()
	{
        GetComponent<FollowITweenPath>().enabled = true;
	}
}
