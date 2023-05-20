using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] float moveStep = 10f;
    [SerializeField] private bool magnetActive = false;
    private void FixedUpdate() {
        if (magnetActive) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity)) {
                if (hit.transform.gameObject.CompareTag("MagnetBlock")) {
                    Debug.Log("Hitting a magnet");
                    Vector3 target = new Vector3(hit.transform.position.x, transform.position.y,transform.position.z);
                    playerObject.transform.position = Vector3.MoveTowards(transform.position, target, moveStep*Time.fixedDeltaTime);
                }
            }
        }
    }
}
