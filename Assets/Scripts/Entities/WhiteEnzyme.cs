using UnityEngine;
using System.Collections;

public class WhiteEnzyme : Enzyme {
	
	void Start () {
		m_Parent = gameObject.transform.parent.gameObject;
		//m_NutrientScript = gameObject.GetComponent<NutrientScript>();
	}
	
	void Update () {
		//if(!m_NutrientScript.GetIsDead())
			CheckCollisions();
	}
	
	protected override void Absorb()
	{
        //NutrientScript tmp = gameObject.GetComponent<NutrientScript>();
        //if(!tmp.GetIsHit())
        //{
        //    //turn to green
        //    tmp.TurnToGreen();
        //    // Commented this out since Halo doesn't seem to exist in this project
        //    // SetGlowEnabled(true);
        //    tmp.SetIsHit(true);
        //}
	}
	
	private void SetGlowEnabled(bool value)
	{
		Behaviour tmp = gameObject.GetComponent("Halo") as Behaviour;
		tmp.enabled = value;
	}
}
