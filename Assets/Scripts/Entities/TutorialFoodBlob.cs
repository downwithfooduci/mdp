using UnityEngine;
using System.Collections;

public class TutorialFoodBlob : FoodBlob {

    private SmallIntestineTutorialManager m_TutorialManager;
    private IntestineGameManager m_GameManager;

	protected override void GenerateEnzymes()
    {
        NutrientManager manager = FindObjectOfType(typeof(NutrientManager)) as NutrientManager;
        m_GameManager = FindObjectOfType(typeof(IntestineGameManager)) as IntestineGameManager;
        m_TutorialManager = FindObjectOfType(typeof(SmallIntestineTutorialManager)) as SmallIntestineTutorialManager;

        // Place enzyme generation code here
        Vector3 position = transform.position;

        Nutrient nutrient = manager.InstantiateNutrient(m_TutorialManager.CurrentColor, position);
        nutrient.Manager = m_GameManager;

        // Attach new enzyme as a child object
        nutrient.transform.parent = gameObject.transform;

        gameObject.AddComponent(typeof(FollowITweenPath));
    }

    public override void TakeHit()
    {
        m_TutorialManager.AdvanceLevel();
    }
}
