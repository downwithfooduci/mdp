// Handles Nutrient instantiation/destruction
// Makes accessors available for tower targeting

using UnityEngine;
using System.Collections.Generic;

public class NutrientManager : MonoBehaviour 
{
    public GameObject NutrientObj;

    private Dictionary<Color, List<Nutrient>> m_Nutrients;

	void Awake () 
	{
        m_Nutrients = new Dictionary<Color, List<Nutrient>>(new ColorComparer());
	}

    public Nutrient InstantiateNutrient(Color color, Vector3 position, Quaternion rotation)
    {
        GameObject NutrientObject = Instantiate(NutrientObj, position, rotation) as GameObject;
        Nutrient Nutrient = NutrientObject.GetComponent<Nutrient>();
        Nutrient.BodyColor = color;

        if (!m_Nutrients.ContainsKey(color))
        {
            m_Nutrients.Add(color, new List<Nutrient>());
        }

        m_Nutrients[color].Add(Nutrient);

        return Nutrient;
    }

    public Nutrient InstantiateNutrient(Color color, Vector3 position)
    {
        return InstantiateNutrient(color, position, Quaternion.identity);
    }

    public void RemoveNutrient(Nutrient n)
    {
   		 m_Nutrients[n.BodyColor].Remove(n);


        if (n.transform.parent.childCount == 1)
            Destroy(n.transform.parent.gameObject);
        else
            Destroy(n.gameObject);
    }

    public IList<Nutrient> GetNutrients(Color color)
    {
        if (m_Nutrients.ContainsKey(color))
            return m_Nutrients[color].AsReadOnly();
        else
            return null;
    }

    public void ChangeColor(Nutrient n, Color c)
    {
        m_Nutrients[n.BodyColor].Remove(n);
        n.BodyColor = c;

        if (!m_Nutrients.ContainsKey(c))
        {
            m_Nutrients.Add(c, new List<Nutrient>());
        }

        m_Nutrients[c].Add(n);
    }
}
