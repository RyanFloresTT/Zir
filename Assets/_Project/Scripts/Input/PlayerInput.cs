using System;
using KBCore.Refs;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : IInputProvider, PlayerInputActions.IPlayerActions {
    PlayerInputActions inputActions;
    Vector2 movementInput;
    Camera mainCamera;
    Vector2 aimInput;
    public Action HandleAutoAttack { get; set; }

    public void Initialize() {
        inputActions = new PlayerInputActions();
        inputActions.Player.SetCallbacks(this);
        mainCamera = Camera.main;
    }

    public void OnEnable() {
        inputActions.Enable();
    }

    public void OnDisable() {
        inputActions.Disable();
    }

    public void OnMove(InputAction.CallbackContext context) {
        movementInput = context.ReadValue<Vector2>().normalized;
    }

    public void OnAutoAttack(InputAction.CallbackContext context) {
        if (context.performed) {
            HandleAutoAttack.Invoke();
        }
    }

    public void OnAim(InputAction.CallbackContext context) {
        aimInput = context.ReadValue<Vector2>();
    }

    Vector3 GetMousePosition() {
        var mousePosition = new Vector3(aimInput.x, aimInput.y, mainCamera.nearClipPlane);
        var worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        return worldPosition;
    }


    public Vector2 GetMovementDirection() => movementInput;
    public Vector3 GetAttackDirection() => GetMousePosition();
}