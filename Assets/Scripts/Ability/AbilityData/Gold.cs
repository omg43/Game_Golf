using Golf;
using UnityEngine;

[CreateAssetMenu(fileName = "GoldAbility", menuName = "Ability/Passive/Gold Effect")]
public class Gold : Ability
{
    [SerializeField] private float m_cuttentSpawnRateDown = 0.5f;
    [SerializeField] private float m_additionalSpawnRate = 0.2f;
    public override void OnAbilityAdded(AbilityHolder abilityHolder, int level)
    {
        abilityHolder.levelController.m_spanwRate += m_cuttentSpawnRateDown;
    }

    public override void OnAbilityRemoved(AbilityHolder abilityHolder)
    {
        abilityHolder.levelController.m_spanwRate -= m_cuttentSpawnRateDown;
    }

    public override void OnAbilityUpdate(AbilityHolder abilityHolder, int level)
    {
        m_cuttentSpawnRateDown += m_additionalSpawnRate;
    }
}
