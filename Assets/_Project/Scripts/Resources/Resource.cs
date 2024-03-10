using UnityEngine;
using Utilities;

public class Resource {
    public string Name { get; } = "Default";
    public int Current { get; set; } = 0;
    public int Max { get; set; } = 100;
    public int RegenRate { get; set; } = 1;
    public int RegenAmount { get; set; } = 1;
    CountdownTimer regenerationTimer;

    public Resource(ResourceData data) {
        Name = data.name;
        Max = data.Max;
        Current = Max;
        RegenRate = data.RegenRate;
        RegenAmount = data.RegenAmount;
        regenerationTimer = new(RegenRate);
        regenerationTimer.Start();
        regenerationTimer.OnTimerStop += RegenerateResource;
        regenerationTimer.OnTimerStop += regenerationTimer.Start;
    }

    public void GainResource(int amount) {
        Current += amount;
        if (Current > Max) Current = Max; 
        Debug.Log($"{GetType().Name} regenerated {amount} resource");
    }

    public void RegenTick() {
        regenerationTimer.Tick(Time.deltaTime);
    }
    
    void RegenerateResource() {
        if (Current >= Max) return;
        GainResource(RegenAmount);
    }
}