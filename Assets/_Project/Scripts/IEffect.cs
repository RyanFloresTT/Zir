using UnityEngine;
public interface IEffect {
    void Apply(Transform transform);
    bool ConditionsMet(Transform transform);
}