using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour {
    public Direction direction = Direction.Up;
    public Color color;
    public Object[] destroyOnDeath;
    public Animator anim;

    Rigidbody2D rb;
    SpriteRenderer sp;
    float speed = 1;

    public enum Direction {
        Up,
        Down,
        Left,
        Right
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        sp.color = color;
        speed = PlayerController.instance.speed;
        UpdateAnim(direction);
    }

    void FixedUpdate() {
        rb.velocity = Dir2Vector(direction) * speed;
        if(IsMaze(direction)) {
            Redirect();
        }
    }

    void Redirect() {
        List<Direction> options = new List<Direction>();
        //Up
        if(direction != Direction.Up) {
            if(!IsMaze(Direction.Up)) {
                options.Add(Direction.Up);
            }
        }
        //Down
        if(direction != Direction.Down) {
            if(!IsMaze(Direction.Down)) {
                options.Add(Direction.Down);
            }
        }
        //Left
        if(direction != Direction.Left) {
            if(!IsMaze(Direction.Left)) {
                options.Add(Direction.Left);
            }
        }
        //Right
        if(direction != Direction.Right) {
            if(!IsMaze(Direction.Right)) {
                options.Add(Direction.Right);
            }
        }
        if(options.Count > 1)
            options.Remove(OppositeDir(direction));
        direction = options[Random.Range(0, options.Count)];
        UpdateAnim(direction);
    }

    bool IsMaze(Direction d) {
        foreach(RaycastHit2D hit in Physics2D.RaycastAll(
            new Vector2(transform.position.x, transform.position.y) + (Dir2Vector(d) * .45001f),
            Dir2Vector(d),
            .1f
            )) {
            if(hit.collider.CompareTag("Maze"))
                return true;
        }
        return false;
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

    Direction OppositeDir(Direction d) {
        switch(d) {
            case Direction.Up:
                return Direction.Down;
            case Direction.Down:
                return Direction.Up;
            case Direction.Left:
                return Direction.Right;
            case Direction.Right:
                return Direction.Left;
            default:
                return Direction.Up;
        }
    }

    public void Kill() {
        anim.SetBool("Dead", true);
        foreach(Object o in destroyOnDeath) {
            Destroy(o);
        }
        sp.sortingOrder = -1;
        Destroy(this);
    }

    void UpdateAnim(Direction d) {
        anim.SetBool("Up", false);
        anim.SetBool("Down", false);
        anim.SetBool("Left", false);
        anim.SetBool("Right", false);
        switch(d) {
            case Direction.Up:
                anim.SetBool("Up", true);
                break;
            case Direction.Down:
                anim.SetBool("Down", true);
                break;
            case Direction.Left:
                anim.SetBool("Left", true);
                break;
            case Direction.Right:
                anim.SetBool("Right", true);
                break;
        }
    }
}
