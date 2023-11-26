using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Entity : MonoBehaviour {
    public Stats EntityStats { get; set; }
    public Resource EntityResource { get; set; }
    
    void Awake() {
        EntityStats = new();
        EntityResource = new();
    }
    void Update() {
        EntityStats.RegenTick();
        EntityResource.RegenTick();
    }
    public bool IsMoving() {
        return GetComponent<Rigidbody2D>().velocity.magnitude > 0.1f;
    }
}