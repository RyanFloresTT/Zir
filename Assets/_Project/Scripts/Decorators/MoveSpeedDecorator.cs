using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Increases a Character's Move Speed.</summary>

public class MoveSpeedDecorator : IDecorator {

    Character character;
    float percentIncrease;
    public MoveSpeedDecorator(Character character, float percentIncrease) {
        this.character = character;
        this.percentIncrease = percentIncrease;
    }
    public void ApplyDecorator() {
        character.Stats.MoveSpeed *= 1 + percentIncrease;
    }
}
