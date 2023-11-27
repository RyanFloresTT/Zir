using System;
using UnityEngine;
public interface IInputProvider {
    public Action HandleAutoAttack { get; set; }
    void Initialize();
    void OnEnable();
    void OnDisable();
    Vector2 GetMovementDirection();
    Vector3 GetAttackDirection();
}