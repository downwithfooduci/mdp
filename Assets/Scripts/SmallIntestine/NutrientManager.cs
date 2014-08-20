// Handles Nutrient instantiation/destruction
// Makes accessors available for tower targeting

using UnityEngine;
using System.Collections.Generic;

public class NutrientManager : MonoBehaviour 
{
    public GameObject NutrientObj;								// hold a nutrient gameobject

    private Dictionary<Color, List<Nutrient>> m_Nutrients;		// creates dictionary with list of all nutrients of each color

	void Awake () 
	{
        m_Nutrients = new Dictionary<Color, List<Nutrient>>(new ColorComparer());	// create the dictionary
	}

	// function that instantiates new nutrients
    public Nutrient InstantiateNutrient(Color color, Vector3 position, Quaternion rotation)
    {
        GameObject NutrientObject = Instantiate(NutrientObj, position, rotation) as GameObject;	// instantiate a nutrient
        Nutrient Nutrient = NutrientObject.GetComponent<Nutrient>();	// get the nutrient script from the newly instantiated nutrient
        Nutrient.BodyColor = color;										// set the color correctly

		// keep track of this nutrient in the dictionary
        if (!m_Nutrients.ContainsKey(color))	// if there is no list for this color in the dictionary, add it
        {
            m_Nutrients.Add(color, new List<Nutrient>());
        }

        m_Nutrients[color].Add(Nutrient);	// adds the nutrient to the dictionary

        return Nutrient;	// returns the newly created nutrient
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
