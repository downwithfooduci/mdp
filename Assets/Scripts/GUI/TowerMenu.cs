using UnityEngine;
using System.Collections;

public class TowerMenu : MonoBehaviour {
	public bool IsEnabled;
	public Font font;
	public GUIStyle powerActive;
	public GUIStyle powerInactive;
	public GUIStyle speedActive;
	public GUIStyle speedInactive;
	public GUIStyle sellActive;
	
	private Tower m_Tower;
	
	private Vector3 m_ScreenPosition;
	private int m_NumButtons;
	
	private IntestineGameManager m_GameManager;
	
	// Dimension and position consts
	private const int Y_GAP = 1;
	private const int UPGRADE_BUTTON_WIDTH = 51;
	private const int UPGRADE_BUTTON_HEIGHT = 60;
	private const int SELL_BUTTON_WIDTH = 110;
	private const int SELL_BUTTON_HEIGHT = 42;
	
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
		m_ScreenPosition.y -= 70;
	}
	
	void LateUpdate()
	{
		bool mouseDown = Input.GetMouseButtonDown(0);
		
		if (m_MouseDownLastFrame && !mouseDown)
			StartCoroutine(CheckMouseClick());		// need to use startcoroutine because the function is of type ienumerator so we can delay the thread
													// without this delay the menu DOES NOT function properly due to the execution order of functions
		
		m_MouseDownLastFrame = mouseDown;
	}
	
	void OnGUI()
	{

		if (!IsEnabled)
			return;
		
		m_NumButtons = 0;
		
		if (GUI.Button(GetSellButtonRect(), "", sellActive))
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
	
	private IEnumerator CheckMouseClick()
	{
		EnableRayCasts(true);
		
		Vector3 mousePos = MDPUtility.MouseToWorldPosition();
		mousePos.y = 5;
		RaycastHit hitInfo;
			
		// check if we click on a tower
		if (Physics.Raycast(mousePos, Vector3.down, out hitInfo, mousePos.y)) 
		{
			// if we click on tower, toggle whether menu is showed
			if (hitInfo.transform == transform)
				IsEnabled = !IsEnabled;
		} else
		{
			// otherwise if we clicked in a random place cancel the menu
			yield return new WaitForSeconds(.1f);
			IsEnabled = false;
		}
		yield return new WaitForSeconds(.0f);
		EnableRayCasts(false);
	}
	
	private void EnableRayCasts(bool val)
	{
		string layer = val ? "Default" : "Ignore Raycast";
		
		gameObject.layer = LayerMask.NameToLayer(layer);
	}
	
    // Returns a rectangle with an adjusted position for
    // the next button
	private Rect GetPowerButtonRect()
	{
		Rect rect = new Rect(
            m_ScreenPosition.x + 15, 
            m_ScreenPosition.y, 
            UPGRADE_BUTTON_WIDTH,
			UPGRADE_BUTTON_HEIGHT);
	
		return rect;
	}

	private Rect GetSpeedButtonRect()
	{
		Rect rect = new Rect(
			m_ScreenPosition.x - UPGRADE_BUTTON_WIDTH - 15, 
			m_ScreenPosition.y, 
			UPGRADE_BUTTON_WIDTH,
			UPGRADE_BUTTON_HEIGHT);
		
		return rect;
	}

	private Rect GetSellButtonRect()
	{
		Rect rect = new Rect(
			m_ScreenPosition.x - SELL_BUTTON_WIDTH / 2, 
			m_ScreenPosition.y + UPGRADE_BUTTON_HEIGHT + 20, 
			SELL_BUTTON_WIDTH,
			SELL_BUTTON_HEIGHT);
		
		return rect;
	}
	
	private void ShowSpeedUpgrade()
	{
		if (m_Tower.ActiveModelName == "Base")
		{
			if(m_GameManager.Nutrients - m_Tower.TOWER_UPGRADE_LEVEL_1_COST < 0)
			{
				GUI.Button(GetSpeedButtonRect(), "", speedInactive);
			}
			else if (GUI.Button(GetSpeedButtonRect(), "Speed (" + m_Tower.TOWER_UPGRADE_LEVEL_1_COST + ")", speedActive))
			{
				m_Tower.UpgradeSpeed();
				IsEnabled = false;
			}
		} else
		{
			if(m_GameManager.Nutrients - m_Tower.TOWER_UPGRADE_LEVEL_2_COST < 0)
			{
				GUI.Button(GetSpeedButtonRect(), "", speedInactive);
			}
			else if (GUI.Button(GetSpeedButtonRect(), "Speed (" + m_Tower.TOWER_UPGRADE_LEVEL_2_COST + ")", speedActive))
			{
				m_Tower.UpgradeSpeed();
				IsEnabled = false;
			}
		}
	}
	
	private void ShowPowerUpgrade()
	{
		if (m_Tower.ActiveModelName == "Base")
		{
			if(m_GameManager.Nutrients - m_Tower.TOWER_UPGRADE_LEVEL_1_COST < 0)
			{
				GUI.Button(GetPowerButtonRect(), "", powerInactive);
			}
			else if (GUI.Button(GetPowerButtonRect(), "Power (" + m_Tower.TOWER_UPGRADE_LEVEL_1_COST + ")", powerActive))
			{
				m_Tower.UpgradePower();
				IsEnabled = false;
			}
		} else
		{
			if(m_GameManager.Nutrients - m_Tower.TOWER_UPGRADE_LEVEL_2_COST < 0)
			{
				GUI.Button(GetPowerButtonRect(), "", powerInactive);
			}
			else if (GUI.Button(GetPowerButtonRect(), "Power (" + m_Tower.TOWER_UPGRADE_LEVEL_2_COST + ")", powerActive))
			{
				m_Tower.UpgradePower();
				IsEnabled = false;
			}
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
