using System;
using UnityEngine;
public interface IEemyInputProvider {
    public Action HandleAutoAttack { get; set; }
    void Initialize();
    void OnEnable();
    void OnDisable();
    Vector2 GetMovementDirection(Transform current, Transform target);
    Vector3 GetAttackDirection();
}