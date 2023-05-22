using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Magnet magnetScript;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private float jumpVelocity = 1f;
    [SerializeField] End endScript;
    private Vector2 move;
    private int playerCoins = 0;
    private bool isGrounded = true;
    private Rigidbody rb;

    public void OnMove(InputAction.CallbackContext context) {
        move = context.ReadValue<Vector2>(); // Take values from WASD (only using AD for movement)
    }
    public void ChangeMagnetState(InputAction.CallbackContext context) { 
        if (!context.started) { // Take value of button being pressed but only checks once to avoid being held
            return;
        }
        magnetScript.AlternateMagnetState();
    }

    public void Jump(InputAction.CallbackContext context) {
        if (!context.started) {
            return;
        }
        if (!isGrounded) {
            return;
        }
        rb.AddForce(Vector3.up * jumpVelocity, ForceMode.VelocityChange);
    }

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!magnetScript.magnetPulling && !magnetScript.atMagnetBlock) { // Stops player being able to move during magnet pull
            MovePlayer();
        }
    }

    public void MovePlayer() {
        Vector3 movement = new Vector3(-move.x, 0f, 0f);


        if (movement.magnitude > 0) { // Rotate player pretty much instantly
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 10000000f);         
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.World); // Move player
    }

    public void AddCoin(int amount) {
        playerCoins += amount;
        coinsText.text = playerCoins.ToString() + "/" + endScript.GetCoinsNeeded();
    }
    public int GetCoins() {
        return playerCoins;
    }

    public void ChangeIsGrounded(bool state) {
        isGrounded = state;
    }
}

