public abstract class Spell
{
    public string SpellName { get; protected set; }
    public string Description { get; protected set; }
    public DamageType DamageType { get; protected set; }

    public abstract void Cast(PlayableClass caster);
}