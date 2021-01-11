using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour {
    public static ProgressBar instance;

    public Slider slider;

    IEnumerator Start() {
        slider.value = slider.maxValue;

        while (slider.value > 0.0f) {
            yield return new WaitForSeconds(1.0f);
            slider.value -= 10.0f;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Awake() {
        instance = this;
    }

    // testing purposes
    private void Update() {
        if (Input.anyKeyDown) {
            slider.value += 5.0f;
        }    
    }
}
