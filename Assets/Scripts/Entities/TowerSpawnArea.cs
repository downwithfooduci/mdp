using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class TowerSpawnArea : MonoBehaviour {
    public bool IsMouseOver
    {
        get { return m_IsMouseOver; }
    }
    private bool m_IsMouseOver;

	// Use this for initialization
	void Start () {
        m_IsMouseOver = false;
	}

    void OnMouseEnter()
    {
        m_IsMouseOver = true;
    }

    void OnMouseExit()
    {
        m_IsMouseOver = false;
    }
}
