using System;
using UnityEngine;

public class Enemy : Entity {
    PlayableClass playableClass;
    
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
