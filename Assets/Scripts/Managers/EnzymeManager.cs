// Handles enzyme instantiation/destruction
// Makes accessors available for tower targetting

using UnityEngine;
using System.Collections.Generic;

public class EnzymeManager : MonoBehaviour {
    public GameObject Enzyme;

    private Dictionary<Color, List<Enzyme>> m_Enzymes;

	// Use this for initialization
	void Start () {
        m_Enzymes = new Dictionary<Color, List<Enzyme>>(new ColorComparer());
	}

    public Enzyme InstantiateEnzyme(Color color, Vector3 position, Quaternion rotation)
    {
        GameObject enzymeObject = Instantiate(Enzyme, position, rotation) as GameObject;
        Enzyme enzyme = enzymeObject.GetComponent<Enzyme>();
        enzyme.BodyColor = color;

        if (!m_Enzymes.ContainsKey(color))
        {
            m_Enzymes.Add(color, new List<Enzyme>());
        }

        m_Enzymes[color].Add(enzyme);

        return enzyme;
    }

    public Enzyme InstantiateEnzyme(Color color, Vector3 position)
    {
        return InstantiateEnzyme(color, position, Quaternion.identity);
    }

    public void RemoveEnzyme(Enzyme enzyme)
    {
        m_Enzymes[enzyme.BodyColor].Remove(enzyme);

        if (enzyme.transform.parent.childCount == 1)
            Destroy(enzyme.transform.parent.gameObject);
        else
            Destroy(enzyme.gameObject);
    }

    public IList<Enzyme> GetEnzymes(Color color)
    {
        if (m_Enzymes.ContainsKey(color))
            return m_Enzymes[color].AsReadOnly();
        else
            return null;
    }
}
