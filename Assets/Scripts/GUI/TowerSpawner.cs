using UnityEngine;

public class TowerSpawner : MonoBehaviour {

    public GameObject[] Towers;
    public Color[] AvailableColors;

    public Rect Dimensions;

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
    }

    void Update ()
    {
        if (m_IsSpawnActive)
        {
            if (Input.GetMouseButtonUp(0))
            {
                m_IsSpawnActive = false;
                m_SpawnedTower.GetComponent<Tower>().enabled = true;
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
        //m_SpawnedTower.SetActive(false);
        m_IsSpawnActive = true;

        m_Spawned++;
    }
}
