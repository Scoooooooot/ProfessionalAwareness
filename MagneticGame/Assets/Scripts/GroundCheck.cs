using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] PlayerController controller;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == controller.gameObject) {
            return;
        }

        controller.ChangeIsGrounded(true);
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject == controller.gameObject) {
            return;
        }

        controller.ChangeIsGrounded(true);
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject == controller.gameObject) {
            return;
        }

        controller.ChangeIsGrounded(false);
    }
}
