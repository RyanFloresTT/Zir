using KBCore.Refs;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour {
    [SerializeReference] IInputProvider inputProvider;
    [SerializeField, Range(0f, 10f)] float speed = 5f;
    [SerializeField, Self] Rigidbody2D rb;

    void OnValidate() {
        this.ValidateRefs();
    }
    void Awake() {
        inputProvider.Initialize();
    }
    void OnEnable() {
        inputProvider.OnEnable();
    }
    void OnDisable() {
        inputProvider.OnDisable();
    }
    void FixedUpdate() {
        var movementInput = inputProvider.GetMovementDirection();
        rb.velocity = movementInput * speed;
    }
}