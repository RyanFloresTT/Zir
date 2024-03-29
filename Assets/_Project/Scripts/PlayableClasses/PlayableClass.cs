using System.Collections.Generic;
using UnityEngine;

public class PlayableClass {
    protected MultiplierManager multiplierManager;
    protected EffectManager effectManager;
    protected LevelManager levelManager;
    protected IInputProvider inputProvider;
    protected List<Talent> talents;
    protected List<Spell> abilities;
    protected int talentPoints;
    protected int talentPointsGainedOnLevelUp = 1;
    protected IAutoAttack autoAttack;
    protected ResourceData resourceData;
    public int ExperiencePoints { get; protected set; }
    public bool IsCasting { get; set; }

    public PlayableClass(Character character, IInputProvider inputProvider, ResourceData resourceData) {
        talentPoints = 0;
        effectManager = new(character);
        multiplierManager = new();
        levelManager = new();
        talents = new();
        abilities = new();
        this.inputProvider = inputProvider;
        ExperiencePoints = 0;
        levelManager.OnLevelUp += HandleLevelUp;
        this.resourceData = resourceData;

        inputProvider.HandleAutoAttack += () => HandleAutoAttack(inputProvider.GetAttackDirection());
        InitializeAbilityModifiers();
        effectManager.AddEffect(new FireRingEffect(character));
        //effectManager.AddEffect(new MovementSpeedEffect(character));
    }

    void HandleAutoAttack(Vector3 direction) {
        autoAttack?.PerformAutoAttack(direction);
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