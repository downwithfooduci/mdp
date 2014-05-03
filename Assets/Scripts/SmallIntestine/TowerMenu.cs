using UnityEngine;
using System.Collections;

public class TowerMenu : MonoBehaviour 
{
	public bool IsEnabled;
	public Font font;

	// for sounds
	public GameObject sellSound;

	// for buttons
	public GUIStyle powerActive;
	public GUIStyle powerInactive;
	public GUIStyle speedActive;
	public GUIStyle speedInactive;
	public GUIStyle sellActive1;
	public GUIStyle sellActive2;
	public GUIStyle sellActive3;

	// for sell popup
	private bool displaySellBox;	// mark whether we should draw sell box
	public Texture sellConfirmBox;
	public GUIStyle confirmYes;
	public GUIStyle confirmNo;
	
	private Tower m_Tower;
	
	private Vector3 m_ScreenPosition;
	private int m_NumButtons;
	
	private IntestineGameManager m_GameManager;
	
	// Dimension and position consts
	private const int Y_GAP = 1;
	private float UPGRADE_BUTTON_WIDTH = 51;
	private float UPGRADE_BUTTON_HEIGHT = 60;
	private float SELL_BUTTON_WIDTH = 110;
	private float SELL_BUTTON_HEIGHT = 42;
	
	private bool m_MouseDownLastFrame;
	
	// Use this for initialization
    void Start()
    {
		UPGRADE_BUTTON_WIDTH = Screen.width * (76.5f / 1024f);  // Any size you want, multiply by 1.5 and divide by 1024 or 768
		UPGRADE_BUTTON_HEIGHT = Screen.height * (90f / 768f);
		SELL_BUTTON_WIDTH = Screen.width * (165f / 1024f);
		SELL_BUTTON_HEIGHT = Screen.height * (63f / 768f);
		m_GameManager = GameObject.Find ("Managers").GetComponent<IntestineGameManager>();

        m_Tower = gameObject.GetComponent<Tower>();

		m_NumButtons = 0;
	}
	
	public void Initialize()
	{
        m_ScreenPosition = MDPUtility.WorldToScreenPosition(transform.position);
		m_ScreenPosition.y -= Screen.height * (105f / 768f);
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
		GUI.depth -= 2;
		if(displaySellBox)
		{
			GUI.DrawTexture(new Rect(Screen.width * 0.3193359375f, 
			                         Screen.height * 0.28515625f, 
			                         Screen.width * 0.3603515625f, 
			                         Screen.height * 0.248697917f), sellConfirmBox);
			
			// draw yes button
			if (GUI.Button(new Rect(Screen.width * 0.41015625f, 
			                        Screen.height * 0.41927083f,
			                        Screen.width * 0.0654296875f,
			                        Screen.height * 0.06640625f), "", confirmYes))
			{
				displaySellBox = false;
				Sell ();
			}
			
			// draw no button
			if (GUI.Button(new Rect(Screen.width * 0.53125f, 
			                        Screen.height * 0.41927083f,
			                        Screen.width * 0.0654296875f,
			                        Screen.height * 0.06640625f), "", confirmNo))
			{
				displaySellBox = false;
			}

		}

		if (!IsEnabled)
			return;
		
		m_NumButtons = 0;
		
		switch (m_Tower.ActiveModelName)
		{
		case "Base":
			ShowPowerUpgrade();
			ShowSpeedUpgrade();
			ShowSell(sellActive1);
			break;
		case "Speed1":
			ShowSpeedUpgrade();
			ShowSell(sellActive2);
			break;
		case "Power1":
			ShowPowerUpgrade();
			ShowSell(sellActive2);
			break;
		default:
			ShowSell(sellActive3);
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
		Vector2 spawnPosition;
		spawnPosition.x = Mathf.Clamp(m_ScreenPosition.x, 
		                              (UPGRADE_BUTTON_WIDTH + Screen.width * (22.5f / 1024f)),
		                              Screen.width - (Screen.width * (22.5f / 1024f)) - UPGRADE_BUTTON_WIDTH);
		spawnPosition.y = Mathf.Clamp(m_ScreenPosition.y, 
		                              0, 
		                              Screen.height - UPGRADE_BUTTON_HEIGHT 
		                              - Screen.height * (30f / 768f) 
		                              - SELL_BUTTON_HEIGHT);

		Rect rect = new Rect(
			spawnPosition.x + Screen.width * (22.5f / 1024f), 
			spawnPosition.y, 
            UPGRADE_BUTTON_WIDTH,
			UPGRADE_BUTTON_HEIGHT);
	
		return rect;
	}

	private Rect GetSpeedButtonRect()
	{

		Vector2 spawnPosition;
		spawnPosition.x = Mathf.Clamp(m_ScreenPosition.x, 
		                              (UPGRADE_BUTTON_WIDTH + Screen.width * (22.5f / 1024f)),
		                              Screen.width - (Screen.width * (22.5f / 1024f)) - UPGRADE_BUTTON_WIDTH);
		spawnPosition.y = Mathf.Clamp(m_ScreenPosition.y, 
		                              0, 
		                              Screen.height - UPGRADE_BUTTON_HEIGHT 
		                              - Screen.height * (30f / 768f) 
		                              - SELL_BUTTON_HEIGHT);

		Rect rect = new Rect(
			spawnPosition.x - UPGRADE_BUTTON_WIDTH - Screen.width * (22.5f / 1024f), 
			spawnPosition.y, 
			UPGRADE_BUTTON_WIDTH,
			UPGRADE_BUTTON_HEIGHT);
		
		return rect;
	}

	private Rect GetSellButtonRect()
	{

		Vector2 spawnPosition;
		spawnPosition.x = Mathf.Clamp(m_ScreenPosition.x, 
		                              (UPGRADE_BUTTON_WIDTH + Screen.width * (22.5f / 1024f)),
		                              Screen.width - (Screen.width * (22.5f / 1024f)) - UPGRADE_BUTTON_WIDTH);
		spawnPosition.y = Mathf.Clamp(m_ScreenPosition.y, 
		                              0, 
		                              Screen.height - UPGRADE_BUTTON_HEIGHT 
		                              - Screen.height * (30f / 768f) 
		                              - SELL_BUTTON_HEIGHT);

		Rect rect = new Rect(
			spawnPosition.x - SELL_BUTTON_WIDTH / 2, 
			spawnPosition.y + UPGRADE_BUTTON_HEIGHT + Screen.height * (30f / 768f), 
			SELL_BUTTON_WIDTH,
			SELL_BUTTON_HEIGHT);
		
		return rect;
	}

	private void ShowSpeedUpgrade()
	{
		if (m_Tower.ActiveModelName == "Base")
		{
			if(m_GameManager.nutrients - m_Tower.TOWER_UPGRADE_LEVEL_1_COST < 0)
			{
				GUI.Button(GetSpeedButtonRect(), "", speedInactive);
			}
			else if (GUI.Button(GetSpeedButtonRect(), "Speed (" + -m_Tower.TOWER_UPGRADE_LEVEL_1_COST + ")", speedActive))
			{
				m_Tower.UpgradeSpeed();
				IsEnabled = false;
			}
		} else
		{
			if(m_GameManager.nutrients - m_Tower.TOWER_UPGRADE_LEVEL_2_COST < 0)
			{
				GUI.Button(GetSpeedButtonRect(), "", speedInactive);
			}
			else if (GUI.Button(GetSpeedButtonRect(), "Speed (" + -m_Tower.TOWER_UPGRADE_LEVEL_2_COST + ")", speedActive))
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
			if(m_GameManager.nutrients - m_Tower.TOWER_UPGRADE_LEVEL_1_COST < 0)
			{
				GUI.Button(GetPowerButtonRect(), "", powerInactive);
			}
			else if (GUI.Button(GetPowerButtonRect(), "Power (" + -m_Tower.TOWER_UPGRADE_LEVEL_1_COST + ")", powerActive))
			{
				m_Tower.UpgradePower();
				IsEnabled = false;
			}
		} else
		{
			if(m_GameManager.nutrients - m_Tower.TOWER_UPGRADE_LEVEL_2_COST < 0)
			{
				GUI.Button(GetPowerButtonRect(), "", powerInactive);
			}
			else if (GUI.Button(GetPowerButtonRect(), "Power (" + -m_Tower.TOWER_UPGRADE_LEVEL_2_COST + ")", powerActive))
			{
				m_Tower.UpgradePower();
				IsEnabled = false;
			}
		}
	}

	private void ShowSell(GUIStyle style)
	{
		if (GUI.Button(GetSellButtonRect(), "", style))
		{
			IsEnabled = false;
			displaySellBox = true;
		}
	}
	
	private void Sell()
	{
		// refund nutrients
		switch (m_Tower.ActiveModelName)
		{
		case "Base":
			m_GameManager.nutrients = m_GameManager.nutrients + (int)(.6*(m_Tower.TOWER_BASE_COST));
			break;
		case "Speed1":
			m_GameManager.nutrients = m_GameManager.nutrients + (int)(.6*(m_Tower.TOWER_BASE_COST +
				m_Tower.TOWER_UPGRADE_LEVEL_1_COST));
			break;
		case "Speed2":
			m_GameManager.nutrients = m_GameManager.nutrients + (int)(.6*(m_Tower.TOWER_BASE_COST +
				m_Tower.TOWER_UPGRADE_LEVEL_1_COST + m_Tower.TOWER_UPGRADE_LEVEL_2_COST));
			break;
		case "Power1":
			m_GameManager.nutrients = m_GameManager.nutrients + (int)(.6*(m_Tower.TOWER_BASE_COST +
				m_Tower.TOWER_UPGRADE_LEVEL_1_COST));
			break;
		case "Power2":
			m_GameManager.nutrients = m_GameManager.nutrients + (int)(.6*(m_Tower.TOWER_BASE_COST +
				m_Tower.TOWER_UPGRADE_LEVEL_1_COST + m_Tower.TOWER_UPGRADE_LEVEL_2_COST));
			break;
		default:
			break;
		} 

		Instantiate (sellSound);

		Destroy(gameObject);
	}
}
