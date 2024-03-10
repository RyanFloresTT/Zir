public class MovingCondition : ICondition {
    Character character;
    public MovingCondition(Character character) => this.character = character;
    public bool IsMet() => character.IsMoving();
}
