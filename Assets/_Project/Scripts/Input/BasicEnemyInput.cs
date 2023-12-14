using System;
using UnityEngine;

public class BasicEnemyInput : IInputProvider {
    public Action HandleAutoAttack { get; set; }
    public Transform CurrentTransform { get; set; }
    int attackRange = 5;
    
    public void Initialize() {
    }
    public void OnEnable() {
    }

    public void OnDisable() {
    }
    public Vector2 GetMovementDirection() {
        return (PlayerPosition - (Vector2)CurrentTransform.position).normalized;
    }

    public Vector3 GetAttackDirection() {
        return (PlayerPosition - (Vector2)CurrentTransform.position).normalized;
    }
    bool ShouldAutoAttackCondition() {
        return Vector2.Distance(CurrentTransform.position, PlayerPosition) < attackRange;
    }
    Vector2 PlayerPosition => GameObject.FindGameObjectWithTag("Player").transform.position;
}
