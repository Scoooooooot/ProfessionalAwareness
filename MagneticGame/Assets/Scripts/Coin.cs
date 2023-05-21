using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int coinAmount;
    [SerializeField] PlayerController playerController;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            playerController.AddCoin(coinAmount);
            Destroy(gameObject);
        }
    }
}
