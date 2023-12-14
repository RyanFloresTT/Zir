using UnityEngine;
public interface IEffect {
    void Apply(Transform transform);
    void TickEffect();
}