using System;

public class Player : Entity {
    void Start() {
        playableClass = new Mage(this);
    }
}
