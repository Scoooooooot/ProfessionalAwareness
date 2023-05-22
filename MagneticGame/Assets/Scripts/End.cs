using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] private int coinsNeeded = 0;
    [SerializeField] PlayerController controller;
    [SerializeField] string level;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if (controller.GetCoins() >= coinsNeeded) {
                PlayerPrefs.SetInt(level, 1);
                SceneManager.LoadScene("LevelSelect");
            }
        }
    }

    public int GetCoinsNeeded() {
        return coinsNeeded;
    }
}
