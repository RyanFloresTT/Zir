using System.Collections.Generic;
using KBCore.Refs;
using UnityEngine;

public class Entity : MonoBehaviour {
    [SerializeReference] protected IInputProvider inputProvider;
    [SerializeField, Range(0f, 10f)] float speed = 5f;
    [SerializeField, Self] Rigidbody2D rb;
    protected List<IDecorator> decorators = new();
    public Stats EntityStats { get; set; }
    public Resource EntityResource { get; set; }
    
    protected virtual void Awake() {
        EntityStats = new();
        EntityResource = new();
        inputProvider.Initialize();
        
        
        // Decorator testing
        var healthStatIncrease = new HealthStatDecorator(this, 0.1f);
        Debug.Log($"Current Max health of {GetType().Name} is {EntityStats.MaxHealth}.");
        Debug.Log("Applying 10% health increase decorator.");
        healthStatIncrease.ApplyDecorator();
        Debug.Log($"Current Max health of {GetType().Name} is {EntityStats.MaxHealth}.");
        Debug.Log("Applying 10% health increase decorator.");
        healthStatIncrease.ApplyDecorator();
        Debug.Log($"Current Max health of {GetType().Name} is {EntityStats.MaxHealth}.");
        Debug.Log("Applying 10% health increase decorator.");
        healthStatIncrease.ApplyDecorator();
        Debug.Log($"Current Max health of {GetType().Name} is {EntityStats.MaxHealth}.");
    }

    void ApplyDecorators() {
        foreach (var decorator in decorators) {
            decorator.ApplyDecorator();
        }
    }

    protected virtual void OnValidate() {
        this.ValidateRefs();
    }
    protected virtual void OnEnable() {
        inputProvider.OnEnable();
    }
    protected virtual void OnDisable() {
        inputProvider.OnDisable();
    }
    protected virtual void Update() {
        EntityStats.RegenTick();
        EntityResource.RegenTick();
    }
    protected virtual void FixedUpdate() {
        var movementInput = inputProvider.GetMovementDirection();
        rb.velocity = movementInput * speed;
    }
    public bool IsMoving() => rb.velocity.magnitude > 0.1f;
}