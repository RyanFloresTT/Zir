using UnityEngine;

public class Player : Entity {
    protected PlayableClass playableClass;
    void Start() {
        playableClass = new Mage(this);
    }

    void Update() {
        playableClass.Tick();
    }

    void FixedUpdate() {
        playableClass.FixedTick();
    }
}
