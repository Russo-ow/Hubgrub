using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;

    private int murders;
    private float comboTimer;
    private int score;
    private int multiplier;

    public float timeLimit;

    void Start() {
        murders = 0;
        comboTimer = 0.0f;
        score = 0;
        multiplier = 1;
    }

    private void Awake() {
        instance = this;
    }

    void Update() {
        if (comboTimer > 0.0f) {
            // combo has been started
            comboTimer -= Time.deltaTime;
        } else {
            // resetting
            multiplier = 1;
        }
    }

    public int DeathCount() {
        return murders;
    }

    public void NPCDeath() {
        if (comboTimer <= 0.0f) {
            // new combo starts
            comboTimer = timeLimit;
            Debug.Log("new combo");
        } else {
            // ongoing combo
            comboTimer = timeLimit;
            multiplier++;
            Debug.Log("ongoing combo");
        }

        score += multiplier * 100;
        murders++;
        Debug.Log("Death Count: " + murders + " Score: " + score);
    }
}
