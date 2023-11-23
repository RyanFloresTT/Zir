public class CastingCondition : ICondition
{
    private PlayableClass caster;

    public CastingCondition(PlayableClass caster)
    {
        this.caster = caster;
    }

    public bool IsMet()
    {
        // Example: Check if the player is currently casting
        return caster.IsCasting;
    }
}