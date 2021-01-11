using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    float timer = 0;

    public NpcController.Direction[] validDirections;

    public bool IsValid(float reqDistance) {
        return (PlayerController.instance.transform.position - transform.position).magnitude >= reqDistance && timer<=0;
    }

    public void Use() {
        timer = 2;
    }

    void Update() {
        if(timer > 0)
            timer -= Time.deltaTime;
    }
}