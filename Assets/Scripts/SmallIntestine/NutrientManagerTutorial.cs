using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NutrientManagerTutorial : MonoBehaviour 
{
	public GameObject NutrientObj;
	
	private Dictionary<Color, List<NutrientTutorial>> m_Nutrients;
	
	void Awake () 
	{
		m_Nutrients = new Dictionary<Color, List<NutrientTutorial>>(new ColorComparer());
	}
	
	public NutrientTutorial InstantiateNutrient(Color color, Vector3 position, Quaternion rotation)
	{
		GameObject NutrientObject = Instantiate(NutrientObj, position, rotation) as GameObject;
		NutrientTutorial Nutrient = NutrientObject.GetComponent<NutrientTutorial>();
		Nutrient.BodyColor = color;
		
		if (!m_Nutrients.ContainsKey(color))
		{
			m_Nutrients.Add(color, new List<NutrientTutorial>());
		}
		
		m_Nutrients[color].Add(Nutrient);
		
		return Nutrient;
	}
	
	public NutrientTutorial InstantiateNutrient(Color color, Vector3 position)
	{
		return InstantiateNutrient(color, position, Quaternion.identity);
	}
	
	public void RemoveNutrient(NutrientTutorial n)
	{
		m_Nutrients[n.BodyColor].Remove(n);

		if (n.transform.parent.childCount == 1)
			Destroy(n.transform.parent.gameObject);
		else
			Destroy(n.gameObject);
	}
	
	public IList<NutrientTutorial> GetNutrients(Color color)
	{
		Debug.Log ("" + Color.red + " " + color);

		if (m_Nutrients.ContainsKey(color))
			return m_Nutrients[color].AsReadOnly();
		else
			return null;
	}
	
	public void ChangeColor(NutrientTutorial n, Color c)
	{
		m_Nutrients[n.BodyColor].Remove(n);
		n.BodyColor = c;
		
		if (!m_Nutrients.ContainsKey(c))
		{
			m_Nutrients.Add(c, new List<NutrientTutorial>());
		}
		
		m_Nutrients[c].Add(n);
	}
}
