public class HealthCondition : ICondition {
    Entity entity;
    float healthPercentage;
    bool isAbove;
    
    public HealthCondition(Entity entity, float healthPercentage, bool isAbove) {
        this.entity = entity;
        this.healthPercentage = healthPercentage;
        this.isAbove = isAbove;
    }
    public bool IsMet() {
        if (!isAbove) {
            return entity.EntityStats.Health / entity.EntityStats.MaxHealth > healthPercentage;
        }
        return entity.EntityStats.Health / entity.EntityStats.MaxHealth < healthPercentage;
    }
}
