using KBCore.Refs;
using Sirenix.OdinInspector;
using UnityEngine;
public class Movement : MonoBehaviour {
    [SerializeReference] IMovementProvider movementProvider;
    [SerializeField, Range(0f, 10f)] float speed = 5f;
    [SerializeField, Self] Rigidbody2D rb;

    void OnValidate() {
        this.ValidateRefs();
    }
    void Awake() {
        movementProvider.Initialize();
    }
    void OnEnable() {
        movementProvider.OnEnable();
    }
    void OnDisable() {
        movementProvider.OnDisable();
    }
    void FixedUpdate() {
        var movementInput = movementProvider.GetMovementDirection();
        rb.velocity = movementInput * speed;
    }
}