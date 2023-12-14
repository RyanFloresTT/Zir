public class HealthStatDecorator : IDecorator {
    Entity entity;
    float percentIncrease;
    public HealthStatDecorator(Entity entity, float percentIncrease) {
        this.entity = entity;
        this.percentIncrease = percentIncrease;
    }
    public void ApplyDecorator() {
        entity.EntityStats.MaxHealth += (int)(entity.EntityStats.MaxHealth * percentIncrease);
    }
}
