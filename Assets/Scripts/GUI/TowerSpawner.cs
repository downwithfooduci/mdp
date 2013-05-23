using UnityEngine;
using System.Collections.Generic;

public class TowerSpawner : MonoBehaviour {
    // Randomly selects a tower model upon creation
    public GameObject[] Towers;

    // Set available tower colors in editor
    public Color[] AvailableColors;

    public GUIStyle ButtonStyle;
    public Rect Dimensions;

    private List<GameObject> m_SpawnAreas;

    private Rect m_ButtonSize;
    private bool m_IsSpawnActive;

    private GameObject m_SpawnedTower;

    void Start ()
    {
        m_IsSpawnActive = false;

        float totalWidth = Dimensions.width * AvailableColors.Length;

        Dimensions.x = (GuiUtility.ORIG_SCREEN_WIDTH - totalWidth) / 2;
        Dimensions.y = GuiUtility.ORIG_SCREEN_HEIGHT - Dimensions.height;
        m_ButtonSize = Dimensions;

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
                    m_SpawnedTower.transform.position = MDPUtility.MouseToWorldPosition() + new Vector3(0, 0.5f, 0);
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
        Matrix4x4 orig = GUI.matrix;
        GUI.matrix = GuiUtility.CachedScaledMatrix;

        for (int i = 0; i < AvailableColors.Length; i++)
        {
            GUI.backgroundColor = AvailableColors[i];
            m_ButtonSize.x = Dimensions.x + i * m_ButtonSize.width;

            if (GUI.RepeatButton(m_ButtonSize, "Drag", ButtonStyle) && !m_IsSpawnActive)
            {
                SpawnTower(AvailableColors[i]);
                m_SpawnedTower.GetComponent<Tower>().enabled = false;
                return;
            }
        }

        GUI.matrix = orig;
    }

    private void SpawnTower(Color color)
    {
        GameObject towerType = Towers[MDPUtility.RandomInt(Towers.Length)];
        m_SpawnedTower = Instantiate(towerType) as GameObject;
        m_SpawnedTower.GetComponent<Tower>().SetColor(color);
        m_IsSpawnActive = true;
    }

    private bool MouseCollides(UnityEngine.Collider c)
    {
        return c.bounds.Contains(MDPUtility.MouseToWorldPosition());
    }
}
