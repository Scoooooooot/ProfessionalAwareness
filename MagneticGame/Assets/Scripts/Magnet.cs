using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnet : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] Image magnetStateImage;
    public bool magnetActive = false;
    public bool magnetPulling = false;
    public bool atMagnetBlock = false;

    private void Update() {

        
        if (magnetPulling || atMagnetBlock) { // If being pulled by magnet or you are at the magnet block while magnet is active, gravity is disabled
            playerObject.GetComponent<Rigidbody>().useGravity = false;
        } 
        if (!magnetPulling && !atMagnetBlock) { // If magnet is not pulling and you are not at the magnet block, gravity is enabled
            playerObject.GetComponent<Rigidbody>().useGravity = true;
        }

        if (magnetActive) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity)) {
                if (hit.transform.gameObject.CompareTag("MagnetBlock")) { // Cast a ray to see if a magnet block is within range
                    float speed = 10 / hit.distance; // Changes speed based on distance
                    if (magnetPulling) {
                        playerObject.transform.position = Vector3.Lerp(playerObject.transform.position, hit.transform.position, speed * Time.deltaTime); // Move towards the magnet block
                    }
                    if (Mathf.Abs(hit.transform.position.x - transform.position.x) < 0.6) { // Stops just before magnet block to avoid glitching through
                        playerObject.transform.position = new Vector3(playerObject.transform.position.x, hit.transform.position.y, 0f); // Fix position
                        magnetPulling = false;
                        atMagnetBlock = true;
                    }
                    else {
                        magnetPulling = true;
                    }                   
                }
                else {
                    magnetPulling = false;
                }
                if (hit.transform.gameObject.CompareTag("Coin")) {
                    float speed = 5 / hit.distance;
                    hit.transform.position = Vector3.Lerp(hit.transform.position, transform.position, speed * Time.deltaTime);
                }

            } 
            else {
                magnetPulling = false;
            }
        }
        else {
            magnetPulling = false;
            atMagnetBlock = false;
        }
    }

    public void AlternateMagnetState() {
        if (magnetActive) { // Change to inactive
            magnetStateImage.color = Color.red;
        }
        if (!magnetActive) { // Change to active
            magnetStateImage.color = Color.green;
        }
        magnetActive = !magnetActive;
    }
}
