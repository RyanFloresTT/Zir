using System.Collections.Generic;

public class EffectManager {
    private List<IEffect> effects = new List<IEffect>();

    public void AddEffect(IEffect effect) {
        effects.Add(effect);
    }

    public void ApplyEffects() {
        foreach (var effect in effects) {
            effect.Apply();
        }
    }
}