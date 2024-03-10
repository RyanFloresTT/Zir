using System;
using UnityEngine;

public class Player : Character {
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
