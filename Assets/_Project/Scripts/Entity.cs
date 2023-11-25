using System;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Entity : MonoBehaviour {
    public Stats EntityStats { get; set; }
    public Resource EntityResource { get; set; }
    
    protected PlayableClass playableClass;

    void Awake() {
        EntityStats = new();
        EntityResource = new();
    }

    void Update() {
        playableClass.Tick();
        EntityStats.RegenTick();
        EntityResource.RegenTick();
    }

    void FixedUpdate() {
        playableClass.FixedTick();
    }

    public bool IsMoving() {
        return GetComponent<Rigidbody2D>().velocity.magnitude > 0.1f;
    }
}