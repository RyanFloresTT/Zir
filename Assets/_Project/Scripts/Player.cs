using UnityEngine;

public class Player : Entity {
    protected PlayableClass playableClass;
    void Start() {
        playableClass = new Mage(this, inputProvider);
    }
    protected override void Update() {
        playableClass.Tick();
        base.Update();
    }

    protected override void FixedUpdate() {
        playableClass.FixedTick();
        base.FixedUpdate();
    }
}
