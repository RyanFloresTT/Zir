using KBCore.Refs;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementInput : IMovementProvider, PlayerInputActions.IPlayerActions {
    PlayerInputActions inputActions;
    Vector2 movementInput;

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
    
    public Vector2 GetMovementDirection() => movementInput;
}