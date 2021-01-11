using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {
    public GameObject target;
    Vector3 offset;
    Vector3 standard;

    // How long the object should shake for.
    private float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    private float shakeAmount = 0;
    public float decreaseFactor = 1.0f;
    public float maxShake = 0.7f;
    public float maxShakeDuration = 1.0f;

    private void Start() {
        standard = target.transform.position - transform.position;
    }

    private void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset - standard, .6f);
    }

    void Update() {
        offset = Random.insideUnitSphere * shakeAmount;

        if (shakeDuration > 0) {
            shakeDuration -= Time.deltaTime * decreaseFactor;
            shakeAmount = Mathf.Lerp(0, maxShake, shakeDuration / maxShakeDuration);
        }
    }

    public void StartBoogie() {
        shakeDuration = maxShakeDuration;
        shakeAmount = maxShake;
    }
}
