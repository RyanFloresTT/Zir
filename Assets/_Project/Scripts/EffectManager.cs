using System.Collections.Generic;

public class EffectManager {
    List<IEffect> effects = new List<IEffect>();
    Entity entity;

    public EffectManager(Entity entity) {
        this.entity = entity;
    }

    public void AddEffect(IEffect effect) {
        effects.Add(effect);
    }

    public void ApplyEffects() {
        foreach (var effect in effects) {
            effect.Apply(entity.transform);
        }
    }
}