using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public LevelController levelController;

    [System.Serializable]
    public class AbilitySlot
    {
        public Ability ability;
        public int level = 1;
        public bool isActive = true;
    }


    [Header("Debug")]
    [SerializeField] private List<AbilitySlot> activeAbilities = new List<AbilitySlot>();

    // События для уведомлений
    public System.Action<Ability, int> OnAbilityAdded;
    public System.Action<Ability> OnAbilityRemoved;
    public System.Action<Ability, int> OnAbilityLevelUp;

    public bool AddAbility(Ability ability, int level = 1)
    {
        if (ability == null) return false;

        // Проверяем, есть ли уже такая способность
        var existingSlot = activeAbilities.Find(slot => slot.ability == ability);
        if (existingSlot != null)
        {
            LevelUpAbility(ability);
            return true;
        }

        // Создаем новый слот
        var newSlot = new AbilitySlot
        {
            ability = ability,
            level = Mathf.Clamp(level, 1, ability.maxLevel),
            isActive = true
        };

        activeAbilities.Add(newSlot);

        // Вызываем инициализацию способности
        ability.OnAbilityAdded(this, newSlot.level);

        OnAbilityAdded?.Invoke(ability, newSlot.level);
         
        

        Debug.Log($"Ability added: {ability.AbilityName} Level {newSlot.level}");
        return true;
    }

    public bool LevelUpAbility(Ability ability)
    {
        var slot = activeAbilities.Find(s => s.ability == ability);
        if (slot == null) return false;
        if (slot.level >= ability.maxLevel) return false;

        slot.level++;
        //ability.OnAbilityLevelUp(this, slot.level);

        OnAbilityLevelUp?.Invoke(ability, slot.level);

        Debug.Log($"Ability leveled up: {ability.AbilityName} Level {slot.level}");
        return true;
    }

    private void UpdateAbilities()
    {
        foreach (var slot in activeAbilities)
        {
            if (slot.isActive && slot.ability.isActive)
            {
                slot.ability.OnAbilityUpdate(this, slot.level);
            }
        }
    }


    // Проверить наличие способности
    public bool HasAbility(Ability ability)
    {
        return activeAbilities.Exists(slot => slot.ability == ability);
    }

    // Получить уровень способности
    public int GetAbilityLevel(Ability ability)
    {
        var slot = activeAbilities.Find(s => s.ability == ability);
        return slot?.level ?? 0;
    }

    // Получить все активные способности
    public List<AbilitySlot> GetActiveAbilities()
    {
        return new List<AbilitySlot>(activeAbilities);
    }

    // Очистить все способности
    public void ClearAllAbilities()
    {
        foreach (var slot in activeAbilities)
        {
            slot.ability.OnAbilityRemoved(this);
        }
        activeAbilities.Clear();
    }

    private void OnDestroy()
    {
        ClearAllAbilities();
    }
}
