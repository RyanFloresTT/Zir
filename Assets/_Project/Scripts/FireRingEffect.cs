using UnityEngine;
using Utilities;

public class FireRingEffect : IEffect {
    Entity entity;
    ConditionManager conditionManager;
    CountdownTimer pulsingTimer;
    float interval = 2f;  // Change the interval to 2 seconds

    public FireRingEffect(Entity entity) {
        this.entity = entity;
        conditionManager = new ConditionManager();
        conditionManager.AddCondition(new MovingCondition(this.entity));
        pulsingTimer = new CountdownTimer(interval);

        pulsingTimer.OnTimerStart += () => {
            Apply(entity.transform);
        };

        pulsingTimer.OnTimerStop += () => {
            pulsingTimer.Reset();
        };
    }

    public void Apply(Transform targetTransform) {
        Debug.Log($"Fire ring spawned @ {targetTransform.position}!");
    }

    public void TickEffect() {
        if (conditionManager.AreAllConditionsMet()) {
            pulsingTimer.Tick(Time.deltaTime);
            if (!pulsingTimer.IsRunning) {
                pulsingTimer.Start();
            }
        }
    }
}