public class CastingCondition : ICondition {
    PlayableClass caster;

    public CastingCondition(PlayableClass caster) {
        this.caster = caster;
    }

    public bool IsMet() {
        return caster.IsCasting;
    }
}