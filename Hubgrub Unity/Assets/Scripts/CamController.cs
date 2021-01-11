using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {
    public GameObject target;
    Vector3 offset;
    Vector3 standard;

    private void Start() {
        standard = target.transform.position - transform.position;
    }

    private void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset - standard, .6f);
    }
}
