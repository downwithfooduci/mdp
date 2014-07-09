using UnityEngine;
using System.Collections;

public class TowerSpawnArea : MonoBehaviour 
{
	private TowerSpawner towerSpawner;

	void Start () 
	{
		towerSpawner = FindObjectOfType(typeof(TowerSpawner)) as TowerSpawner;
	}

    void OnMouseOver()
    {
	    towerSpawner.IsMouseOverWall = true;
		towerSpawner.wall = gameObject;
    }

    void OnMouseExit()
    {
		towerSpawner.IsMouseOverWall = false;
    }
}
