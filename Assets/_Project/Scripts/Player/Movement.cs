using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour, PlayerInputActions.IPlayerActions {
    [SerializeField, Range(0f, 10f)] float speed = 5f;
    
    PlayerInputActions inputActions;
    Vector2 movementInput;
    Rigidbody2D rb;

    void Awake() {
        inputActions = new PlayerInputActions();
        inputActions.Player.SetCallbacks(this);
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable() {
        inputActions.Enable();
    }

    void OnDisable() {
        inputActions.Disable();
    }

    void FixedUpdate() {
        rb.velocity = movementInput * speed;
    }

    public void OnMove(InputAction.CallbackContext context) {
        movementInput = context.ReadValue<Vector2>().normalized;
    }
}