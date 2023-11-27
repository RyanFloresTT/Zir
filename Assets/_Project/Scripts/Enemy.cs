using System;
using UnityEngine;

public class Enemy : Entity {
    [SerializeReference] IInputProvider inputProvider;
    PlayableClass playableClass;
    
    void Awake() {
        playableClass = new Mage(this, inputProvider);
    }

    protected override void Update() {
        base.Update();
    }
}
