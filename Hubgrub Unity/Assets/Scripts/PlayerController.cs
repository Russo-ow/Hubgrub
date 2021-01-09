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

    void FixedUpdate() {


        //Length of the ray
        float laserLength = 50f;

        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, laserLength);
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        //If the collider of the object hit is not NULL
        if (hit.collider != null) {
            //Hit something, print the tag of the object
            Debug.Log("Hitting: " + hit.collider.tag);
        }

        //Method to draw the ray in scene for debug purpose
        Debug.DrawRay(transform.position, Vector2.right * laserLength, Color.red);
    }
}
