using System;

public class LevelManager {

    public int CurrentLevel { get; set; }
    public int CumulativeExperience { get; set; }
    public int ExperienceToNextLevel { get; set; }
    public Action<int> OnLevelUp;

    public LevelManager() {
        CurrentLevel = 1;
        CumulativeExperience = 0;
        ExperienceToNextLevel = CalculateExperienceForNextLevel(CurrentLevel);
    }

    public void GainExperience(int amount) {
        CumulativeExperience += amount;

        while (CumulativeExperience >= ExperienceToNextLevel) {
            CumulativeExperience -= ExperienceToNextLevel;
            LevelUp();
            ExperienceToNextLevel = CalculateExperienceForNextLevel(CurrentLevel);
        }
    }

    private void LevelUp() {
        CurrentLevel++;
        OnLevelUp?.Invoke(CurrentLevel);
    }

    private int CalculateExperienceForNextLevel(int level) {
        return (int)Math.Round((double)Fibonacci(level) * 5);
    }

    private int Fibonacci(int n) {
        if (n <= 1) return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}