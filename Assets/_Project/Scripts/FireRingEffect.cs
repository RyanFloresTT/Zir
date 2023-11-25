using UnityEngine;
using Utilities;

public class FireRingEffect : IEffect {
    Entity entity;
    ConditionManager conditionManager;
    CountdownTimer pulsingTimer;
    float interval = 1f;

    public FireRingEffect(Entity entity) {
        this.entity = entity;
        conditionManager = new();
        conditionManager.AddCondition(new MovingCondition(this.entity));
        pulsingTimer = new CountdownTimer(interval);
    }

    public void Apply(Transform targetTransform) {
        if (conditionManager.AreAllConditionsMet()) {
            Debug.Log("All Conditions Met");
            if (!pulsingTimer.IsRunning) {
                Debug.Log("Timer not running, starting it now...");
                pulsingTimer.Start();
                pulsingTimer.OnTimerStart += () => {
                    SpawnFireRing(entity.transform);
                };
                pulsingTimer.OnTimerStop += () => {
                    Debug.Log("Timer stopped, resetting it now...");
                    pulsingTimer.Reset();
                    Apply(targetTransform);
                };
                
            }
        }
    }

    public void TickEffect() {
        pulsingTimer.Tick(Time.deltaTime);
    }

    void SpawnFireRing(Transform transform) {
        Debug.Log($"Fire ring spawned @ {transform.position}!");
    }
    
}