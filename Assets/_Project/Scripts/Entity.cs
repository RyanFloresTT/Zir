using KBCore.Refs;
using UnityEngine;

public class Entity : MonoBehaviour {
    [SerializeReference] protected IInputProvider inputProvider;
    [SerializeField, Range(0f, 10f)] float speed = 5f;
    [SerializeField, Self] Rigidbody2D rb;
    public Stats EntityStats { get; set; }
    public Resource EntityResource { get; set; }
    
    protected virtual void Awake() {
        EntityStats = new();
        EntityResource = new();
        inputProvider.Initialize();
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