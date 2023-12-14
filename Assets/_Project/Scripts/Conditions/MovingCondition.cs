public class MovingCondition : ICondition {
    Entity entity;
    public MovingCondition(Entity entity) => this.entity = entity;
    public bool IsMet() => entity.IsMoving();
}
