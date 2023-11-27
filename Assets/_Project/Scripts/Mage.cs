public class Mage : PlayableClass {
    public Mage(Entity entity, IInputProvider inputProvider) : base(entity, inputProvider) {
        InitializeStats(entity);
        InitializeResource(entity);
        autoAttack = new MageAutoAttack();
    }

    void InitializeStats(Entity entity) {
        entity.EntityStats = new();
    }

    void InitializeResource(Entity entity) {
        entity.EntityResource = new();
    }
}
