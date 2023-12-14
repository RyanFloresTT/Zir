using System;
using UnityEngine;
using UnityEngine.Rendering;
using Utilities;

public class Resource {
    public string Name { get; }
    public int Value { get; set; }
    public int MaxValue { get; set; }
    public int RegenerationRate { get; set; }
    public int RegenerationAmount { get; set; }
    CountdownTimer regenerationTimer;

    public Resource(string name = "Default", int? value = 0, int maxValue = 100, int regenerationRate = 1, int regenerationAmount = 1) {
        Name = name;
        MaxValue = maxValue;
        Value = value ?? MaxValue;
        RegenerationRate = regenerationRate;
        RegenerationAmount = regenerationAmount;
        regenerationTimer = new(RegenerationRate);
        regenerationTimer.Start();
        regenerationTimer.OnTimerStop += RegenerateResource;
        regenerationTimer.OnTimerStop += regenerationTimer.Start;
    }

    public void GainResource(int amount) {
        Value += amount;
        if (Value > MaxValue) Value = MaxValue; 
        Debug.Log($"{GetType().Name} regenerated {amount} resource");
    }

    public void RegenTick() {
        regenerationTimer.Tick(Time.deltaTime);
    }
    
    void RegenerateResource() {
        if (Value >= MaxValue) return;
        GainResource(RegenerationAmount);
    }
}