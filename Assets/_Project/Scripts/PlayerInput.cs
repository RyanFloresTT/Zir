using KBCore.Refs;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : IMovementProvider, PlayerInputActions.IPlayerActions {
    PlayerInputActions inputActions;
    Vector2 movementInput;
    IAutoAttack autoAttack;

    public void Initialize() {
        inputActions = new PlayerInputActions();
        inputActions.Player.SetCallbacks(this);
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
            DoAutoAttack();
        }
    }

    public Vector2 GetMovementDirection() => movementInput;

    public void SetAutoAttack(IAutoAttack autoAttack) {
        this.autoAttack = autoAttack;
    }

    public void DoAutoAttack() {
        autoAttack?.PerformAutoAttack();
    }
}