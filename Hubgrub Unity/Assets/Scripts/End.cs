using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

    public TMPro.TextMeshProUGUI scoreText;
    private int score = 0;

    void Start() {
        score += ScoreManager.instance.Score();
        scoreText.text += score;
    }
}
