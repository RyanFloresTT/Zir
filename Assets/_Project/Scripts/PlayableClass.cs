using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayableClass {
    protected MultiplierManager multiplierManager;
    protected EffectManager effectManager;
    protected ConditionManager conditionManager;
    protected List<Talent> talents;
    protected List<Spell> abilities;
    protected int talentPoints;
    protected int talentPointsGainedOnLevelUp = 1;
    protected LevelManager levelManager;
    public int ExperiencePoints { get; protected set; }
    public bool IsCasting { get; set; }

    public PlayableClass(Entity entity) {
        talentPoints = 0;
        effectManager = new EffectManager(entity);
        conditionManager = new ConditionManager();
        multiplierManager = new MultiplierManager();
        talents = new();
        abilities = new();
        levelManager = new();
        
        levelManager.OnLevelUp += HandleLevelUp;
        InitializeAbilityModifiers();
    }
    
    void InitializeAbilityModifiers() {
        foreach (var ability in abilities) {
            multiplierManager.AddAbilityMultiplier(ability.SpellName, 1.0f);
        }
    }
    void HandleLevelUp(int level) {
        Debug.Log($"{GetType().Name} leveled up to level {level}");
    }
    public void GainExperience(int amount) {
        levelManager.GainExperience(amount);
    }

    public virtual void LearnTalent(Talent talent) {
        if (talentPoints < talent.TalentPointCost) return;
        talents.Add(talent);
        talent.Learn();
        talentPoints -= talent.TalentPointCost;
    }

    public virtual void ImproveAbility(string abilityName, float damageMultiplier) {
        multiplierManager.AddAbilityMultiplier(abilityName, damageMultiplier);
    }

    public void Tick() {
         
    }

    public void FixedTick() {
        
    }
}