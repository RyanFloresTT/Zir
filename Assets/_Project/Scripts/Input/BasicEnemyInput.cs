using System;
using UnityEngine;

public class BasicEnemyInput : IEemyInputProvider {
    public Action HandleAutoAttack { get; set; }
    public Transform CurrentTransform { get; set; }
    public Transform Target { get; set; }
    int attackRange = 5;
    public void Initialize() {
    }
    public void OnEnable() {
    }
    public void OnDisable() {
    }

    public Vector2 GetMovementDirection(Transform current, Transform target) {
        CurrentTransform = current;
        Target = target;
        return (Target.position - CurrentTransform.position).normalized;
    }

    public Vector3 GetAttackDirection() {
        return (Target.position - CurrentTransform.position).normalized;
    }
    bool ShouldAutoAttackCondition() {
        return Vector2.Distance(CurrentTransform.position, Target.position) < attackRange;
    }
}