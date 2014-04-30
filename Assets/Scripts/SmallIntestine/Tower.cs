using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour {
	public int TOWER_BASE_COST = 20;
	public int TOWER_UPGRADE_LEVEL_1_COST = 50;
	public int TOWER_UPGRADE_LEVEL_2_COST = 50;
	
	DebugConfig debugConfig;
	
	public GameObject Projectile;

	public GameObject wall;

	public string ActiveModelName
	{
		get { return m_ActiveModelName; }
	}
	private string m_ActiveModelName;
	
	public float FiringRange;
	
	// Firing cooldown in seconds
	public float BaseCooldown;
	public float Level1Cooldown;
	public float Level2Cooldown;

	// for power towers, max blobs killed at once
	public int baseTargets = 1;
	public int level1Targets = 3;
	public int level2Targets = 6;
	
	private TowerMenu m_Menu;
    private Transform m_ActiveModel;

    private Color m_TargetColor;
    private NutrientManager m_NutrientManager;
	private IntestineGameManager m_GameManager;

	private float m_Cooldown;
	private int targets;
	private float m_CurrentCooldown;
	private bool m_CanFire;

	private const float timer = 2.0f;	// for displaying text messages
	private float timePassed = 0.0f;
	private string message = "";
		
	// Use this for initialization
	void Start () {
		debugConfig = ((GameObject)GameObject.Find("Debug Config")).GetComponent<DebugConfig>();
		TOWER_BASE_COST = debugConfig.TOWER_BASE_COST;
		TOWER_UPGRADE_LEVEL_1_COST = debugConfig.TOWER_UPGRADE_LEVEL_1_COST;
		TOWER_UPGRADE_LEVEL_2_COST = debugConfig.TOWER_UPGRADE_LEVEL_2_COST;
		m_Cooldown = BaseCooldown;
		m_CurrentCooldown = m_Cooldown;
		m_CanFire = true;

        m_NutrientManager = GameObject.Find("Managers").GetComponent<NutrientManager>();
		m_GameManager = GameObject.Find ("Managers").GetComponent<IntestineGameManager>();
		
		m_Menu = gameObject.GetComponent<TowerMenu>();
		
		foreach (Transform child in transform)
		{
			child.localPosition = Vector3.zero;
			child.gameObject.SetActive(false);
		}
		
		SetActiveModel("Base");		
	}

	// for displaying text messages
	void OnGUI()
	{
		GUI.depth--;

		if (timePassed > 0)
		{
			timePassed -= Time.deltaTime;
			GUIStyle style = new GUIStyle();
			style.fontSize = 16;
			style.alignment = TextAnchor.MiddleCenter;
			style.normal.textColor = Color.white;
			GUI.Label(new Rect(Screen.width * 0.0185546875f, Screen.height * 0.83f, Screen.width * 0.775390625f, Screen.height * 0.02604167f), message, style); // sort of center the message
		}
	}
	
	// Update is called once per frame
	void Update () {
		switch (m_ActiveModelName)
		{
		case "Base":
			m_Cooldown = debugConfig.BaseCooldown;
			targets = debugConfig.baseTargets;
			break;
		case "Speed1":
			m_Cooldown = debugConfig.Level1Cooldown;
			break;
		case "Speed2":
			m_Cooldown = debugConfig.Level2Cooldown;
			break;
		case "Power1":
			targets = debugConfig.level1Targets;
			break;
		case "Power2":
			targets = debugConfig.level2Targets;
			break;
		default:
			break;
		}
		TOWER_BASE_COST = debugConfig.TOWER_BASE_COST;
		TOWER_UPGRADE_LEVEL_1_COST = debugConfig.TOWER_UPGRADE_LEVEL_1_COST;
		TOWER_UPGRADE_LEVEL_2_COST = debugConfig.TOWER_UPGRADE_LEVEL_2_COST;
		if (m_CanFire)
		{
            Fire();
		}
		else
		{
			m_CurrentCooldown -= Time.deltaTime;
			if (m_CurrentCooldown <= 0f)
			{
				m_CanFire = true;
				m_CurrentCooldown = m_Cooldown;
			}
		}
	}

    public void SetColor(Color color)
    {
        m_TargetColor = color;

        foreach (Transform child in transform)
        {
            Transform circle = child.FindChild("Circle");
            circle.renderer.materials[0].color = m_TargetColor;
        }
    }
	
	private void SetActiveModel(string name)
	{
		if(m_ActiveModelName != null)
			m_ActiveModel.gameObject.SetActive(false);
		
		m_ActiveModelName = name;
        m_ActiveModel = transform.FindChild(m_ActiveModelName);
		m_ActiveModel.gameObject.SetActive(true);
	}
	
	private void Fire()
	{
        Nutrient target = AcquireTarget();
        if (target)
        {
			transform.Rotate(new Vector3(90,0,0), -40, Space.World);
            // Look at target but lock rotation on x axis
            float xRotation = transform.rotation.eulerAngles.x;
            transform.LookAt(target.transform);
			transform.Rotate(new Vector3(90,0,0), 40, Space.World);
            //Vector3 euler = transform.rotation.eulerAngles;
            //euler.x = xRotation;
            //transform.rotation = Quaternion.Euler(euler);
            transform.FindChild(m_ActiveModelName).animation.Play("Default Take", PlayMode.StopAll);

            GameObject bulletObject = Instantiate(Projectile, transform.position, transform.rotation) as GameObject;
            bulletObject.renderer.material.color = m_TargetColor;

            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.Target = target.gameObject;
			bullet.targets = targets;

            target.IsTargetted = true;

            m_CanFire = false;
        }
	}

    // Returns closest nutrient within range of TargetColor's type 
    // that isn't already targeted and is in direct line of sight
    // or null if there are no valid targets
    private Nutrient AcquireTarget()
    {
        IList<Nutrient> nutrients = m_NutrientManager.GetNutrients(m_TargetColor);
        if (nutrients == null)
        {
            return null;
        }

        Nutrient closestNutrient = null;
        float closestDistance = float.MaxValue;

        foreach (Nutrient e in nutrients)
        {
            if (!e.IsTargetted)
            {
                float distance = MDPUtility.DistanceSquared(gameObject, e.gameObject);

                if (distance < closestDistance && distance < FiringRange * FiringRange && IsInLineOfSight(e.transform))
                {
                    closestNutrient = e;
                    closestDistance = distance;
                }
            }
        }

        return closestNutrient;
    }

	private bool IsInLineOfSight(Transform target)
	{
		Vector3 direction = (target.position - wall.transform.position).normalized;
        if (!Physics.Linecast (wall.transform.position + direction * .7f, target.position)) 
		{
			Debug.DrawLine(wall.transform.position + direction * .5f, target.position, Color.red, 5.0f);
			return true;
		}
		return false;
	}
	
	public void UpgradeSpeed()
	{
		switch (m_ActiveModelName)
		{
		case "Base":
			if (m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_1_COST >= 0)  // if you have enough nutrients to upgrade
			{
				SetActiveModel("Speed1");
				m_Cooldown = Level1Cooldown;
				AdjustAnimationSpeed(m_Cooldown);
				m_GameManager.nutrients = m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_1_COST;	// upgrade costs  nutrients (for test)
				// set message and display time
				message = "Upgraded tower to Speed Level 1";
				timePassed = timer;
			} else // if not enough nutrients let user know
			{
				// set message and display time
				message = "Not enough nutrients to upgrade tower";
				timePassed = timer;
			}
			break;
		case "Speed1":
			if (m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_2_COST >= 0)  // if you have enough nutrients to upgrade
			{
				SetActiveModel("Speed2");
				m_Cooldown = Level2Cooldown;
				AdjustAnimationSpeed(m_Cooldown);
				m_GameManager.nutrients = m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_2_COST;		// upgrade costs  nutrients (for test)
				// set message and display time
				message = "Upgraded tower to Speed Level 2";
				timePassed = timer;
			} else  // if not enough nutrients let user know
			{
				// set message and display time
				message = "Not enough nutrients to upgrade tower";
				timePassed = timer;
			}
			break;
		default:
			break;
		}
	}
	
	private void AdjustAnimationSpeed(float newCooldown)
	{
        foreach (AnimationState state in transform.FindChild(m_ActiveModelName).animation)
        {
            state.speed = BaseCooldown / newCooldown;
        }
	}
	
	public void UpgradePower()
	{
		switch (m_ActiveModelName)
		{
		case "Base":
			if (m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_1_COST >= 0)  // if the upgrade is successful
			{
				SetActiveModel("Power1");
				targets = level1Targets;
				m_GameManager.nutrients = m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_1_COST;		// upgrade costs nutrients (for test
				// set message and display time
				message = "Upgraded tower to Power Level 1";
				timePassed = timer;
			} else // if not enough nutrients to upgrade notify
			{
				// set message and display time
				message = "Not enough nutrients to upgrade tower";
				timePassed = timer;
			}
			break;
		case "Power1":
			if (m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_2_COST >= 0) // if the upgrade is successful
			{
				SetActiveModel("Power2");
				targets = level2Targets;
				m_GameManager.nutrients = m_GameManager.nutrients - TOWER_UPGRADE_LEVEL_2_COST;		// upgrade costs  nutrients (for test
				// set message and display time
				message = "Upgraded tower to Power level 2";
				timePassed = timer;
			} else // if not enough nutrients to upgrade notify
			{
				// set message and display time
				message = "Not enough nutrients to upgrade tower";
				timePassed = timer;
			}
			break;
		default:
			break;
		}
	}
}
