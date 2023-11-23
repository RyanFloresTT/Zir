using System.Collections.Generic;

public class PlayableClass {
    protected MultiplierManager multiplierManager = new MultiplierManager();
    protected EffectManager effectManager = new EffectManager();
    protected ConditionManager conditionManager = new ConditionManager();
    protected List<Talent> talents = new List<Talent>();
    protected List<Spell> abilities = new List<Spell>();
    protected int talentPoints;
    protected int talentPointsGainedOnLevelUp = 1; 
    protected int talentPointCost = 1;
    public bool IsCasting { get; set; }

    public PlayableClass() {
        talentPoints = 0;
        conditionManager.AddCondition(new CastingCondition(this));
    }

    public virtual void LevelUp() {
        talentPoints += talentPointsGainedOnLevelUp;
    }

    public virtual void LearnTalent(Talent talent) {
        if (talentPoints >= talentPointCost) {
            talents.Add(talent);
            talent.Learn();
            talentPoints -= talentPointCost;
        }
    }

    public virtual void ImproveAbility(string abilityName, float damageMultiplier) {
        multiplierManager.AddAbilityMultiplier(abilityName, damageMultiplier);
    }

    public virtual void ApplyEffects() {
        if (conditionManager.AreAllConditionsMet()) {
            effectManager.ApplyEffects();
        }
    }
}