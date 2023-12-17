using System;
using UnityEngine;

public class Enemy : Entity {
    PlayableClass playableClass;
    [Header("Enemy")]
    [SerializeReference] ITargetProvider targetProvider;
    
    void Start() {
        playableClass = new Mage(this, inputProvider);
    }
    protected override void Update() {
        playableClass.Tick();
        base.Update();
        targetProvider.GetTarget();
    }

    protected override void FixedUpdate() {
        playableClass.FixedTick();
        base.FixedUpdate();
    }
}
