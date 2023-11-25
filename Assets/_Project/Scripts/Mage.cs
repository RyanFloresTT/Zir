using System.Collections.Generic;

public class Mage : PlayableClass {
    MultiplierManager multiplierManager = new MultiplierManager();
    List<Spell> abilities = new();

    public Mage(Entity entity) : base(entity) {
        InitializeStats(entity);
        InitializeResource(entity);
    }

    void InitializeStats(Entity entity) {
        entity.EntityStats = new();
    }

    void InitializeResource(Entity entity) {
        entity.EntityResource = new();
    }

    public void ImproveAbility(string abilityName, float damageMultiplier) {
        multiplierManager.AddAbilityMultiplier(abilityName, damageMultiplier);
    }

    public float GetTotalMultiplier(DamageType damageType, string abilityName) {
        return multiplierManager.GetTotalMultiplier(damageType, abilityName);
    }
}
