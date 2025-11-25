using UnityEngine;

public abstract class Ability : ScriptableObject
{
    [SerializeField] private string m_abilityName;
    [SerializeField] private string m_abilityDescription { get; }

    [SerializeField] private AbilityHolder m_abilityHolder;

    [Min(1)] public int maxLevel;
    public bool isActive;
    public string AbilityName => m_abilityName;
    public string AbilityDescription => m_abilityDescription;

    public int level;
    public ActivationType activationType = ActivationType.Immediate;

    public enum ActivationType
    {
        Immediate,
        OnEvent,
        Conditional
    }

    //ну базовое добавление способности
    public virtual void OnAbilityAdded(AbilityHolder abilityHolder ,int level) { }

    //вызывается кажыдй кадр
    public virtual void OnAbilityUpdate(AbilityHolder abilityHolder, int level) { }

    // Вызывается при удалении способности, нужен чтобы убирать улучшения при удалении
    public virtual void OnAbilityRemoved(AbilityHolder abilityHolder) { }
    public virtual void Activate() { }

    public virtual bool CanActivate() { return false; }
}

