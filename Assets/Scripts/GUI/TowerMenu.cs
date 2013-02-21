using UnityEngine;
using System.Collections;

public class TowerMenu : MonoBehaviour {
	public bool IsEnabled;
	//public GUIStyle Style;
	
	private Tower m_Tower;
	
	private Vector3 m_ScreenPosition;
	private int m_NumButtons;
	
	// Dimension and position consts
	private const int Y_GAP = 1;
	private const int BUTTON_WIDTH = 50;
	private const int BUTTON_HEIGHT = 30;
	
	// Use this for initialization
    void Start()
    {
        m_Tower = gameObject.GetComponent<Tower>();
        m_ScreenPosition = MDPUtility.WorldToScreenPosition(transform.position);

		m_NumButtons = 0;
	}
	
	void OnGUI()
	{
		if (!IsEnabled)
			return;
		
		m_NumButtons = 0;
		
		if (GUI.Button(GetButtonRect(), "Sell"))
		{
			Sell();
		}
		
		switch (m_Tower.ActiveModelName)
		{
		case "Base":
			ShowPowerUpgrade();
			ShowSpeedUpgrade();
			break;
		case "Speed1":
			ShowSpeedUpgrade();
			break;
		case "Power1":
			ShowPowerUpgrade();
			break;
		default:
			break;
		}
		
	}
	
    // Returns a rectangle with an adjusted position for
    // the next button
	private Rect GetButtonRect()
	{
		Rect rect = new Rect(
            m_ScreenPosition.x, 
            m_ScreenPosition.y - m_NumButtons * (Y_GAP + BUTTON_HEIGHT), 
            BUTTON_WIDTH,
			BUTTON_HEIGHT);

		m_NumButtons++;
		return rect;
	}
	
	private void ShowSpeedUpgrade()
	{
		if (GUI.Button(GetButtonRect(), "Speed"))
		{
			m_Tower.UpgradeSpeed();
			IsEnabled = false;
		}
	}
	
	private void ShowPowerUpgrade()
	{
		if (GUI.Button(GetButtonRect(), "Power"))
		{
			m_Tower.UpgradePower();
			IsEnabled = false;
		}
	}
	
	private void Sell()
	{
		Destroy(gameObject);
	}
}
