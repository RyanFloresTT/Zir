public class FireballSpell : Spell {
    private int manaGenerated;

    public FireballSpell(int manaGenerated) {
        SpellName = "Fireball";
        Description = "Launches a fiery projectile.";
        DamageType = DamageType.Fire;
        this.manaGenerated = manaGenerated;
    }

    public override void Cast(PlayableClass player) {
        if (player is Mage mage) {
            mage.GenerateMana(manaGenerated);
        }
    }
}