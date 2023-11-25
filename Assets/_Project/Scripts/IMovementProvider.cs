using UnityEngine;
public interface IMovementProvider {
    void Initialize();
    void OnEnable();
    void OnDisable();
    Vector2 GetMovementDirection();
}