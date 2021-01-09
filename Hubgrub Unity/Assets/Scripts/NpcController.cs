using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour {
    public Direction direction = Direction.Up;

    Rigidbody2D rb;
    float speed;

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
        rb.velocity = Dir2Vector(direction);
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
