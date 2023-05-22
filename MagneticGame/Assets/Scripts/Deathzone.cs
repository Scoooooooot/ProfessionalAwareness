using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{

    [SerializeField] Transform playerSpawn;
    [SerializeField] PlayerController controller;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Body")) {
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.transform.position = playerSpawn.position;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Body")) {
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            controller.TakeLives(1);
        }
    }
}
