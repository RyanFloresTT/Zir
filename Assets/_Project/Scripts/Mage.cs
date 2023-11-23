public class Mage : PlayableClass
{
    private MultiplierManager multiplierManager = new MultiplierManager();

    // Assume abilities is a collection of abilities associated with the Mage
    private List<Spell> abilities;

    public Mage()
    {
        // ... (other initialization)
        InitializeAbilityModifiers();
    }

    private void InitializeAbilityModifiers()
    {
        foreach (var ability in abilities)
        {
            multiplierManager.AddAbilityModifier(ability.SpellName, 1.0f);
        }
    }

    public void ImproveAbility(string abilityName, float damageMultiplier)
    {
        multiplierManager.AddAbilityModifier(abilityName, damageMultiplier);
        // Handle any additional logic related to improving ability damage multiplier
    }

    public float GetTotalMultiplier(DamageType damageType, string abilityName)
    {
        return multiplierManager.GetTotalMultiplier(damageType, abilityName);
    }

    // Override base class method to include mage-specific damage types
    public override float GetDamageMultiplier(DamageType damageType)
    {
        float baseMultiplier = base.GetDamageMultiplier(damageType);
        float mageMultiplier = GetMageDamageMultiplier((MageDamageType)damageType);
        return baseMultiplier * mageMultiplier;
    }

    private float GetMageDamageMultiplier(MageDamageType mageDamageType)
    {
        // Implement logic to retrieve mage-specific damage multipliers
        // For simplicity, returning 1.0f as a placeholder
        return 1.0f;
    }

    // ... (other methods)
}
