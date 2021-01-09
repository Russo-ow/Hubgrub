using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static PlayerController instance;

    Rigidbody2D rb;
    public float speed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake() {
        instance = this;
    }

    void Update() {
        rb.velocity = speed * new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }
}
