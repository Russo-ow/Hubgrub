using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;

    public TMPro.TextMeshProUGUI scoreObject;
    public TMPro.TextMeshProUGUI multiplierObject;

    public Slider comboSlider;

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
        scoreObject.text = "Score: " + score;
        multiplierObject.text = "x" + multiplier;

        if(comboTimer > 0.0f) {
            // combo has been started
            comboTimer -= Time.deltaTime;
        } else {
            // resetting
            multiplier = 1;
            multiplierObject.text = "";
        }
        comboSlider.value = comboTimer;
    }

    public int DeathCount() {
        return murders;
    }

    public void NPCDeath() {
        comboTimer = timeLimit;
        murders++;
        score += multiplier * 100;
        multiplier++;
        multiplierObject.text = "x" + multiplier;
        //Debug.Log("ongoing combo");

        Debug.Log("Death Count: " + murders + " Score: " + score);
    }

    public int Score() {
        return score;
    }
}
