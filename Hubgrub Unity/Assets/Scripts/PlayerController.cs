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

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("NPC"))
            other.gameObject.GetComponent<NpcController>().Kill();

    }

    /*void FixedUpdate() {
        // current facing direction of player

        //Length of the ray
        float laserLength = 50f;

        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y) + Vector2.right, Vector2.right, laserLength);

        //If the collider of the object hit is not NULL
        if (hit.collider != null) {
            //Hit something, print the tag of the object
            Debug.Log("Hitting: " + hit.collider.tag);
        }

        //Method to draw the ray in scene for debug purpose < doesn't work
        Debug.DrawRay(transform.position, Vector2.right * laserLength, Color.red);
    }*/
}
