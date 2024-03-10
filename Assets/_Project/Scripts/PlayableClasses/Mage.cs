public class Mage : PlayableClass {
    public Mage(Character entity, IInputProvider inputProvider, ResourceData resourceData) : base(entity, inputProvider, resourceData) {
        entity.Resource = new(resourceData);
        autoAttack = new MageAutoAttack();
    }
}
