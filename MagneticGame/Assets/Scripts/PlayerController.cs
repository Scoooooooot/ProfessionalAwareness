using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 move;

    public void OnMove(InputAction.CallbackContext context) {
        move = context.ReadValue<Vector2>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer() {
        Vector3 movement = new Vector3(-move.x, 0f, 0f);


        if (movement.magnitude > 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
