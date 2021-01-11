using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {
    
    public TMPro.TextMeshProUGUI scoreText;
    private int score = 0;

    void Start() {
        Debug.Log("sad");
        score += PlayerPrefs.GetInt("score");
        scoreText.text += score;
        Debug.Log(scoreText.text);
    }
}
