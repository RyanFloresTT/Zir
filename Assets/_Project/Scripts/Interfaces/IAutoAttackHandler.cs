using System;

public interface IAutoAttackHandler {
    void Initialize();
    void OnEnable();
    void OnDisable();
    void SetAutoAttack(IAutoAttack handler);
    void DoAutoAttack();
}