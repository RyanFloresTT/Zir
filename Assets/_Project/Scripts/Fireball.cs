public class FireballSpell : Spell {
    int manaGenerated;

    public FireballSpell(int manaGenerated) {
        SpellName = "Fireball";
        Description = "Launches a fiery projectile.";
        DamageType = DamageType.Fire;
        this.manaGenerated = manaGenerated;
    }

    public override void Cast(PlayableClass player) {
        // Fireball Cast
    }
}