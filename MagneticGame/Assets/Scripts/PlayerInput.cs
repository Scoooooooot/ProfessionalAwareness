using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }

    Controls _input;

    private void OnEnable() {
        _input = new Controls();
        _input.Player.Enable();

        _input.Player.Movement.performed += SetMove;
        _input.Player.Movement.canceled += SetMove;
    }

    private void OnDisable() {
        _input.Player.Movement.performed -= SetMove;
        _input.Player.Movement.canceled -= SetMove;

        _input.Player.Disable();
    }

    private void SetMove(InputAction.CallbackContext ctx) {
        MoveInput = ctx.ReadValue<Vector2>();
    }
}

