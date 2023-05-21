using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector3 newPosition;
    private Transform trans;
    private bool magnetPulling = true;
    private float speed = 0f;

    private void Awake() {
        trans = transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (magnetPulling) {
            speed = 1 / (Vector3.Distance(trans.position, newPosition));
            Debug.Log(speed);
            trans.position = Vector3.Lerp(trans.position, newPosition, speed * 5 * Time.deltaTime);

            if (Mathf.Abs(newPosition.x - trans.position.x) < 0.05) {
                trans.position = newPosition;
                magnetPulling = false;
            }
        }
    }
}
