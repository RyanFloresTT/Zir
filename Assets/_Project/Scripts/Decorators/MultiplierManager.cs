using System.Collections.Generic;

public class MultiplierManager {
    Dictionary<string, float> abilityMultipliers = new ();
    Dictionary<DamageType, float> damageTypeMultipliers = new ();

    public void AddAbilityMultiplier(string abilityName, float modifier) {
        abilityMultipliers[abilityName] = modifier;
    }

    public void AddDamageTypeMultiplier(DamageType damageType, float modifier) {
        damageTypeMultipliers[damageType] = modifier;
    }

    public float GetTotalMultiplier(DamageType damageType, string abilityName) {
        float abilityModifier = abilityMultipliers.TryGetValue(abilityName, out var modifier) ? modifier : 1.0f;
        float damageTypeModifier = damageTypeMultipliers.TryGetValue(damageType, out var typeModifier) ? typeModifier : 1.0f;
        return abilityModifier * damageTypeModifier;
    }
}
