using UnityEngine;
using System.Collections;

public class TowerSpawnArea : MonoBehaviour 
{
	private TowerSpawner towerSpawner;
	private TowerSpawnerTutorial towerSpawnerTutorial;

	void Start () 
	{
		if (Application.loadedLevelName == "SmallIntestineTutorial")
		{
			towerSpawnerTutorial = FindObjectOfType(typeof(TowerSpawnerTutorial)) as TowerSpawnerTutorial;
		} else
		{
			towerSpawner = FindObjectOfType(typeof(TowerSpawner)) as TowerSpawner;
		}
	}

    void OnMouseOver()
    {
		if (Application.loadedLevelName == "SmallIntestineTutorial")
		{
			towerSpawnerTutorial.IsMouseOverWall = true;
			towerSpawnerTutorial.wall = gameObject;
		} else
		{
	        towerSpawner.IsMouseOverWall = true;
			towerSpawner.wall = gameObject;
		}
    }

    void OnMouseExit()
    {
		if (Application.loadedLevelName == "SmallIntestineTutorial")
		{
			towerSpawnerTutorial.IsMouseOverWall = false;
		} else
		{
			towerSpawner.IsMouseOverWall = false;
		}
    }
}
