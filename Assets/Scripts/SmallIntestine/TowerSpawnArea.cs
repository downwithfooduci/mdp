using UnityEngine;
using System.Collections;

public class TowerSpawnArea : MonoBehaviour 
{
	private TowerSpawnerTutorial towerSpawner;

	void Start () 
	{
		towerSpawner = FindObjectOfType(typeof(TowerSpawnerTutorial)) as TowerSpawnerTutorial;
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
