using UnityEngine;
using Utilities;

public class FireRingEffect : IEffect
{
    bool isActive;
    float interval = 2f;
    CountdownTimer timer;

    public FireRingEffect() {
        timer = new CountdownTimer(interval);
    }

    public void Apply(Transform targetTransform) {
        Debug.Log("Fire ring spawned!");
    }

    public bool ConditionsMet(Transform targetTransform) {
        bool isMoving = targetTransform.GetComponent<Entity>().IsMoving();
        return isMoving && timer.IsFinished;
    }
}