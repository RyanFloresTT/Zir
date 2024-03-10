using System.Collections.Generic;
using KBCore.Refs;
using UnityEngine;

public class Entity : MonoBehaviour {
    public Stats Stats { get; set; }
    protected virtual void Awake() {
        Stats = new();
        
        // Decorator testing
        var healthStatIncrease = new HealthStatDecorator(this, 0.1f);
        Debug.Log($"Current Max health of {GetType().Name} is {Stats.MaxHealth}.");
        Debug.Log("Applying 10% health increase decorator.");
        healthStatIncrease.ApplyDecorator();
        Debug.Log($"Current Max health of {GetType().Name} is {Stats.MaxHealth}.");
        Debug.Log("Applying 10% health increase decorator.");
        healthStatIncrease.ApplyDecorator();
        Debug.Log($"Current Max health of {GetType().Name} is {Stats.MaxHealth}.");
        Debug.Log("Applying 10% health increase decorator.");
        healthStatIncrease.ApplyDecorator();
        Debug.Log($"Current Max health of {GetType().Name} is {Stats.MaxHealth}.");
    }
}