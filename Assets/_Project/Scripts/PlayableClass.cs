using System.Collections.Generic;
using UnityEngine;

public class PlayableClass {
    protected MultiplierManager multiplierManager;
    protected EffectManager effectManager;
    protected LevelManager levelManager;
    protected List<Talent> talents;
    protected List<Spell> abilities;
    protected int talentPoints;
    protected int talentPointsGainedOnLevelUp = 1;
    public int ExperiencePoints { get; protected set; }
    public bool IsCasting { get; set; }

    public PlayableClass(Entity entity) {
        talentPoints = 0;
        effectManager = new(entity);
        multiplierManager = new();
        levelManager = new();
        talents = new();
        abilities = new();
        ExperiencePoints = 0;
        levelManager.OnLevelUp += HandleLevelUp;
        
        InitializeAbilityModifiers();
        effectManager.AddEffect(new FireRingEffect(entity));
        effectManager.AddEffect(new MovementSpeedEffect(entity));
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
    public void LearnTalent(Talent talent) {
        if (talentPoints < talent.TalentPointCost) return;
        talents.Add(talent);
        talent.Learn();
        talentPoints -= talent.TalentPointCost;
    }
    public void ImproveAbility(string abilityName, float damageMultiplier) {
        multiplierManager.AddAbilityMultiplier(abilityName, damageMultiplier);
    }
    public void Tick() {    
        effectManager.TickEffects();
    }
    public void FixedTick() {
    }
}