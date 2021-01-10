using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour {
    public Direction direction = Direction.Up;

    Rigidbody2D rb;
    float speed = 1;

    public enum Direction {
        Up,
        Down,
        Left,
        Right
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        speed = PlayerController.instance.speed;
    }

    void Update() {
        rb.velocity = Dir2Vector(direction) * speed;
        foreach(RaycastHit2D hit in Physics2D.RaycastAll(
            new Vector2(transform.position.x, transform.position.y) + (Dir2Vector(direction) * .901f),
            Dir2Vector(direction),
            .099f
            )) {
            if(hit.collider.CompareTag("Maze"))
                Redirect();
        }
    }

    void Redirect() {
        int numViable = 0;
        bool[] viable = { false, false, false, false };
        //Up
        if(direction!=Direction.Up) {

        }
        //Down
        if(direction!=Direction.Down) {

        }
        //Left
        if(direction!=Direction.Left) {

        }
        //Right
        if(direction!=Direction.Right) {

        }
    }

    Vector2 Dir2Vector(Direction d) {
        switch(d) {
            case Direction.Up:
                return Vector2.up;
            case Direction.Down:
                return Vector2.down;
            case Direction.Left:
                return Vector2.left;
            case Direction.Right:
                return Vector2.right;
            default:
                return Vector2.zero;
        }
    }
}
