using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTargetProvider : ITargetProvider
{
    Transform target;
    
    public Vector3 GetTarget() {
        if (target != null) return target.position;
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            target = player.transform;
        }
        return Vector3.zero;
    }
}