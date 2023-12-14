public class Talent {
    public string TalentName { get; protected set; }
    protected MultiplierManager multiplierManager;
    protected EffectManager effectManager;
    public int TalentPointCost { get; set; }

    public Talent(MultiplierManager multiplierManager, EffectManager effectManager, int talentPointCost) {
        this.multiplierManager = multiplierManager;
        this.effectManager = effectManager;
        this.TalentPointCost = talentPointCost;
    }

    public virtual void Learn() {
        InitializeModifiers();
        InitializeEffects();
    }

    protected virtual void InitializeModifiers() {
        // Base class provides a default implementation, specific talents can override
    }

    protected virtual void InitializeEffects() {
        // Base class provides a default implementation, specific talents can override
    }
}