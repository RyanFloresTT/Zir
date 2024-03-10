using UnityEngine;
using Utilities;

public class FireRingEffect : IEffect {
    Character character;
    ConditionManager conditionManager;
    CountdownTimer pulsingTimer;
    float interval = 2f;  // Change the interval to 2 seconds

    public FireRingEffect(Character character) {
        this.character = character;
        conditionManager = new ConditionManager();
        conditionManager.AddCondition(new MovingCondition(this.character));
        pulsingTimer = new CountdownTimer(interval);

        pulsingTimer.OnTimerStart += () => {
            Apply(character.transform);
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