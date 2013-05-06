using UnityEngine;
using System.Collections.Generic;

public class TowerSpawner : MonoBehaviour {

    public GameObject[] Towers;
    public Color[] AvailableColors;

    public Rect Dimensions;

    private List<GameObject> m_SpawnAreas;

    private Rect m_ButtonSize;
    private bool m_IsSpawnActive;

    private GameObject m_SpawnedTower;

    private int m_Spawned;

    void Start ()
    {
        m_IsSpawnActive = false;

        m_ButtonSize = Dimensions;
        m_ButtonSize.width /= AvailableColors.Length;

        m_Spawned = 0;

        GameObject spawnAreaObject = GameObject.FindGameObjectWithTag("SpawnArea");
        m_SpawnAreas = new List<GameObject>();
        foreach (Transform child in spawnAreaObject.transform)
        {
            m_SpawnAreas.Add(child.gameObject);
        }
    }

    void Update ()
    {
        // Handle valid spawn locations if player is spawning a tower
        if (m_IsSpawnActive)
        {
            bool isValidSpawnArea = false;
            foreach (GameObject area in m_SpawnAreas)
            {
                if (MouseCollides(area.collider))
                {
                    isValidSpawnArea = true;
                    break;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                m_IsSpawnActive = false;
                if (isValidSpawnArea)
                {
                    m_SpawnedTower.GetComponent<Tower>().enabled = true;
                    m_SpawnedTower.transform.position = MDPUtility.MouseToWorldPosition();
                }
                else
                {
                    Destroy(m_SpawnedTower);
                    m_SpawnedTower = null;
                }
            }
            else
            {
                m_SpawnedTower.transform.position = MDPUtility.MouseToWorldPosition();
            }
        }
    }

    void OnGUI ()
    {
        GUI.Box(Dimensions, "");

        for (int i = 0; i < AvailableColors.Length; i++)
        {
            GUI.backgroundColor = AvailableColors[i];
            m_ButtonSize.x = Dimensions.x + i * m_ButtonSize.width;

            if (GUI.RepeatButton(m_ButtonSize, "Drag") && !m_IsSpawnActive)
            {
                SpawnTower(AvailableColors[i]);
                m_SpawnedTower.GetComponent<Tower>().enabled = false;
                return;
            }
        }
    }

    private void SpawnTower(Color color)
    {
        GameObject towerType = Towers[MDPUtility.RandomInt(Towers.Length)];
        m_SpawnedTower = Instantiate(towerType, new Vector3(m_Spawned * 1.2f, 0, 0), Quaternion.identity) as GameObject;
        m_SpawnedTower.GetComponent<Tower>().SetColor(color);
        m_IsSpawnActive = true;

        m_Spawned++;
    }

    // Returns true if mouse is over a collider object
    private bool MouseCollides(UnityEngine.Collider c)
    {
        return c.bounds.Contains(MDPUtility.MouseToWorldPosition());
    }
}
