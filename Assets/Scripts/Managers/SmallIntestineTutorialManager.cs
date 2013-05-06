using UnityEngine;
using System.Collections;

public class SmallIntestineTutorialManager : MonoBehaviour {

    public GameObject FoodBlob;

    public Color CurrentColor
    {
        get { return Colors[m_CurrentLevel]; }
    }

    private static Color[] Colors = { Color.yellow, Color.red, Color.white };
    private int m_CurrentLevel;

	// Use this for initialization
	void Start () {
        m_CurrentLevel = 0;
        SpawnNutrient();
	}

    public void AdvanceLevel()
    {
        if (m_CurrentLevel < Colors.Length - 1)
        {
            m_CurrentLevel++;
            SpawnNutrient();
        }
        else
            OnTutorialFinish();
    }

    private void SpawnNutrient()
    {
        Instantiate(FoodBlob, new Vector3(-30, 0, 1), Quaternion.identity);
    }

    private void OnTutorialFinish()
    {

    }

    private void Reset()
    {
        SpawnNutrient();
    }
}
