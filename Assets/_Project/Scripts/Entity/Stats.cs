using UnityEngine;
using Utilities;

public class Stats {
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Armor { get; set; }
    public int MoveSpeed { get; set; }
    public int RegenerationRate { get; set; }
    public int RegenerationAmount { get; set; }
    public readonly int DefaultHealth;
    CountdownTimer regenerationTimer;
    public Stats(int health = 70, int maxHealth = 100, int armor = 0, int moveSpeed = 5, int regenerationRate = 2, int regenerationAmount = 3) {
        Health = health;
        MaxHealth = maxHealth;
        DefaultHealth = maxHealth;
        Armor = armor;
        MoveSpeed = moveSpeed;
        RegenerationRate = regenerationRate;
        RegenerationAmount = regenerationAmount;
        regenerationTimer = new(RegenerationRate);
        regenerationTimer.Start();
        regenerationTimer.OnTimerStart += RegenerateHealth;
        regenerationTimer.OnTimerStop += regenerationTimer.Start;
    }

    public void GainHealth(int amount) {
        Health += amount;
        if (Health > MaxHealth) Health = MaxHealth;
        Debug.Log($"{GetType().Name} regenerated {amount} health.");
    }

    public void RegenTick() {
        regenerationTimer.Tick(Time.deltaTime);
    }
    
    void RegenerateHealth() {
        if (Health >= MaxHealth) return;
        GainHealth(RegenerationAmount);
    }
}