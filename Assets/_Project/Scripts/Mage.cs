public class Mage : PlayableClass {
    public Mage(Entity entity) : base(entity) {
        InitializeStats(entity);
        InitializeResource(entity);
    }

    void InitializeStats(Entity entity) {
        entity.EntityStats = new();
    }

    void InitializeResource(Entity entity) {
        entity.EntityResource = new();
    }
}
