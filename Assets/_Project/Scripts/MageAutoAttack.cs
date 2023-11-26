using UnityEngine;

public class MageAutoAttack : IAutoAttack {
    float attackCooldown = 2f;
    float lastAttackTime = 0f;

    public void PerformAutoAttack() {
        Debug.Log("?");
        if (Time.time - lastAttackTime >= attackCooldown) {
            Debug.Log("Mage performs Frost Bolt!");
            lastAttackTime = Time.time;
        }
    }
}