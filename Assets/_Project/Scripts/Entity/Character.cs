using KBCore.Refs;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity {
    [Header("Entity")]
    [SerializeReference] protected IInputProvider inputProvider;
    [SerializeField, Self] Rigidbody2D rb;
    protected List<IDecorator> decorators = new();
    public Resource Resource { get; set; }

    protected virtual void OnValidate() {
        this.ValidateRefs();
    }
    protected virtual void OnEnable() {
        inputProvider.OnEnable();
    }
    protected virtual void OnDisable() {
        inputProvider.OnDisable();
    }
    new void Awake() {
        base.Awake();
        inputProvider.Initialize();
    }
    protected virtual void Update() {
        Stats.RegenTick();
        Resource.RegenTick();
    }
    protected virtual void FixedUpdate() {
        var movementInput = inputProvider.GetMovementDirection();
        rb.velocity = movementInput * Stats.MoveSpeed;
    }
    public bool IsMoving() => rb.velocity.magnitude > 0.1f;
}
