using UnityEngine;
using System.Collections;

public class TowerSpawnArea : MonoBehaviour {
	
	private TowerSpawner m_TowerSpawner;

	void Start () {
		m_TowerSpawner = FindObjectOfType(typeof(TowerSpawner)) as TowerSpawner;
	}

    void OnMouseOver()
    {
        m_TowerSpawner.IsMouseOverWall = true;
		m_TowerSpawner.wall = gameObject;
    }

    void OnMouseExit()
    {
        m_TowerSpawner.IsMouseOverWall = false;
    }
}
