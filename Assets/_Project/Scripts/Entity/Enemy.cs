using System;
using UnityEngine;

public class Enemy : Character {
    [SerializeField] ResourceData resourceData;
    PlayableClass playableClass;
    
    void Start() {
        playableClass = new Mage(this, inputProvider, resourceData);
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
