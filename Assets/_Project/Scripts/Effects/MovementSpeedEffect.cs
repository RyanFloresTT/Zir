using UnityEngine;

public class MovementSpeedEffect : IEffect {
    ConditionManager conditionManager;
    Entity entity;
    bool isEffectApplied;

    public MovementSpeedEffect(Entity entity) {
        conditionManager = new ConditionManager();
        this.entity = entity;
        conditionManager.AddCondition(new HealthCondition(this.entity, .5f, true));
        isEffectApplied = false;
    }

    public void Apply(Transform transform) {
        if (isEffectApplied) return;
        entity.EntityStats.MoveSpeed *= 2;
        isEffectApplied = true;
    }

    public void TickEffect() {
        if (conditionManager.AreAllConditionsMet()) {
            Apply(entity.transform);
        }
    }
}