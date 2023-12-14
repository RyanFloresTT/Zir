using UnityEngine;

public class MageAutoAttack : IAutoAttack {
    float attackCooldown = 2f;
    float lastAttackTime = 0f;

    public void PerformAutoAttack(Vector3 direction) {
        // Fire a projectile in the direction of the mouse cursor, with a cooldown of 2 seconds
        if (Time.time - lastAttackTime > attackCooldown) {
            lastAttackTime = Time.time;
            Debug.Log($"Firing mage auto attack at {direction}");
        }
    }
}