using System.Collections.Generic;

public class EffectManager {
    List<IEffect> effects;
    Entity entity;

    public EffectManager(Entity entity) {
        effects = new();
        this.entity = entity;
    }

    public void AddEffect(IEffect effect) {
        effects.Add(effect);
    }
    
    public void TickEffects() {
        foreach (var effect in effects) {
            effect.TickEffect();
        }
    }
}
