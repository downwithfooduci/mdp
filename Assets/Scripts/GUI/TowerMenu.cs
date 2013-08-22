using UnityEngine;
using System.Collections;

public class TowerMenu : MonoBehaviour {
	public bool IsEnabled;
	//public GUIStyle Style;
	
	private Tower m_Tower;
	
	private Vector3 m_ScreenPosition;
	private int m_NumButtons;
	
	private IntestineGameManager m_GameManager;
	
	// Dimension and position consts
	private const int Y_GAP = 1;
	private const int BUTTON_WIDTH = 50;
	private const int BUTTON_HEIGHT = 30;
	
	private bool m_MouseDownLastFrame;
	
	// Use this for initialization
    void Start()
    {
		m_GameManager = GameObject.Find ("Managers").GetComponent<IntestineGameManager>();

        m_Tower = gameObject.GetComponent<Tower>();

		m_NumButtons = 0;
	}
	
	public void Initialize()
	{
        m_ScreenPosition = MDPUtility.WorldToScreenPosition(transform.position);
		m_ScreenPosition.x += 15;
	}
	
	void Update()
	{
		bool mouseDown = Input.GetMouseButtonDown(0);
		
		if (m_MouseDownLastFrame && !mouseDown)
			CheckMouseClick();
		
		m_MouseDownLastFrame = mouseDown;
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
	
	private void CheckMouseClick()
	{
		EnableRayCasts(true);
		
		Vector3 mousePos = MDPUtility.MouseToWorldPosition();
		mousePos.y = 5;
		RaycastHit hitInfo;
			
		if (Physics.Raycast(mousePos, Vector3.down, out hitInfo, mousePos.y)) 
		{
			if (hitInfo.transform == transform)
				IsEnabled = !IsEnabled;
		}
		
		EnableRayCasts(false);
	}
	
	private void EnableRayCasts(bool val)
	{
		string layer = val ? "Default" : "Ignore Raycast";
		
		gameObject.layer = LayerMask.NameToLayer(layer);
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
		// refund nutrients
		switch (m_Tower.ActiveModelName)
		{
		case "Base":
			m_GameManager.Nutrients = m_GameManager.Nutrients + (int)(.6*(m_Tower.TOWER_BASE_COST));
			break;
		case "Speed1":
			m_GameManager.Nutrients = m_GameManager.Nutrients + (int)(.6*(m_Tower.TOWER_BASE_COST +
				m_Tower.TOWER_UPGRADE_LEVEL_1_COST));
			break;
		case "Speed2":
			m_GameManager.Nutrients = m_GameManager.Nutrients + (int)(.6*(m_Tower.TOWER_BASE_COST +
				m_Tower.TOWER_UPGRADE_LEVEL_1_COST + m_Tower.TOWER_UPGRADE_LEVEL_2_COST));
			break;
		case "Power1":
			m_GameManager.Nutrients = m_GameManager.Nutrients + (int)(.6*(m_Tower.TOWER_BASE_COST +
				m_Tower.TOWER_UPGRADE_LEVEL_1_COST));
			break;
		case "Power2":
			m_GameManager.Nutrients = m_GameManager.Nutrients + (int)(.6*(m_Tower.TOWER_BASE_COST +
				m_Tower.TOWER_UPGRADE_LEVEL_1_COST + m_Tower.TOWER_UPGRADE_LEVEL_2_COST));
			break;
		default:
			break;
		}
		
		Destroy(gameObject);
	}
}
